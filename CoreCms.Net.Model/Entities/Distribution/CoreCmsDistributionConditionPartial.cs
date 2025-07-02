
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     分销商等级升级条件
    /// </summary>
    public partial class CoreCmsDistributionCondition
    {
        /// <summary>
        ///     Code转码
        /// </summary>
        [Display(Name = "Code转码")]
        [SugarColumn(IsIgnore = true)]
        public string name { get; set; }
    }
}