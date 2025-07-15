using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreCms.Net.Auth.OverWrite;
using CoreCms.Net.Auth.Policys;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.DTO.UserInfo;
using CoreCms.Net.Model.ViewModels.Email;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Services;
using CoreCms.Net.Utility.Extensions;
using CoreCms.Net.Utility.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    /// 用户授权登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly PermissionRequirement _permissionRequirement;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ISysUserServices _sysUserServices;
        private readonly ISysRoleMenuServices _sysRoleMenuServices;
        private readonly ISysLoginRecordRepository _sysLoginRecordRepository;
        private readonly ICoreCmsUserServices _coreCmsUserServices;
        private readonly EmailSenderHelper _emailSender;//发邮件的服务

        #region 构造函数注入
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public LoginController(
            PermissionRequirement permissionRequirement
            , ICoreCmsUserServices coreCmsUserServices
            , ISysUserServices sysUserServices
            , ISysRoleMenuServices sysRoleMenuServices
            , IHttpContextAccessor httpContextAccessor
            , ISysLoginRecordRepository sysLoginRecordRepository
            , EmailSenderHelper emailSender
            )
        {
            _permissionRequirement = permissionRequirement;
            _sysUserServices = sysUserServices;
            _sysRoleMenuServices = sysRoleMenuServices;
            _httpContextAccessor = httpContextAccessor;
            _sysLoginRecordRepository = sysLoginRecordRepository;
            _coreCmsUserServices = coreCmsUserServices;
            _emailSender = emailSender;
        }
        #endregion

        #region 获取JWT的授权
        /// <summary>
        /// 获取JWT的授权
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AdminUiCallBack> GetJwtToken([FromBody] FMLogin model)
        {
            var jm = new AdminUiCallBack();
            if (string.IsNullOrEmpty(model.userName) || string.IsNullOrEmpty(model.password))
            {
                jm.msg = "用户名或密码不能为空";
                return jm;
            }

            model.password = CommonHelper.Md5For32(model.password);
            var user = await _sysUserServices.QueryByClauseAsync(p => p.userName == model.userName && p.passWord == model.password);
            if (user != null)
            {
                if (user.state == 1)
                {
                    jm.msg = "您的账户已经被冻结,请联系管理员解锁";
                    return jm;
                }

                var userRoles = await _sysUserServices.GetUserRoleNameStr(model.userName, model.password);

                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                        new Claim(ClaimTypes.GivenName, user.nickName),
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.id.ToString()),
                        new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString())
                };

                claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                // ids4和jwt切换
                // jwt
                if (!Permissions.IsUseIds4)
                {
                    var data = await _sysRoleMenuServices.RoleModuleMaps();
                    var list = (from item in data
                                orderby item.id
                                select new PermissionItem
                                {
                                    Url = item.menu?.component,
                                    RouteUrl = item.menu?.path,
                                    Authority = item.menu?.authority,
                                    Role = item.role?.roleCode,
                                }).ToList();

                    _permissionRequirement.Permissions = list;
                }

                //用户标识
                var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                identity.AddClaims(claims);

                var token = JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);

                jm.code = 0;
                jm.msg = "认证成功";
                jm.data = new
                {
                    token,
                    loginUrl = "Panel.html"
                };

                //插入登录日志
                var log = new SysLoginRecord();
                log.username = model.userName;
                log.ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress != null ?
                    _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() : "127.0.0.1";

                log.os = RuntimeInformation.OSDescription;
                if (_httpContextAccessor.HttpContext != null)
                    log.browser = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent];
                log.operType = (int)GlobalEnumVars.LoginRecordType.登录成功;
                log.createTime = DateTime.Now;

                await _sysLoginRecordRepository.InsertAsync(log);

                return jm;
            }
            else
            {
                //插入登录日志
                var log = new SysLoginRecord();
                log.username = model.userName;
                log.ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress != null ?
                    _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString() : "127.0.0.1";

                log.os = RuntimeInformation.OSDescription;
                if (_httpContextAccessor.HttpContext != null)
                    log.browser = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent];
                log.operType = (int)GlobalEnumVars.LoginRecordType.登录失败;
                log.createTime = DateTime.Now;
                await _sysLoginRecordRepository.InsertAsync(log);

                jm.msg = "账户密码错误";
                return jm;
            }
        }
        #endregion

        #region 请求刷新Token（以旧换新）
        /// <summary>
        /// 请求刷新Token（以旧换新）
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<AdminUiCallBack> RefreshToken(string token = "")
        {
            var jm = new AdminUiCallBack();
            if (string.IsNullOrEmpty(token))
            {
                jm.code = 1001;
                jm.msg = "token无效，请重新登录！";
                return jm;
            }
            var tokenModel = JwtHelper.SerializeJwt(token);
            if (tokenModel != null && tokenModel.Uid > 0)
            {
                var user = await _sysUserServices.QueryByIdAsync(tokenModel.Uid);
                if (user != null)
                {
                    var userRoles = await _sysUserServices.GetUserRoleNameStr(user.userName, user.passWord);

                    //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid.ObjectToString()),
                        new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString())
                    };

                    claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                    //用户标识
                    var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);

                    var refreshToken = JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);
                    jm.code = 0;
                    jm.msg = "认证成功";
                    jm.data = refreshToken;

                    //插入登录日志
                    var log = new SysLoginRecord();
                    log.username = user.userName;
                    if (_httpContextAccessor.HttpContext != null)
                    {
                        if (_httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                        {
                            log.ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                        }
                        log.os = RuntimeInformation.OSDescription;
                        log.browser = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent];
                    }

                    log.operType = (int)GlobalEnumVars.LoginRecordType.刷新Token;
                    log.createTime = DateTime.Now;
                    await _sysLoginRecordRepository.InsertAsync(log);

                    return jm;
                }
            }
            jm.code = 1001;
            jm.msg = "token无效，请重新登录！";
            return jm;
        }
        #endregion


        #region 用户注册============================================================
        // POST: api/login/DoCreate
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("用户注册")]
        public async Task<AdminUiCallBack> DoCreate([FromBody] UserRegisterModel param)
        {
            var jm = new AdminUiCallBack();

            if (string.IsNullOrEmpty(param.phone))
            {
                jm.msg = "请输入用户手机号";
                return jm;
            }

            var isHave = await _sysUserServices.ExistsAsync(p => p.phone == param.phone);
            if (isHave)
            {
                jm.msg = "已存在此手机号码";
                return jm;
            }

            SysUser entity = new SysUser();
            entity.userName = param.userName;
            entity.passWord = CommonHelper.Md5For32(param.passWord);
            entity.nickName = param.nickName;
            entity.sex = 0;
            entity.phone = param.phone;
            entity.email = param.email;
            entity.createTime = DateTime.Now;
            entity.updateTime = DateTime.Now;

            var bl = await _sysUserServices.InsertAsync(entity) > 0;
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.CreateSuccess : GlobalConstVars.CreateFailure;
            return jm;
        }

        #endregion

        #region 忘记密码-发送验证码
        /// <summary>
        /// POST: api/login/DoSendValidCode
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("发送验证码修改密码")]
        public async Task<AdminUiCallBack> DoSendValidCode([FromBody] FMSendValidCodeForgetPasswordPost param)
        {
            var jm = new AdminUiCallBack();

            if (string.IsNullOrEmpty(param.userEmail))
            {
                jm.msg = "请输入用户邮箱！";
                return jm;
            }

            var user = await _sysUserServices.QueryByClauseAsync(p => p.userName == param.userName && p.email == param.userEmail);
            if (user != null)
            {
                if (user.state == 1)
                {
                    jm.msg = "您的账户已经被冻结,请联系管理员解锁";
                    return jm;
                }

                //发送验证码, 发送邮件
                Random rd = new Random();
                int codeNumber = rd.Next(100000, 999999);

                SendVerificationEmailAsync(param.userEmail, codeNumber.ToString());

                var bl = true;
                jm.code = bl ? 0 : 1;
                jm.msg = bl ? GlobalConstVars.SendEmailSuccess : GlobalConstVars.SendEmailFailure;
                return jm;
            }
            else
            {
                jm.msg = "您输入的用户与邮箱不匹配！";
                return jm;
            }
        }

        /// <summary>
        /// 异步发送验证码
        /// </summary>
        /// <param name="email"></param>
        /// <param name="verificationCode"></param>
        public async void SendVerificationEmailAsync(string email, string verificationCode)
        {
            var message = new MailMessageModel()
            {
                ToAddresses = new List<string> { email },
                Subject = "邮箱验证码",
                Body = $"""
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset="utf-8">
                        <title>邮箱验证</title>
                    </head>
                    <body>
                        <div style="max-width: 600px; margin: 0 auto; font-family: Arial, sans-serif;">
                            <h2 style="color: #1e9fff;">邮箱验证请求</h2>
                            <p>您的验证码是：<strong style="font-size: 24px; letter-spacing: 2px;">
                                {verificationCode}
                            </strong></p>
                            <p>验证码将在30分钟后失效，请尽快使用。</p>
                            <hr style="border: 0; border-top: 1px solid #eee;">
                            <p style="color: #999; font-size: 12px;">此为系统邮件，请勿直接回复</p>
                        </div>
                    </body>
                    </html>
                    """,

                IsBodyHtml = true
            };

            await _emailSender.SendEmailAsync(message);
        }

        #endregion

    }
}
