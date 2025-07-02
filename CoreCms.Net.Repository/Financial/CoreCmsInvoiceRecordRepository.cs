

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     发票信息记录 接口实现
    /// </summary>
    public class CoreCmsInvoiceRecordRepository : BaseRepository<CoreCmsInvoiceRecord>, ICoreCmsInvoiceRecordRepository
    {
        public CoreCmsInvoiceRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}