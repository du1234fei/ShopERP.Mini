using Consul;

namespace ConsulAndOcelot.ApiGateWay.Infrastructure
{
    /// <summary>
    /// Consul 服务发现-帮助类
    /// </summary>
    public class ConsulServiceDiscover
    {
        private IConfiguration _configuration;
        public ConsulServiceDiscover(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region 根据服务名称获取服务地址
        /// <summary>
        /// 根据服务名称获取服务地址
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetDomainByServiceName(string serviceName)
        {
            string domain = string.Empty;

            //Consul 客户端, 用 Using 包起来的程序域会被自动 回收
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(_configuration["Consul:consulAddress"]);
                c.Datacenter = "apiService";
            }))

            {
                //根据服务名获取健康的服务
                var queryResult = client.Health.Service(serviceName, string.Empty, true);
                var len = queryResult.Result.Response.Length;

                //平均策略-多个负载中随机获取一个
                var node = queryResult.Result.Response[new Random().Next(len)];
                domain = $"http://{node.Service.Address}:{node.Service.Port}";

            }

            return domain;
        }
        #endregion

        #region 获取 api 域名
        /// <summary>
        /// 获取 api 域名
        /// </summary>
        /// <returns></returns>
        public string GetApiDomin()
        {
            return GetDomainByServiceName(_configuration["Consul:apiServiceName"]);
        } 
        #endregion



    }

}
