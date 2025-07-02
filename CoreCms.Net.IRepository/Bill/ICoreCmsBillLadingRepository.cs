
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;

namespace CoreCms.Net.IRepository
{
    /// <summary>
    ///     提货单表 工厂接口
    /// </summary>
    public interface ICoreCmsBillLadingRepository : IBaseRepository<CoreCmsBillLading>
    {
        /// <summary>
        ///     添加提货单
        /// </summary>
        /// <returns></returns>
        Task<WebApiCallBack> AddData(string orderId, int storeId, string name, string mobile);
    }
}