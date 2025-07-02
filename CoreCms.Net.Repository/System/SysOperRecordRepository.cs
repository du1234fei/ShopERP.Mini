
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     操作日志表 接口实现
    /// </summary>
    public class SysOperRecordRepository : BaseRepository<SysOperRecord>, ISysOperRecordRepository
    {
        public SysOperRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}