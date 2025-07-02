
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     服务消费券
    /// </summary>
    public partial class CoreCmsUserServicesTicket
    {
        /// <summary>
        ///     状态说明
        /// </summary>
        [Display(Name = "状态说明")]
        [SugarColumn(IsIgnore = true)]
        public string statusStr { get; set; }
    }
}