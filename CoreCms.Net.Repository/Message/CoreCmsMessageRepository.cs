
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Net.Configuration;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 消息发送表 接口实现
    /// </summary>
    public class CoreCmsMessageRepository : BaseRepository<CoreCmsMessage>, ICoreCmsMessageRepository
    {
        public CoreCmsMessageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

      
    }
}
