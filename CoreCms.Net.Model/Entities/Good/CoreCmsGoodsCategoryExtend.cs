using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 商品分类扩展表
    /// </summary>
    [SugarTable("CoreCmsGoodsCategoryExtend",TableDescription = "商品分类扩展表")]
    public partial class CoreCmsGoodsCategoryExtend
    {
        /// <summary>
        /// 商品分类扩展表
        /// </summary>
        public CoreCmsGoodsCategoryExtend()
        {
        }

        /// <summary>
        /// 序列
        /// </summary>
        [Display(Name = "序列")]
        [SugarColumn(ColumnDescription = "序列", IsPrimaryKey = true, IsIdentity = true)]
        [Required(ErrorMessage = "请输入{0}")]
        public System.Int32 id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [Display(Name = "商品id")]
        [SugarColumn(ColumnDescription = "商品id", IsNullable = true)]
        public System.Int32? goodsId { get; set; }
        /// <summary>
        /// 商品分类id
        /// </summary>
        [Display(Name = "商品分类id")]
        [SugarColumn(ColumnDescription = "商品分类id", IsNullable = true)]
        public System.Int32? goodsCategroyId { get; set; }
    }
}