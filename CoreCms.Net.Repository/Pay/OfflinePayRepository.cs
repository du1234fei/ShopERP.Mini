
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 线下支付 接口实现
    /// </summary>
    public class OfflinePayRepository : BaseRepository<CoreCmsSetting>, IOfflinePayRepository
    {
        public OfflinePayRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}