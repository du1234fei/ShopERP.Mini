
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Services
{
    /// <summary>
    ///     售后单明细表 接口实现
    /// </summary>
    public class CoreCmsBillAftersalesItemServices : BaseServices<CoreCmsBillAftersalesItem>,
        ICoreCmsBillAftersalesItemServices
    {
        private readonly ICoreCmsBillAftersalesItemRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsBillAftersalesItemServices(IUnitOfWork unitOfWork, ICoreCmsBillAftersalesItemRepository dal)
        {
            _dal = dal;
            BaseDal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}