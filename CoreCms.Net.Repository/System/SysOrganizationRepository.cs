
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     组织机构表 接口实现
    /// </summary>
    public class SysOrganizationRepository : BaseRepository<SysOrganization>, ISysOrganizationRepository
    {
        public SysOrganizationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}