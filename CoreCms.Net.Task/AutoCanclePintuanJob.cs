using System;
using CoreCms.Net.IServices;
using CoreCms.Net.Loging;
using CoreCms.Net.Model.Entities;
using Newtonsoft.Json;

namespace CoreCms.Net.Task
{
    /// <summary>
    /// 拼团自动取消到期团
    /// </summary>
    public class AutoCanclePinTuanJob
    {
        private readonly ICoreCmsPinTuanRecordServices _pinTuanRecordServices;


        public AutoCanclePinTuanJob(ICoreCmsPinTuanRecordServices pinTuanRecordServices)
        {
            _pinTuanRecordServices = pinTuanRecordServices;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            await _pinTuanRecordServices.AutoCanclePinTuanOrder();
        }
    }
}
