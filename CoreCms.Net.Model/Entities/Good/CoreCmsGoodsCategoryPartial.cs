
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     商品分类
    /// </summary>
    public partial class CoreCmsGoodsCategory
    {
        /// <summary>
        ///     类别名称
        /// </summary>
        [Display(Name = "类别名称")]
        [SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }
    }
}