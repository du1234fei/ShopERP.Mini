
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.IServices
{
    /// <summary>
    ///     拼团商品表 服务工厂接口
    /// </summary>
    public interface ICoreCmsPinTuanGoodsServices : IBaseServices<CoreCmsPinTuanGoods>
    {
        /// <summary>
        ///     取拼团的商品信息，增加拼团的一些属性，会显示优惠价
        /// </summary>
        /// <returns></returns>
        Task<CoreCmsGoods> GetGoodsInfo(int id, int userId, int pinTuanStatus = 0);
    }
}