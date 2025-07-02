using System;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Newtonsoft.Json;

namespace CoreCms.Net.Task
{
    /// <summary>
    /// 订单自动签收任务
    /// </summary>
    public class AutoSignOrderJob
    {
        private readonly ICoreCmsOrderServices _orderServices;


        public AutoSignOrderJob(ICoreCmsOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _orderServices.AutoSignOrder();
        }

    }
}
