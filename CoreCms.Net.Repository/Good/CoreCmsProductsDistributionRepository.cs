
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Caching.Manual;
using CoreCms.Net.Configuration;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.ViewModels.UI;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 货品三级佣金表 接口实现
    /// </summary>
    public class CoreCmsProductsDistributionRepository : BaseRepository<CoreCmsProductsDistribution>, ICoreCmsProductsDistributionRepository
    {
        public CoreCmsProductsDistributionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
