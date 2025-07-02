
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 商品类型属性值表 接口实现
    /// </summary>
    public class CoreCmsGoodsTypeSpecValueRepository : BaseRepository<CoreCmsGoodsTypeSpecValue>, ICoreCmsGoodsTypeSpecValueRepository
    {
        public CoreCmsGoodsTypeSpecValueRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
