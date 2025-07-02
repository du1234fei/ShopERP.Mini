
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     用户表
    /// </summary>
    public partial class CoreCmsUser
    {
        /// <summary>
        ///     来源类型
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int type { get; set; }

        /// <summary>
        ///     下级用户数量
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int childNum { get; set; }

        /// <summary>
        ///     父级名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string parentNickName { get; set; }
    }
}