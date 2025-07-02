
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     第三方授权记录表 接口实现
    /// </summary>
    public class CoreCmsApiAccessTokenServices : BaseServices<CoreCmsApiAccessToken>, ICoreCmsApiAccessTokenServices
    {
        private readonly ICoreCmsApiAccessTokenRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsApiAccessTokenServices(IUnitOfWork unitOfWork, ICoreCmsApiAccessTokenRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}