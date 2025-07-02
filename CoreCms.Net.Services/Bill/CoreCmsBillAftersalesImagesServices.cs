

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     商品图片关联表 接口实现
    /// </summary>
    public class CoreCmsBillAftersalesImagesServices : BaseServices<CoreCmsBillAftersalesImages>,
        ICoreCmsBillAftersalesImagesServices
    {
        private readonly ICoreCmsBillAftersalesImagesRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsBillAftersalesImagesServices(IUnitOfWork unitOfWork, ICoreCmsBillAftersalesImagesRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}