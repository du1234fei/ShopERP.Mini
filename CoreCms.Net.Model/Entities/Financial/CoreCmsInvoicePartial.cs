
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     发票表格
    /// </summary>
    public partial class CoreCmsInvoice
    {
        /// <summary>
        ///     分类名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string categoryName { get; set; }


        /// <summary>
        ///     类型名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }

        /// <summary>
        ///     状态名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string statusName { get; set; }


        /// <summary>
        ///     用户昵称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string userNickName { get; set; }
    }
}