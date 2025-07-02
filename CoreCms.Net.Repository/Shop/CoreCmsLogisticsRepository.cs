
using System;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 物流公司表 接口实现
    /// </summary>
    public class CoreCmsLogisticsRepository : BaseRepository<CoreCmsLogistics>, ICoreCmsLogisticsRepository
    {
        public CoreCmsLogisticsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
