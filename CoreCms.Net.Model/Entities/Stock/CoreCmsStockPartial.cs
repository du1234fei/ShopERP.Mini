
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     库存操作表
    /// </summary>
    public partial class CoreCmsStock
    {
        /// <summary>
        ///     操作员昵称
        /// </summary>
        [Display(Name = "操作员昵称")]
        [SugarColumn(IsIgnore = true)]
        public string managerName { get; set; }
    }
}