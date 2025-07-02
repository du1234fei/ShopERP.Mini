
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     标签表 接口实现
    /// </summary>
    public class CoreCmsLabelRepository : BaseRepository<CoreCmsLabel>, ICoreCmsLabelRepository
    {
        public CoreCmsLabelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}