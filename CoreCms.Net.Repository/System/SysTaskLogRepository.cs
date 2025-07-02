
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     定时任务日志 接口实现
    /// </summary>
    public class SysTaskLogRepository : BaseRepository<SysTaskLog>, ISysTaskLogRepository
    {
        public SysTaskLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}