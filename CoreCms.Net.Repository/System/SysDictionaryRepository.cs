
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     数据字典表 接口实现
    /// </summary>
    public class SysDictionaryRepository : BaseRepository<SysDictionary>, ISysDictionaryRepository
    {
        public SysDictionaryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}