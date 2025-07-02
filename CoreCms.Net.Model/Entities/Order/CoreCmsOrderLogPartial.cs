
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     订单记录表
    /// </summary>
    public partial class CoreCmsOrderLog
    {
        /// <summary>
        ///     类型说明
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string typeText { get; set; }
    }
}