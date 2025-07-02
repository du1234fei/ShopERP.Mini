
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     用户日志 接口实现
    /// </summary>
    public class CoreCmsUserLogRepository : BaseRepository<CoreCmsUserLog>, ICoreCmsUserLogRepository
    {
        public CoreCmsUserLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}