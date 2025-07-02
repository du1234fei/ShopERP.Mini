
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     登录日志表 接口实现
    /// </summary>
    public class SysLoginRecordRepository : BaseRepository<SysLoginRecord>, ISysLoginRecordRepository
    {
        public SysLoginRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}