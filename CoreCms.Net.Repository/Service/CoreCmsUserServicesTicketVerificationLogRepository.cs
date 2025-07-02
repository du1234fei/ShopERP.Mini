
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     服务券核验日志 接口实现
    /// </summary>
    public class CoreCmsUserServicesTicketVerificationLogRepository :
        BaseRepository<CoreCmsUserServicesTicketVerificationLog>, ICoreCmsUserServicesTicketVerificationLogRepository
    {
        public CoreCmsUserServicesTicketVerificationLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}