
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 微信支付 接口实现
    /// </summary>
    public class WeChatPayRepository : BaseRepository<CoreCmsSetting>, IWeChatPayRepository
    {
        public WeChatPayRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}