
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     用户积分记录表 接口实现
    /// </summary>
    public class CoreCmsUserPointLogRepository : BaseRepository<CoreCmsUserPointLog>, ICoreCmsUserPointLogRepository
    {
        public CoreCmsUserPointLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}