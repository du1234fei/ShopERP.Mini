using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Utility.Consul
{
    /// <summary>
    /// Consul 注册
    /// </summary>
    public static class ConsulRegister
    {
        #region 服务注册
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            //获取主机生命周期管理接口
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(configuration["Consul:consulAddress"]);
                c.Datacenter = "orderService";
            });

            string ip = configuration["ip"];//优先接收变量的值
            string port = configuration["port"];//优先接收变量的值

            string currentIp = configuration["Consul:currentIP"];
            string currentPort = configuration["Consul:currentPort"];

            ip = string.IsNullOrEmpty(ip) ? currentIp : ip;//当前程序的 IP
            port = string.IsNullOrEmpty(port) ? currentPort : port;//当前程序的端口

            string serviceID = $"service:{ip}:{port}";

            //服务注册
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serviceID,//唯一的
                Name = configuration["Consul:serviceName"],//组名称-Group
                Address = ip,//IP 地址
                Port = int.Parse(port),//端口
                Tags = new string[] { "api 站点" },

                //健康检查
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(10),//多久检查一次心跳
                    HTTP = $"http://{ip}:{port}/Health",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5), //超时时间
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5)//服务启动多久后注册
                }

            }).Wait();

            //健康检查，不需要新建 Controller
            app.MapWhen(context => context.Request.Path.Equals("/Health"), appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync("Success");
                });
            });

            //应用程序终止时，取消注册
            lifetime.ApplicationStopping.Register(() => 
            {
                client.Agent.ServiceDeregister(serviceID).Wait();
            });

            return app;
        } 
        #endregion

    }
}
