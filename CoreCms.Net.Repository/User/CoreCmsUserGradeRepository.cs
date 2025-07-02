

using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     用户等级表 接口实现
    /// </summary>
    public class CoreCmsUserGradeRepository : BaseRepository<CoreCmsUserGrade>, ICoreCmsUserGradeRepository
    {
        public CoreCmsUserGradeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}