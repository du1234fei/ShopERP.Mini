
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 提交表单保存大文本值表 接口实现
    /// </summary>
    public class CoreCmsFormSubmitDetailRepository : BaseRepository<CoreCmsFormSubmitDetail>, ICoreCmsFormSubmitDetailRepository
    {
        public CoreCmsFormSubmitDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
