
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     广告表 接口实现
    /// </summary>
    public class CoreCmsAdvertisementServices : BaseServices<CoreCmsAdvertisement>, ICoreCmsAdvertisementServices
    {
        private readonly ICoreCmsAdvertisementRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsAdvertisementServices(IUnitOfWork unitOfWork, ICoreCmsAdvertisementRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}