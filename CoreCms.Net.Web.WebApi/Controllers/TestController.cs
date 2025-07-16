using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.Email;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoreCms.Net.Web.WebApi.Controllers
{
    /// <summary>
    /// 用户测试事件
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly EmailSenderHelper _emailSender;//发邮件的服务

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="emailSender"></param>
        public TestController(EmailSenderHelper emailSender)
        {
            _emailSender = emailSender;
        }

        #region 用户邮箱发送===================================================================
        /// <summary>
        /// 用户邮箱发送
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<WebApiCallBack> SendEmail([FromBody] FMSendEmail entity)
        {
            var jm = new WebApiCallBack();
            if (string.IsNullOrEmpty(entity.email))
            {
                jm.msg = "请输入合法的邮箱地址";
                return jm;
            }

            //发送验证码, 发送邮件
            Random rd = new Random();
            int codeNumber = rd.Next(100000, 999999);

            var message = new MailMessageModel()
            {
                ToAddresses = new List<string> { entity.email },
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
                                {codeNumber}
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

            // 在应用启动代码前添加
            System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            await _emailSender.SendWithMailKitAsync(message);

            return jm;
        }
        #endregion

    }
}
