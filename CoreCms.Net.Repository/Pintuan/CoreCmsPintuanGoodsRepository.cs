

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 拼团商品表 接口实现
    /// </summary>
    public class CoreCmsPinTuanGoodsRepository : BaseRepository<CoreCmsPinTuanGoods>, ICoreCmsPinTuanGoodsRepository
    {
        public CoreCmsPinTuanGoodsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

     

    }
}
