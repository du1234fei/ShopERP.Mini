using System;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Newtonsoft.Json;

namespace CoreCms.Net.Task
{
    /// <summary>
    /// 订单催付款任务
    /// </summary>
    public class RemindOrderPayJob
    {
        private readonly ICoreCmsOrderServices _orderServices;


        public RemindOrderPayJob(ICoreCmsOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _orderServices.RemindOrderPay();
        }
    }
}
