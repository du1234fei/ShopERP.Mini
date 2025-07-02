
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 商品参数表 接口实现
    /// </summary>
    public class CoreCmsGoodsParamsRepository : BaseRepository<CoreCmsGoodsParams>, ICoreCmsGoodsParamsRepository
    {
        public CoreCmsGoodsParamsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
