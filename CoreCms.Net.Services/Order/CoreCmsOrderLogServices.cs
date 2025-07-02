
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     订单记录表 接口实现
    /// </summary>
    public class CoreCmsOrderLogServices : BaseServices<CoreCmsOrderLog>, ICoreCmsOrderLogServices
    {
        private readonly ICoreCmsOrderLogRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsOrderLogServices(IUnitOfWork unitOfWork, ICoreCmsOrderLogRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}