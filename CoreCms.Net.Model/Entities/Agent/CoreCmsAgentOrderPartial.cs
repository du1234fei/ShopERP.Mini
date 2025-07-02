using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 分销商订单记录表
    /// </summary>
    public partial class CoreCmsAgentOrder
    {

        /// <summary>
        /// 购买人昵称
        /// </summary>
        [Display(Name = "购买人昵称")]
        [SugarColumn(IsIgnore = true)]
        public System.String buyUserNickName { get; set; }

        /// <summary>
        /// 分销商
        /// </summary>
        [Display(Name = "分销商")]
        [SugarColumn(IsIgnore = true)]
        public System.String distributorName { get; set; }

    }
}
