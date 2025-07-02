using Autofac.Extensions.DependencyInjection;
using CoreCms.Net.Loging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Linq;
using Autofac;
using CoreCms.Net.Auth;
using CoreCms.Net.Configuration;
using CoreCms.Net.Core.AutoFac;
using CoreCms.Net.Core.Config;
using CoreCms.Net.Filter;
using CoreCms.Net.Mapping;
using CoreCms.Net.Middlewares;
using CoreCms.Net.Swagger;
using CoreCms.Net.Web.Admin.Infrastructure;
using Essensoft.Paylink.Alipay;
using Essensoft.Paylink.WeChatPay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Yitter.IdGenerator;

namespace CoreCms.Net.Web.Admin
{
    /// <summary>
    /// ����ʼ����
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
            
            // ѩ��Ư���㷨
            // ���� IdGeneratorOptions �������ڹ��캯�������� WorkerId��
            var options = new IdGeneratorOptions(1);

            // �������������Ĳ����������������ö�������Ч����
            YitIdHelper.SetIdGenerator(options);

            //AutoFacע��
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
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