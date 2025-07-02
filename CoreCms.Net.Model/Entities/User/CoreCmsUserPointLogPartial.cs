
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     用户积分
    /// </summary>
    public partial class CoreCmsUserPointLog
    {
        /// <summary>
        ///     类型说明
        /// </summary>
        [Display(Name = "类型说明")]
        [SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }
    }
}