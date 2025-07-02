

using System;
using System.IO;
using System.Net;
using System.Text;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SqlSugar;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 短信发送日志 接口实现
    /// </summary>
    public class CoreCmsSmsRepository : BaseRepository<CoreCmsSms>, ICoreCmsSmsRepository
    {
        public CoreCmsSmsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
