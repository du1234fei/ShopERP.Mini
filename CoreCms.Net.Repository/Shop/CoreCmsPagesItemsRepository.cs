
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     单页内容 接口实现
    /// </summary>
    public class CoreCmsPagesItemsRepository : BaseRepository<CoreCmsPagesItems>, ICoreCmsPagesItemsRepository
    {
        public CoreCmsPagesItemsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}