
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     文章分类表 接口实现
    /// </summary>
    public class CoreCmsArticleTypeRepository : BaseRepository<CoreCmsArticleType>, ICoreCmsArticleTypeRepository
    {
        public CoreCmsArticleTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}