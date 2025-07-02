
using System;
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
    /// 登录日志表 接口实现
    /// </summary>
    public class SysLoginRecordServices : BaseServices<SysLoginRecord>, ISysLoginRecordServices
    {
        private readonly ISysLoginRecordRepository _dal;
        private readonly IUnitOfWork _unitOfWork;
        public SysLoginRecordServices(IUnitOfWork unitOfWork, ISysLoginRecordRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }



    }
}
