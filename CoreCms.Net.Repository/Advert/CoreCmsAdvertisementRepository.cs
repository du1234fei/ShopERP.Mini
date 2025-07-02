
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     广告表 接口实现
    /// </summary>
    public class CoreCmsAdvertisementRepository : BaseRepository<CoreCmsAdvertisement>, ICoreCmsAdvertisementRepository
    {
        public CoreCmsAdvertisementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}