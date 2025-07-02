
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Net.Caching;
using CoreCms.Net.Caching.Manual;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Model.ViewModels.UI;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 店铺设置表 接口实现
    /// </summary>
    public class CoreCmsSettingRepository : BaseRepository<CoreCmsSetting>, ICoreCmsSettingRepository
    {
        public CoreCmsSettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}
