
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;

namespace CoreCms.Net.IRepository
{
    /// <summary>
    ///     发货单表 工厂接口
    /// </summary>
    public interface ICoreCmsBillDeliveryRepository : IBaseRepository<CoreCmsBillDelivery>
    {
        /// <summary>
        ///     发货单统计7天统计
        /// </summary>
        /// <returns></returns>
        Task<List<StatisticsOut>> Statistics();
    }
}