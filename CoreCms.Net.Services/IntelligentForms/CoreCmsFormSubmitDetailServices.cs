
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
    /// 提交表单保存大文本值表 接口实现
    /// </summary>
    public class CoreCmsFormSubmitDetailServices : BaseServices<CoreCmsFormSubmitDetail>, ICoreCmsFormSubmitDetailServices
    {
        private readonly ICoreCmsFormSubmitDetailRepository _dal;
        private readonly IUnitOfWork _unitOfWork;
        public CoreCmsFormSubmitDetailServices(IUnitOfWork unitOfWork, ICoreCmsFormSubmitDetailRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }


    }
}
