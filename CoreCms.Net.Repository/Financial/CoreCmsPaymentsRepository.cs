
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     支付方式表 接口实现
    /// </summary>
    public class CoreCmsPaymentsRepository : BaseRepository<CoreCmsPayments>, ICoreCmsPaymentsRepository
    {
        public CoreCmsPaymentsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}