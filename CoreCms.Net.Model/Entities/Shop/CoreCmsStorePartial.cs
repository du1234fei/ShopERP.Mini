
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     门店表
    /// </summary>
    public partial class CoreCmsStore
    {
        /// <summary>
        ///     全名详细地址
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string allAddress { get; set; }


        /// <summary>
        ///     距离说明
        /// </summary>
        [Display(Name = "距离说明")]
        [SugarColumn(IsIgnore = true)]
        public string distanceStr { get; set; }
    }
}