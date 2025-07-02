using System.Collections.Generic;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 提货单表
    /// </summary>
    public partial class CoreCmsBillLading
    {

        /// <summary>
        /// 关联门店名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String storeName { get; set; }


        /// <summary>
        /// 状态中文描述
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String statusName { get; set; }



        /// <summary>
        /// 店员昵称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public System.String clerkIdName { get; set; }


        /// <summary>
        /// 关联订单项目
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<CoreCmsOrderItem> orderItems { get; set; }

    }
}
