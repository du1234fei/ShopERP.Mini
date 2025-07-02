using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 拼团商品表
    /// </summary>
    [SugarTable("CoreCmsPinTuanGoods",TableDescription = "拼团商品表")]
    public partial class CoreCmsPinTuanGoods
    {
        /// <summary>
        /// 拼团商品表
        /// </summary>
        public CoreCmsPinTuanGoods()
        {
        }

        /// <summary>
        /// 规则表序列
        /// </summary>
        [Display(Name = "规则表序列")]
        [SugarColumn(ColumnDescription = "规则表序列")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 ruleId { get; set; }
        /// <summary>
        /// 商品序列
        /// </summary>
        [Display(Name = "商品序列")]
        [SugarColumn(ColumnDescription = "商品序列")]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 goodsId { get; set; }
    }
}