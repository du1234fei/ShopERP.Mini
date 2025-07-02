using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.IServices.Warehouse;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Model.ViewModels.DTO;
using CoreCms.Net.Model.ViewModels.UI;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Services.Warehouse
{
    /// <summary>
    /// 库存表 业务层
    /// </summary>
    public class InventoriesServices : BaseServices<Inventories>, IinventoriesServices
    {
        private readonly IinventoriesRepository _dal;
        private readonly IUnitOfWork _unitOfWork;

        public InventoriesServices(IUnitOfWork unitOfWork, IinventoriesRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
            _unitOfWork = unitOfWork;
        }

        #region 实现重写增删改查操作
        async Task<AdminUiCallBack> IinventoriesServices.InsertAsync(Inventories entity)
        {
            return await _dal.InsertAsync(entity);
        }

        async Task<AdminUiCallBack> IinventoriesServices.UpdateAsync(Inventories entity)
        {
            return await _dal.UpdateAsync(entity);
        }

        async Task<AdminUiCallBack> IinventoriesServices.UpdateAsync(List<Inventories> entity)
        {
            return await _dal.UpdateAsync(entity);
        }

        async Task<AdminUiCallBack> IinventoriesServices.DeleteByIdAsync(object id)
        {
            return await _dal.DeleteByIdAsync(id);
        }

        async Task<AdminUiCallBack> IinventoriesServices.DeleteByIdsAsync(int[] ids)
        {
            return await _dal.DeleteByIdAsync(ids);
        }
        #endregion

        #region 对 Cache 缓存的操作
        public async Task<List<Inventories>> GetCache()
        {
            return await _dal.GetCache();
        }

        public async Task<List<Inventories>> UpdateCache()
        {
            return await _dal.UpdateCache();
        }
        #endregion

        #region 重写-根据条件查询分页数据
        /// <summary>
        /// 重写-根据条件查询分页数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="blUseNoLock"></param>
        /// <returns></returns>
        public new async Task<IPageList<Inventories>> QueryPageAsync(Expression<Func<Inventories, bool>> predicate,
            Expression<Func<Inventories, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1,
            int pageSize = 20, bool blUseNoLock = false)
        {
            return await _dal.QueryPageAsync(predicate, orderByExpression, orderByType, pageIndex, pageSize, blUseNoLock);
        }
        #endregion

        #region 通过原生 Sql 根据条件查询分页数据
        /// <summary>
        /// 通过原生 Sql 根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">判断集合</param>
        /// <param name="orderByType">排序方式</param>
        /// <param name="pageIndex">当前页面索引</param>
        /// <param name="pageSize">分布大小</param>
        /// <param name="orderByExpression"></param>
        /// <param name="blUseNoLock">是否使用WITH(NOLOCK)</param>
        /// <returns></returns>
        public async Task<IPageList<GoodsInventoriesDto>> SqlQueryPageAsync(
            Expression<Func<GoodsInventoriesDto, bool>> predicate,
            Expression<Func<GoodsInventoriesDto, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 20, bool blUserNoLock = false)
        {
            return await _dal.SqlQueryPageAsync(predicate, orderByExpression, orderByType, pageIndex, pageSize, blUserNoLock);
        }
        #endregion

    }
}
