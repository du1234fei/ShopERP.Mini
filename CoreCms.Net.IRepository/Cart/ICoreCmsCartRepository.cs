
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.IRepository
{
    /// <summary>
    ///     购物车表 工厂接口
    /// </summary>
    public interface ICoreCmsCartRepository : IBaseRepository<CoreCmsCart>
    {
        /// <summary>
        ///     获取购物车用户数据总数
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync(int userId);
    }
}