
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 退货单明细表 接口实现
    /// </summary>
    public class CoreCmsBillReshipItemRepository : BaseRepository<CoreCmsBillReshipItem>, ICoreCmsBillReshipItemRepository
    {
        public CoreCmsBillReshipItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

     
    }
}
