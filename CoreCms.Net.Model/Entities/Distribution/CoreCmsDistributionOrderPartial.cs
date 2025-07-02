
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     分销商订单记录表
    /// </summary>
    public partial class CoreCmsDistributionOrder
    {
        /// <summary>
        ///     购买人昵称
        /// </summary>
        [Display(Name = "购买人昵称")]
        [SugarColumn(IsIgnore = true)]
        public string buyUserNickName { get; set; }

        /// <summary>
        ///     分销商
        /// </summary>
        [Display(Name = "分销商")]
        [SugarColumn(IsIgnore = true)]
        public string distributorName { get; set; }
    }
}