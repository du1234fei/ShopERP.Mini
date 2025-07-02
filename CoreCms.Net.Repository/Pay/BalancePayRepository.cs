
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 余额支付 接口实现
    /// </summary>
    public class BalancePayRepository : BaseRepository<CoreCmsSetting>, IBalancePayRepository
    {
        public BalancePayRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}