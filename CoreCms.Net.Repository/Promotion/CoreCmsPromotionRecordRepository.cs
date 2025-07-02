
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoreCms.Net.Caching.Manual;
using CoreCms.Net.Configuration;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.ViewModels.UI;
using SqlSugar;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 促销活动记录表 接口实现
    /// </summary>
    public class CoreCmsPromotionRecordRepository : BaseRepository<CoreCmsPromotionRecord>, ICoreCmsPromotionRecordRepository
    {
        public CoreCmsPromotionRecordRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
