
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     广告位置表 接口实现
    /// </summary>
    public class CoreCmsAdvertPositionServices : BaseServices<CoreCmsAdvertPosition>, ICoreCmsAdvertPositionServices
    {
        private readonly ICoreCmsAdvertPositionRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsAdvertPositionServices(IUnitOfWork unitOfWork, ICoreCmsAdvertPositionRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}