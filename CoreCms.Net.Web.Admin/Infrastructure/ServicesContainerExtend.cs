using CoreCms.Net.Auth;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.Config;
using CoreCms.Net.Loging;
using CoreCms.Net.Mapping;
using Essensoft.Paylink.Alipay;
using Essensoft.Paylink.WeChatPay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoreCms.Net.Web.Admin.Infrastructure
{
    /// <summary>
    /// 服务容器-扩展
    /// </summary>
    public static class ServicesContainerExtend
    {
        #region 添加服务到容器中
        /// <summary>
        /// 添加服务到容器中
        /// </summary>
        /// <param name="builder"></param>
        public static void AddServicesToContainer(this WebApplicationBuilder builder)
        {
            //添加本地路径获取支持
            builder.Services.AddSingleton(new AppSettingsHelper(builder.Environment.ContentRootPath));
            builder.Services.AddSingleton(new LogLockHelper(builder.Environment.ContentRootPath));

            //Memory缓存
            builder.Services.AddMemoryCacheSetup();
            //Redis缓存
            builder.Services.AddRedisCacheSetup();

            //添加数据库连接SqlSugar注入支持
            builder.Services.AddSqlSugarSetup();
            //配置跨域（CORS）
            builder.Services.AddCorsSetup();

            //添加session支持(session依赖于cache进行存储)
            builder.Services.AddSession();
            // AutoMapper支持
            builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
            //使用 SignalR
            builder.Services.AddSignalR();

            // 注入工厂 HTTP 客户端
            builder.Services.AddHttpClient();

            //Swagger接口文档注入
            builder.Services.AddAdminSwaggerSetup();

            //配置易联云打印机
            builder.Services.AddYiLianYunSetup();

            //jwt授权支持注入
            builder.Services.AddAuthorizationSetupForAdmin();
            //上下文注入
            builder.Services.AddHttpContextSetup();

            //服务配置中加入AutoFac控制器替换规则。
            builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //注册mvc，注册razor引擎视图
            builder.Services.AddMvc(options =>
            {
                //实体验证
                options.Filters.Add<RequiredErrorForAdmin>();

                //异常处理
                options.Filters.Add<GlobalExceptionsFilterForAdmin>();

                //Swagger剔除不需要加入api展示的列表
                options.Conventions.Add(new ApiExplorerIgnores());

                options.EnableEndpointRouting = false;
            })
            .AddNewtonsoftJson(p =>
            {
                //数据格式首字母小写 不使用驼峰
                p.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //不使用驼峰样式的key
                //p.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //忽略循环引用
                p.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //设置时间格式
                p.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });


        }
        #endregion

    }
}
