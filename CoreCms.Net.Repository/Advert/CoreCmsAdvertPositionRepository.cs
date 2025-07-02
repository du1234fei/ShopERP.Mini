
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     广告位置表 接口实现
    /// </summary>
    public class CoreCmsAdvertPositionRepository : BaseRepository<CoreCmsAdvertPosition>,
        ICoreCmsAdvertPositionRepository
    {
        public CoreCmsAdvertPositionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}