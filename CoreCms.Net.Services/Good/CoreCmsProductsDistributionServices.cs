
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;


namespace CoreCms.Net.Services
{
    /// <summary>
    /// 货品三级佣金表 接口实现
    /// </summary>
    public class CoreCmsProductsDistributionServices : BaseServices<CoreCmsProductsDistribution>, ICoreCmsProductsDistributionServices
    {
        private readonly ICoreCmsProductsDistributionRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public CoreCmsProductsDistributionServices(IUnitOfWork unitOfWork, ICoreCmsProductsDistributionRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }

    }
}
