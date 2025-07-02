

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 订单记录表 接口实现
    /// </summary>
    public class CoreCmsOrderLogRepository : BaseRepository<CoreCmsOrderLog>, ICoreCmsOrderLogRepository
    {
        public CoreCmsOrderLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
