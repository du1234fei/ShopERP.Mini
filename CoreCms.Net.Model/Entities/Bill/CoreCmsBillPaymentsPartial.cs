using System.Collections.Generic;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 支付单表
    /// </summary>
    public partial class CoreCmsBillPayments
    {

        /// <summary>
        /// 支付代码描述
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String paymentCodeName { get; set; }

        /// <summary>
        /// 状态中文描述
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String statusName { get; set; }


        /// <summary>
        /// 支付标题
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String payTitle { get; set; }


        /// <summary>
        /// 用户昵称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String userNickName { get; set; }

    }
}
