
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 商品会员价表 接口实现
    /// </summary>
    public class CoreCmsGoodsGradeRepository : BaseRepository<CoreCmsGoodsGrade>, ICoreCmsGoodsGradeRepository
    {
        public CoreCmsGoodsGradeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
