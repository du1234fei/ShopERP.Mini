using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreCms.Net.Auth;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.AutoFac;
using CoreCms.Net.Core.Config;
using CoreCms.Net.Filter;
using CoreCms.Net.Loging;
using CoreCms.Net.Mapping;
using CoreCms.Net.Middlewares;
using CoreCms.Net.Swagger;
using CoreCms.Net.Task;
using CoreCms.Net.Web.WebApi.Infrastructure;
using Essensoft.Paylink.Alipay;
using Essensoft.Paylink.WeChatPay;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Web;

namespace CoreCms.Net.Web.WebApi
{
    /// <summary>
    /// ��ʼ����
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServicesToContainer();

            //AutoFacע��
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            //ʹ�� AutoFac �滻 .NET Core ���е� ����
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                //��ȡ���п��������Ͳ�ʹ������ע��
                var controllerBaseType = typeof(ControllerBase);

                containerBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                    .PropertiesAutowired();

                containerBuilder.RegisterModule(new AutofacModuleRegister());
            });

            var app = builder.Build();

            app.ConfigureRequestPipeline();

            try
            {
                //ȷ��NLog.config�������ַ�����appsettings.json��ͬ��
                NLogUtil.EnsureNlogConfig("NLog.config");

                //������Ŀ����ʱ��Ҫ��������
                NLogUtil.WriteLogFile(NLog.LogLevel.Trace, LogType.ApiRequest, "�ӿ�����", "�ӿ������ɹ�");

                app.Run();
            }
            catch (Exception ex)
            {
                //ʹ��Nlogд��������־�ļ�����һ���ݿ�û����/���ӳɹ���
                NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.ApiRequest, "�ӿ�����", "��ʼ�������쳣", ex);
                throw;
            }

        }
    }
}