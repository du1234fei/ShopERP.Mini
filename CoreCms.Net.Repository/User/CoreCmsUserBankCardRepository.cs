
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     银行卡信息 接口实现
    /// </summary>
    public class CoreCmsUserBankCardRepository : BaseRepository<CoreCmsUserBankCard>, ICoreCmsUserBankCardRepository
    {
        public CoreCmsUserBankCardRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}