

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     标签表 接口实现
    /// </summary>
    public class CoreCmsLabelServices : BaseServices<CoreCmsLabel>, ICoreCmsLabelServices
    {
        private readonly ICoreCmsLabelRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsLabelServices(IUnitOfWork unitOfWork, ICoreCmsLabelRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}