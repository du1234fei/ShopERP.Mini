
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     文章分类表 接口实现
    /// </summary>
    public class CoreCmsArticleTypeServices : BaseServices<CoreCmsArticleType>, ICoreCmsArticleTypeServices
    {
        private readonly ICoreCmsArticleTypeRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsArticleTypeServices(IUnitOfWork unitOfWork, ICoreCmsArticleTypeRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}