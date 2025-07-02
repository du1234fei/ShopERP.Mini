
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 支付宝支付 接口实现
    /// </summary>
    public class AliPayRepository : BaseRepository<CoreCmsSetting>, IAliPayRepository
    {
        public AliPayRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}