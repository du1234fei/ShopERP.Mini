
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     Nlog记录表 接口实现
    /// </summary>
    public class SysNLogRecordsRepository : BaseRepository<SysNLogRecords>, ISysNLogRecordsRepository
    {
        public SysNLogRecordsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}