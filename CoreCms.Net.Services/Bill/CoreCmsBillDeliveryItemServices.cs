
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     发货单详情表 接口实现
    /// </summary>
    public class CoreCmsBillDeliveryItemServices : BaseServices<CoreCmsBillDeliveryItem>,
        ICoreCmsBillDeliveryItemServices
    {
        private readonly ICoreCmsBillDeliveryItemRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsBillDeliveryItemServices(IUnitOfWork unitOfWork, ICoreCmsBillDeliveryItemRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}