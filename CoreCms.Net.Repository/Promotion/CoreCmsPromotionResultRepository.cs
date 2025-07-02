
using System;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 促销结果表 接口实现
    /// </summary>
    public class CoreCmsPromotionResultRepository : BaseRepository<CoreCmsPromotionResult>, ICoreCmsPromotionResultRepository
    {
        public CoreCmsPromotionResultRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
