
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.IServices
{
    /// <summary>
    ///     订单明细表 服务工厂接口
    /// </summary>
    public interface ICoreCmsOrderItemServices : IBaseServices<CoreCmsOrderItem>
    {
        /// <summary>
        ///     发货数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="item">发货明细</param>
        /// <returns></returns>
        Task<bool> ship(string orderId, Dictionary<int, int> item);
    }
}