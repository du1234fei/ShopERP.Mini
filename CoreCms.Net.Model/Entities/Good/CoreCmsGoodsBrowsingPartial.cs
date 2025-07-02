
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     商品浏览记录
    /// </summary>
    public partial class CoreCmsGoodsBrowsing
    {
        /// <summary>
        ///     商品图片
        /// </summary>
        [Display(Name = "商品图片")]
        [SugarColumn(IsIgnore = true)]
        public string goodImage { get; set; }


        /// <summary>
        ///     是否收藏
        /// </summary>
        [Display(Name = "是否收藏")]
        [SugarColumn(IsIgnore = true)]
        public bool isCollection { get; set; }
    }
}