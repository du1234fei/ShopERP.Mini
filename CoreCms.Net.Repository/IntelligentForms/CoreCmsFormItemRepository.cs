
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     表单项表 接口实现
    /// </summary>
    public class CoreCmsFormItemRepository : BaseRepository<CoreCmsFormItem>, ICoreCmsFormItemRepository
    {
        public CoreCmsFormItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}