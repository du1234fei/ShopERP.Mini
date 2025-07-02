
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     发货单详情表 接口实现
    /// </summary>
    public class CoreCmsBillDeliveryItemRepository : BaseRepository<CoreCmsBillDeliveryItem>,
        ICoreCmsBillDeliveryItemRepository
    {
        public CoreCmsBillDeliveryItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}