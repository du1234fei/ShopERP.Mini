using System;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Newtonsoft.Json;

namespace CoreCms.Net.Task
{
    /// <summary>
    /// 订单自动完成任务
    /// </summary>
    public class CompleteOrderJob
    {
        private readonly ICoreCmsOrderServices _orderServices;

        public CompleteOrderJob(ICoreCmsOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _orderServices.AutoCompleteOrder();
        }
    }
}
