
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     服务项目表
    /// </summary>
    public partial class CoreCmsServices
    {
        /// <summary>
        ///     倒计时时间戳
        /// </summary>
        [Display(Name = "倒计时时间戳")]
        [SugarColumn(IsIgnore = true)]
        public int timestamp { get; set; } = 0;

        /// <summary>
        ///     允许购买用户等级
        /// </summary>
        [Display(Name = "允许购买用户等级")]
        [SugarColumn(IsIgnore = true)]
        public List<string> allowedMemberships { get; set; }

        /// <summary>
        ///     核销门店
        /// </summary>
        [Display(Name = "核销门店")]
        [SugarColumn(IsIgnore = true)]
        public List<string> consumableStores { get; set; }
    }
}