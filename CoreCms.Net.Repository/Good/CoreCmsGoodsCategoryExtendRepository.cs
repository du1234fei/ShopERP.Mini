
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     商品分类扩展表 接口实现
    /// </summary>
    public class CoreCmsGoodsCategoryExtendRepository : BaseRepository<CoreCmsGoodsCategoryExtend>,
        ICoreCmsGoodsCategoryExtendRepository
    {
        public CoreCmsGoodsCategoryExtendRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}