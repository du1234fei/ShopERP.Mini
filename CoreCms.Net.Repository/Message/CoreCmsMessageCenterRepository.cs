
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 消息配置表 接口实现
    /// </summary>
    public class CoreCmsMessageCenterRepository : BaseRepository<CoreCmsMessageCenter>, ICoreCmsMessageCenterRepository
    {
        public CoreCmsMessageCenterRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}
