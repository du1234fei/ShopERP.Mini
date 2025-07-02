
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     品牌表 接口实现
    /// </summary>
    public class CoreCmsBrandRepository : BaseRepository<CoreCmsBrand>, ICoreCmsBrandRepository
    {
        public CoreCmsBrandRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}