using CoreCms.Net.Caching.Manual;
using CoreCms.Net.Configuration;
using CoreCms.Net.IRepository;
using CoreCms.Net.IRepository.UnitOfWork;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.Basics;
using CoreCms.Net.Model.ViewModels.DTO;
using CoreCms.Net.Model.ViewModels.UI;
using NPOI.OpenXmlFormats.Wordprocessing;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Repository
{
    /// <summary>
    /// 库存表 接口实现
    /// </summary>
    public class InventoriesRepository : BaseRepository<Inventories>, IinventoriesRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoriesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region 实现重新增删改查操作
        /// <summary>
        /// 重写异步插入方法
        /// </summary>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        public new async Task<AdminUiCallBack> InsertAsync(Inventories entity)
        {
            var jm = new AdminUiCallBack();

            var b1 = await DbClient.Insertable(entity).ExecuteReturnIdentityAsync() > 0;
            jm.code = b1 ? 0 : 1;
            jm.msg = b1 ? GlobalConstVars.CreateSuccess : GlobalConstVars.CreateFailure;

            if (b1)
            {
                //如果数据库插入成功，要更新缓存。
                await UpdateCache();
            }
            return jm;
        }

        /// <summary>
        /// 重写异步的更新方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new async Task<AdminUiCallBack> UpdateAsync(Inventories entity)
        {
            var jm = new AdminUiCallBack();

            //根据 id 查询查询
            var oldModel = await DbClient.Queryable<Inventories>().In(entity.InvID).SingleAsync();
            if (oldModel == null)
            {
                jm.msg = "不存在此信息";
                return jm;
            }

            //事务处理开始
            oldModel.InvID = entity.InvID;
            oldModel.WarehouseID = entity.WarehouseID;
            oldModel.SKU = entity.SKU;
            oldModel.Stocks = entity.Stocks;
            oldModel.QtyAllocation = entity.QtyAllocation;
            oldModel.QtyRemain = entity.QtyRemain;
            oldModel.CreatedBy = entity.CreatedBy;
            oldModel.CreatedOn = entity.CreatedOn;
            oldModel.LastUpdatedBy = entity.LastUpdatedBy;
            oldModel.LastUpdatedOn = entity.LastUpdatedOn;

            //事务处理过程结束
            var bl = await DbClient.Updateable(oldModel).ExecuteCommandHasChangeAsync();
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.EditSuccess : GlobalConstVars.EditFailure;
            if (bl)
            {
                //更新缓存
                await UpdateCache();
            }

            return jm;
        }

        /// <summary>
        /// 重写异步更新方法 (批量更新)
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public new async Task<AdminUiCallBack> UpdateAsync(List<Inventories> entityList)
        {
            var jm = new AdminUiCallBack();

            var bl = await DbClient.Updateable(entityList).ExecuteCommandHasChangeAsync();
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.EditSuccess : GlobalConstVars.EditFailure;
            if (bl)
            {
                await UpdateCache();
            }

            return jm;
        }

        /// <summary>
        /// 重写删除指定 ID 的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new async Task<AdminUiCallBack> DeleteByIdAsync(object id)
        {
            var jm = new AdminUiCallBack();

            var bl = await DbClient.Deleteable<Inventories>(id).ExecuteCommandHasChangeAsync();
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;
            if (bl)
            {
                await UpdateCache();
            }

            return jm;
        }

        /// <summary>
        /// 重写删除指定 ID 集合的数据 (批量删除)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public new async Task<AdminUiCallBack> DeleteByIdsAsync(int[] ids)
        {
            var jm = new AdminUiCallBack();

            var bl = await DbClient.Deleteable<Inventories>().In(ids).ExecuteCommandHasChangeAsync();
            jm.code = bl ? 0 : 1;
            jm.msg = bl ? GlobalConstVars.DeleteSuccess : GlobalConstVars.DeleteFailure;
            if (bl)
            {
                await UpdateCache();
            }
            return jm;
        }
        #endregion

        #region 操作 Cache 缓存相关的操作
        /// <summary>
        /// 获取缓存的所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<Inventories>> GetCache()
        {
            var cache = ManualDataCache.Instance.Get<List<Inventories>>(GlobalConstVars.CacheInventories);
            if (cache != null)
            {
                return cache;
            }
            return await UpdateCache();
        }

        /// <summary>
        /// 更新 Cache 缓存
        /// </summary>
        /// <returns></returns>
        public async Task<List<Inventories>> UpdateCache()
        {
            var list = await DbClient.Queryable<Inventories>().With(SqlWith.NoLock).ToListAsync();
            ManualDataCache.Instance.Set(GlobalConstVars.CacheInventories, list);
            return list;
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
        /// <param name="blUserNoLock"></param>
        /// <returns></returns>
        public new async Task<IPageList<Inventories>> QueryPageAsync(Expression<Func<Inventories, bool>> predicate,
            Expression<Func<Inventories, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1,
            int pageSize = 20, bool blUserNoLock = false)
        {
            RefAsync<int> totalCount = 0;
            List<Inventories> page;

            if (blUserNoLock)
            {
                //如果使用脏读数据
                page = await DbClient.Queryable<Inventories>()
                     .OrderByIF(orderByExpression != null, orderByExpression, orderByType)
                     .WhereIF(predicate != null, predicate).Select(p => new Inventories
                     {
                         InvID = p.InvID,
                         WarehouseID = p.WarehouseID,
                         SKU = p.SKU,
                         Stocks = p.Stocks,
                         QtyAllocation = p.QtyAllocation,
                         QtyRemain = p.QtyRemain,
                         CreatedBy = p.CreatedBy,
                         CreatedOn = p.CreatedOn,
                         LastUpdatedBy = p.LastUpdatedBy,
                         LastUpdatedOn = p.LastUpdatedOn

                     }).With(SqlWith.NoLock).ToPageListAsync(pageIndex, pageSize, totalCount);
            }
            else
            {
                page = await DbClient.Queryable<Inventories>()
                    .OrderByIF(orderByExpression != null, orderByExpression, orderByType)
                    .WhereIF(predicate != null, predicate).Select(p => new Inventories
                    {
                        InvID = p.InvID,
                        WarehouseID = p.WarehouseID,
                        SKU = p.SKU,
                        Stocks = p.Stocks,
                        QtyAllocation = p.QtyAllocation,
                        QtyRemain = p.QtyRemain,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        LastUpdatedBy = p.LastUpdatedBy,
                        LastUpdatedOn = p.LastUpdatedOn

                    }).ToPageListAsync(pageIndex, pageSize, totalCount);
            }

            var list = new PageList<Inventories>(page, pageIndex, pageSize, totalCount);
            return list;
        }
        #endregion

        #region 通过原生 Sql 查询分页数据
        /// <summary>
        /// 通过原生 Sql 查询分页数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="orderByType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="blUserNoLock"></param>
        /// <returns></returns>
        public async Task<IPageList<GoodsInventoriesDto>> SqlQueryPageAsync(Expression<Func<GoodsInventoriesDto, bool>> predicate,
            Expression<Func<GoodsInventoriesDto, object>> orderByExpression, OrderByType orderByType, int pageIndex = 1, int pageSize = 20, bool blUserNoLock = false)
        {
            RefAsync<int> totalCount = 0;
            List<GoodsInventoriesDto> page;

            string strSql = @" SELECT it.*,gd.`name` AS GoodsName,gd.image AS GoodsImage
                               FROM inventories it
                               INNER JOIN corecmsgoods gd ON it.SKU=gd.bn ";

            if (blUserNoLock)
            {
                //如果使用脏读
                page = await DbClient.SqlQueryable<GoodsInventoriesDto>(strSql)
                    .OrderByIF(orderByExpression != null, orderByExpression, orderByType)
                    .WhereIF(predicate != null, predicate).Select(p => new GoodsInventoriesDto
                    {
                        InvID = p.InvID,
                        WarehouseID = p.WarehouseID,
                        SKU = p.SKU,
                        GoodsName = p.GoodsName,
                        GoodsImage = p.GoodsImage,
                        Stocks = p.Stocks,
                        QtyAllocation = p.QtyAllocation,
                        QtyRemain = p.QtyRemain,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        LastUpdatedBy = p.LastUpdatedBy,
                        LastUpdatedOn = p.LastUpdatedOn

                    }).With(SqlWith.NoLock).ToPageListAsync(pageIndex, pageSize, totalCount);
            }
            else
            {
                page = await DbClient.SqlQueryable<GoodsInventoriesDto>(strSql)
                    .OrderByIF(orderByExpression != null, orderByExpression, orderByType)
                    .WhereIF(predicate != null, predicate).Select(p => new GoodsInventoriesDto
                    {
                        InvID = p.InvID,
                        WarehouseID = p.WarehouseID,
                        SKU = p.SKU,
                        GoodsName = p.GoodsName,
                        GoodsImage = p.GoodsImage,
                        Stocks = p.Stocks,
                        QtyAllocation = p.QtyAllocation,
                        QtyRemain = p.QtyRemain,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        LastUpdatedBy = p.LastUpdatedBy,
                        LastUpdatedOn = p.LastUpdatedOn

                    }).ToPageListAsync(pageIndex, pageSize, totalCount);
            }

            var list = new PageList<GoodsInventoriesDto>(page, pageIndex, pageSize, totalCount);
            return list;
        }
        #endregion


    }
}
