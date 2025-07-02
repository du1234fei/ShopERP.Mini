
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     售后单明细表 接口实现
    /// </summary>
    public class CoreCmsBillAftersalesItemRepository : BaseRepository<CoreCmsBillAftersalesItem>,
        ICoreCmsBillAftersalesItemRepository
    {
        public CoreCmsBillAftersalesItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}