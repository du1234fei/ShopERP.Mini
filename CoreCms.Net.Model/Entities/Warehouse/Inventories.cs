using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 库存表
    /// </summary>
    public partial class Inventories
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Inventories()
        {
        }

        /// <summary>
        /// 序列
        /// </summary>
        [Display(Name = "序列")]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 InvID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "仓库ID")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]
        public System.String WarehouseID { get; set; }


        /// <summary>
        /// SKU
        /// </summary>
        [Display(Name = "SKU")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]
        public System.String SKU { get; set; }


        /// <summary>
        /// 货架库存
        /// </summary>
        [Display(Name = "货架库存")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 Stocks { get; set; }


        /// <summary>
        /// 占用库存
        /// </summary>
        [Display(Name = "占用库存")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 QtyAllocation { get; set; }


        /// <summary>
        /// 可用库存
        /// </summary>
        [Display(Name = "可用库存")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 QtyRemain { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]

        [Required(ErrorMessage = "请输入{0}")]

        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]

        public System.String CreatedBy { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreatedOn { get; set; }


        /// <summary>
        /// 更新人
        /// </summary>
        [Display(Name = "更新人")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0}不能超过{1}字")]
        public System.String LastUpdatedBy { get; set; }


        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public DateTime? LastUpdatedOn { get; set; }

    }
}
