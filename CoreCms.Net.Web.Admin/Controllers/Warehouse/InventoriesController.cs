
using CoreCms.Net.Configuration;
using CoreCms.Net.IServices.Warehouse;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.Entities.Expression;
using CoreCms.Net.Model.FromBody;
using CoreCms.Net.Model.ViewModels.DTO;
using CoreCms.Net.Model.ViewModels.Echarts;
using CoreCms.Net.Model.ViewModels.UI;
using CoreCms.Net.Utility.Helper;
using CoreCms.Net.Web.Admin.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using SqlSugar;
using SqlSugar.Extensions;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreCms.Net.Web.Admin.Controllers
{
    /// <summary>
    /// 库存控制器
    /// </summary>
    [Description("库存表")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [RequiredErrorForAdmin]
    //[Authorize(Permissions.Name)]
    public class InventoriesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IinventoriesServices _inventoriesServices;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="webHostEnvironmnet"></param>
        /// <param name="inventoriesServices"></param>
        public InventoriesController(IWebHostEnvironment webHostEnvironmnet, IinventoriesServices inventoriesServices)
        {
            _webHostEnvironment = webHostEnvironmnet;
            _inventoriesServices = inventoriesServices;
        }

        #region 分页获取列表数据
        /// <summary>
        /// 分页获取列表数据
        /// POST: Api/Inventories/GetPageList
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取列表数据")]
        public async Task<AdminUiCallBack> GetPageList()
        {
            var jm = new AdminUiCallBack();

            //当前页码，每页大小
            int pageCurrent = Request.Form["page"].FirstOrDefault().ObjToInt(1);
            int pageSize = Request.Form["limit"].FirstOrDefault().ObjToInt(30);

            //查询条件
            var where = PredicateBuilder.True<GoodsInventoriesDto>();

            Expression<Func<GoodsInventoriesDto, object>> orderEx = null;
            OrderByType orderBy = OrderByType.Asc;

            //获取排序字段
            string orderField = Request.Form["orderFiled"].FirstOrDefault();
            if (!string.IsNullOrEmpty(orderField))
            {
                orderEx = orderField switch
                {
                    "InvID" => (p => p.InvID),
                    "WarehouseID" => p => p.WarehouseID,
                    _ => p => p.WarehouseID,
                };
            }

            //设置排序方式
            string orderDirection = Request.Form["orderDirection"].FirstOrDefault();
            if (!string.IsNullOrEmpty(orderDirection))
            {
                orderBy = orderDirection switch
                {
                    "asc" => OrderByType.Asc,
                    "desc" => OrderByType.Desc,
                    _ => OrderByType.Desc
                };
            }

            //查询筛选
            var WarehouseID = Request.Form["WarehouseID"].FirstOrDefault();

            //仓库
            if (!string.IsNullOrEmpty(WarehouseID))
            {
                where = where.And(p => p.WarehouseID.Contains(WarehouseID.Trim()));
            }

            //SKU
            var SKU = Request.Form["SKU"].FirstOrDefault();
            if (!string.IsNullOrEmpty(SKU))
            {
                where = where.And(p => p.SKU.Contains(SKU));
            }

            var list = await _inventoriesServices.SqlQueryPageAsync(where, orderEx, orderBy, pageCurrent, pageSize, true);

            //返回数据
            jm.data = list;
            jm.code = 0;
            jm.count = list.Count;
            jm.msg = "数据调用成功！";
            return jm;
        }
        #endregion

        #region 首页数据
        /// <summary>
        /// 首页数据
        /// POST: Api/Inventories/GetIndex
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("首页数据")]
        public AdminUiCallBack GetIndex()
        {
            //返回数据
            var jm = new AdminUiCallBack { code = 0 };
            return jm;
        }
        #endregion

        #region 创建数据
        /// <summary>
        /// POST: Api/inventories/GetCreate
        /// 创建数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("创建数据")]
        public AdminUiCallBack GetCreate()
        {
            //返回数据
            var jm = new AdminUiCallBack { code = 0 };
            return jm;
        }
        #endregion

        #region 创建提交
        /// <summary>
        /// POST: Api/inventories/DoCreate
        /// 创建提交
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<AdminUiCallBack> DoCreate([FromBody] Inventories entity)
        {
            var jm = await _inventoriesServices.InsertAsync(entity);
            return jm;
        }
        #endregion

        #region 编辑数据
        /// <summary>
        /// POST: Api/inventories/GetEidt
        /// 编辑数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("编辑数据")]
        public async Task<AdminUiCallBack> GetEdit([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _inventoriesServices.QueryByIdAsync(entity.id, false);
            if (model == null)
            {
                jm.msg = "不存在此信息";
                return jm;
            }

            jm.code = 0;
            jm.data = model;
            return jm;
        }
        #endregion

        #region 编辑提交
        /// <summary>
        /// POST: Api/Inventories/Edit
        /// 编辑提交
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("编辑提交")]
        public async Task<AdminUiCallBack> DoEdit([FromBody] Inventories entity)
        {
            var jm = await _inventoriesServices.UpdateAsync(entity);
            return jm;
        }
        #endregion

        #region 单选删除数据
        /// <summary>
        /// POST: Api/inventories/DoDelete/10
        /// 单选删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("单选删除数据")]
        public async Task<AdminUiCallBack> DoDelete([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _inventoriesServices.ExistsAsync(p => p.InvID == entity.id, true);
            if (!model)
            {
                //如果不存在
                jm.msg = GlobalConstVars.DataisNo;
                return jm;
            }
            jm = await _inventoriesServices.DeleteByIdAsync(entity.id);
            return jm;
        }
        #endregion

        #region 批量删除
        /// <summary>
        /// POST： Api/inventories/DoBatchDelete/10,11,20
        /// 批量删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("批量删除")]
        public async Task<AdminUiCallBack> DoBatchDelete([FromBody] FMArrayIntIds entity)
        {
            var jm = await _inventoriesServices.DeleteByIdsAsync(entity.id);
            return jm;
        }
        #endregion

        #region 预览数据
        /// <summary>
        /// POST: Api/inventories/GetDetails/10
        /// 预览数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("预览数据")]
        public async Task<AdminUiCallBack> GetDetails([FromBody] FMIntId entity)
        {
            var jm = new AdminUiCallBack();

            var model = await _inventoriesServices.QueryByIdAsync(entity.id);
            if (model == null)
            {
                jm.msg = "不存在此信息";
                return jm;
            }
            jm.code = 0;
            jm.data = model;

            return jm;
        }
        #endregion

        #region 选择导出
        /// <summary>
        /// POST: Api/inventories/SelectExpotExcel/10
        /// 选择导出
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("选择导出")]
        public async Task<AdminUiCallBack> SelectExportExcel([FromBody] FMArrayIntIds entity)
        {
            var jm = new AdminUiCallBack();

            //创建 Excel 文件的对象
            var book = new HSSFWorkbook();
            //添加一个 sheet
            var mySheet = book.CreateSheet("Sheet1");

            //获取 list 数据
            var listModel = await _inventoriesServices.QueryListByClauseAsync(p => entity.id.Contains(p.InvID), p => p.InvID, OrderByType.Asc, true);
            //给 sheet1 添加第一行的头部标题
            var headerRow = mySheet.CreateRow(0);
            var headerStyle = ExcelHelper.GetHeaderStyle(book);

            #region Excel 列表头
            //Excel 列表头
            var cell0 = headerRow.CreateCell(0);
            cell0.SetCellValue("序列");
            cell0.CellStyle = headerStyle;
            mySheet.SetColumnWidth(0, 10 * 256);

            var cell1 = headerRow.CreateCell(1);
            cell1.SetCellValue("仓库");
            cell1.CellStyle = headerStyle;
            mySheet.SetColumnWidth(1, 10 * 256);

            var cell2 = headerRow.CreateCell(2);
            cell2.SetCellValue("SKU");
            cell2.CellStyle = headerStyle;
            mySheet.SetColumnWidth(2, 10 * 256);

            var cell3 = headerRow.CreateCell(3);
            cell3.SetCellValue("货架库存");
            cell3.CellStyle = headerStyle;
            mySheet.SetColumnWidth(3, 10 * 256);

            var cell4 = headerRow.CreateCell(4);
            cell4.SetCellValue("占用库存");
            cell4.CellStyle = headerStyle;
            mySheet.SetColumnWidth(4, 10 * 256);

            var cell5 = headerRow.CreateCell(5);
            cell5.SetCellValue("可用库存");
            cell5.CellStyle = headerStyle;
            mySheet.SetColumnWidth(5, 10 * 256);

            var cell6 = headerRow.CreateCell(6);
            cell6.SetCellValue("更新人");
            cell6.CellStyle = headerStyle;
            mySheet.SetColumnWidth(6, 10 * 256);

            var cell7 = headerRow.CreateCell(7);
            cell7.SetCellValue("更新时间");
            cell7.CellStyle = headerStyle;
            mySheet.SetColumnWidth(6, 12 * 256);
            #endregion

            headerRow.Height = 30 * 20;
            var commonCellStyle = ExcelHelper.GetCommonStyle(book);

            //将数据逐步写入 sheet1 各个行
            for (var i = 0; i < listModel.Count; i++)
            {
                var rowTemp = mySheet.CreateRow(i + 1);

                //创建第一列
                var rowTemp0 = rowTemp.CreateCell(0);
                rowTemp0.SetCellValue(listModel[i].InvID);
                rowTemp0.CellStyle = commonCellStyle;

                //创建列
                var rowTemp1 = rowTemp.CreateCell(1);
                rowTemp1.SetCellValue(listModel[i].WarehouseID);
                rowTemp1.CellStyle = commonCellStyle;

                //创建列
                var rowTemp2 = rowTemp.CreateCell(2);
                rowTemp2.SetCellValue(listModel[i].SKU);
                rowTemp2.CellStyle = commonCellStyle;

                //创建列 (货架库存)
                var rowTemp3 = rowTemp.CreateCell(3);
                rowTemp3.SetCellValue(listModel[i].Stocks);
                rowTemp3.CellStyle = commonCellStyle;

                //创建列 (占用库存)
                var rowTemp4 = rowTemp.CreateCell(4);
                rowTemp4.SetCellValue(listModel[i].QtyAllocation);
                rowTemp4.CellStyle = commonCellStyle;

                //创建列 (可用库存)
                var rowTemp5 = rowTemp.CreateCell(5);
                rowTemp5.SetCellValue(listModel[i].QtyRemain);
                rowTemp5.CellStyle = commonCellStyle;

                //创建列 (更新人)
                var rowTemp6 = rowTemp.CreateCell(6);
                rowTemp6.SetCellValue(listModel[i].LastUpdatedBy);
                rowTemp6.CellStyle = commonCellStyle;

                //创建列 (更新时间)
                var rowTemp7 = rowTemp.CreateCell(7);
                rowTemp7.SetCellValue(listModel[i].LastUpdatedOn.ToString());
                rowTemp7.CellStyle = commonCellStyle;
            }

            //导出 Excel
            string webRootPath = _webHostEnvironment.WebRootPath;
            string tPath = "/files/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-货架库存导出 (选择结果).xls";
            string filePath = webRootPath + tPath;

            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }

            FileStream fileHssf = new FileStream(filePath + fileName, FileMode.Create);
            book.Write(fileHssf);
            fileHssf.Close();

            jm.code = 0;
            jm.msg = GlobalConstVars.ExcelExportSuccess;
            jm.data = tPath + fileName;

            return jm;
        }
        #endregion

        #region 查询导出
        /// <summary>
        /// POST: Api/inventories/QueryExportExcel/10
        /// 查询导出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("查询导出")]
        public async Task<AdminUiCallBack> QueryExportExcel()
        {
            var jm = new AdminUiCallBack();

            var where = PredicateBuilder.True<Inventories>();

            //仓库
            var WarehouseID = Request.Form["WarehouseID"].FirstOrDefault();
            if (!string.IsNullOrEmpty(WarehouseID))
            {
                where = where.And(p => p.WarehouseID.Contains(WarehouseID.Trim()));
            }

            //SKU
            var SKU = Request.Form["SKU"].FirstOrDefault();
            if (!string.IsNullOrEmpty(SKU))
            {
                where = where.And(p => p.SKU.Contains(SKU));
            }

            //获取数据
            //创建 Excel 文件的对象
            var book = new HSSFWorkbook();
            //添加一个 sheet
            var mySheet = book.CreateSheet("Sheet1");

            //获取 list 数据
            var listModel = await _inventoriesServices.QueryListByClauseAsync(where, p => p.InvID, OrderByType.Asc, true);

            //给 sheet1 添加第一行的头部标题
            var headerRow = mySheet.CreateRow(0);
            var headerStyle = ExcelHelper.GetHeaderStyle(book);

            #region Excel 列表头
            //Excel 列表头
            var cell0 = headerRow.CreateCell(0);
            cell0.SetCellValue("序列");
            cell0.CellStyle = headerStyle;
            mySheet.SetColumnWidth(0, 10 * 256);

            var cell1 = headerRow.CreateCell(1);
            cell1.SetCellValue("仓库");
            cell1.CellStyle = headerStyle;
            mySheet.SetColumnWidth(1, 10 * 256);

            var cell2 = headerRow.CreateCell(2);
            cell2.SetCellValue("SKU");
            cell2.CellStyle = headerStyle;
            mySheet.SetColumnWidth(2, 10 * 256);

            var cell3 = headerRow.CreateCell(3);
            cell3.SetCellValue("货架库存");
            cell3.CellStyle = headerStyle;
            mySheet.SetColumnWidth(3, 10 * 256);

            var cell4 = headerRow.CreateCell(4);
            cell4.SetCellValue("占用库存");
            cell4.CellStyle = headerStyle;
            mySheet.SetColumnWidth(4, 10 * 256);

            var cell5 = headerRow.CreateCell(5);
            cell5.SetCellValue("可用库存");
            cell5.CellStyle = headerStyle;
            mySheet.SetColumnWidth(5, 10 * 256);

            var cell6 = headerRow.CreateCell(6);
            cell6.SetCellValue("更新人");
            cell6.CellStyle = headerStyle;
            mySheet.SetColumnWidth(6, 10 * 256);

            var cell7 = headerRow.CreateCell(7);
            cell7.SetCellValue("更新时间");
            cell7.CellStyle = headerStyle;
            mySheet.SetColumnWidth(6, 12 * 256);
            #endregion

            //设置列表头的行高
            headerRow.Height = 30 * 20;
            var commonCellStyle = ExcelHelper.GetCommonStyle(book);

            //将数据逐步写入 sheet1 各个行
            for (var i = 0; i < listModel.Count; i++)
            {
                var rowTemp = mySheet.CreateRow(i + 1);

                //创建第一列
                var rowTemp0 = rowTemp.CreateCell(0);
                rowTemp0.SetCellValue(listModel[i].InvID);
                rowTemp0.CellStyle = commonCellStyle;

                //创建列
                var rowTemp1 = rowTemp.CreateCell(1);
                rowTemp1.SetCellValue(listModel[i].WarehouseID);
                rowTemp1.CellStyle = commonCellStyle;

                //创建列
                var rowTemp2 = rowTemp.CreateCell(2);
                rowTemp2.SetCellValue(listModel[i].SKU);
                rowTemp2.CellStyle = commonCellStyle;

                //创建列 (货架库存)
                var rowTemp3 = rowTemp.CreateCell(3);
                rowTemp3.SetCellValue(listModel[i].Stocks);
                rowTemp3.CellStyle = commonCellStyle;

                //创建列 (占用库存)
                var rowTemp4 = rowTemp.CreateCell(4);
                rowTemp4.SetCellValue(listModel[i].QtyAllocation);
                rowTemp4.CellStyle = commonCellStyle;

                //创建列 (可用库存)
                var rowTemp5 = rowTemp.CreateCell(5);
                rowTemp5.SetCellValue(listModel[i].QtyRemain);
                rowTemp5.CellStyle = commonCellStyle;

                //创建列 (更新人)
                var rowTemp6 = rowTemp.CreateCell(6);
                rowTemp6.SetCellValue(listModel[i].LastUpdatedBy);
                rowTemp6.CellStyle = commonCellStyle;

                //创建列 (更新时间)
                var rowTemp7 = rowTemp.CreateCell(7);
                rowTemp7.SetCellValue(listModel[i].LastUpdatedOn.ToString());
                rowTemp7.CellStyle = commonCellStyle;
            }

            //写入到 Excel
            string webRootPath = _webHostEnvironment.WebRootPath;
            string tPath = "/files/"+DateTime.Now.ToString("yyyy-MM-dd")+"/";
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff")+"-inventories 导出 (查询结果).xls";
            string filePath = webRootPath + tPath;

            DirectoryInfo di = new DirectoryInfo(filePath);
            if (!di.Exists)
            {
                di.Create();
            }

            FileStream fileHssf = new FileStream(filePath+fileName,FileMode.Create);
            book.Write(fileHssf);
            fileHssf.Close();

            jm.code = 0;
            jm.msg = GlobalConstVars.ExcelExportSuccess;
            jm.data = tPath + fileName;
            return jm;
        }
        #endregion


    }
}
