
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     商品分类
    /// </summary>
    public partial class CoreCmsGoodsGrade
    {
        /// <summary>
        ///     名称
        /// </summary>
        [Display(Name = "名称")]
        [SugarColumn(IsIgnore = true)]
        public string gradeName { get; set; }
    }
}