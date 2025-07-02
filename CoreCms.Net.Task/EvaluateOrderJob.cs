using System;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Newtonsoft.Json;

namespace CoreCms.Net.Task
{
    /// <summary>
    /// 自动评价订单任务
    /// </summary>
    public class EvaluateOrderJob
    {
        private readonly ICoreCmsOrderServices _orderServices;


        public EvaluateOrderJob(ICoreCmsOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _orderServices.AutoEvaluateOrder();
        }
    }
}
