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

namespace CoreCms.Net.IServices.Warehouse
{
    /// <summary>
    /// 库存表 -服务工厂接口
    /// </summary>
    public interface IinventoriesServices : IBaseServices<Inventories>
    {
        #region 重写增删改查的操作
        /// <summary>
        /// 重写异步插入方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        new Task<AdminUiCallBack> InsertAsync(Inventories entity);

        /// <summary>
        /// 重写异步更新方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        new Task<AdminUiCallBack> UpdateAsync(Inventories entity);

        /// <summary>
        /// 重写异步批量更新方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        new Task<AdminUiCallBack> UpdateAsync(List<Inventories> entity);

        /// <summary>
        /// 重写删除指定 ID 的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        new Task<AdminUiCallBack> DeleteByIdAsync(object id);

        /// <summary>
        /// 重写批量删除指定 ID 集合的数据 (批量删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        new Task<AdminUiCallBack> DeleteByIdsAsync(int[] ids);
        #endregion

        #region 与缓存相关的操作
        /// <summary>
        /// 获取缓存的所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<Inventories>> GetCache();

        /// <summary>
        /// 更新缓存 Cache
        /// </summary>
        /// <returns></returns>
        Task<List<Inventories>> UpdateCache();
        #endregion

        #region 重写根据条件查询分页数据
        /// <summary>
        /// 重写根据条件查询分页数据
        /// </summary>
        /// <param name="predicate">条件集合</param>
        /// <param name="orderByExpression">排序字段</param>
        /// <param name="orderByType">排序方式(ASC、DESC)</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <param name="blUserNoLock">是否使用 WITH(NOLOCK)</param>
        /// <returns></returns>
        new Task<IPageList<Inventories>> QueryPageAsync(
            Expression<Func<Inventories, bool>> predicate,
            Expression<Func<Inventories, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1,
            int pageSize = 20, bool blUserNoLock = false);
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
        Task<IPageList<GoodsInventoriesDto>> SqlQueryPageAsync(
            Expression<Func<GoodsInventoriesDto, bool>> predicate,
            Expression<Func<GoodsInventoriesDto, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 20, bool blUserNoLock = false);
        #endregion



    }
}
