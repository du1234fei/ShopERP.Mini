
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    ///     商品图片关联表 接口实现
    /// </summary>
    public class CoreCmsBillAftersalesImagesRepository : BaseRepository<CoreCmsBillAftersalesImages>,
        ICoreCmsBillAftersalesImagesRepository
    {
        public CoreCmsBillAftersalesImagesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}