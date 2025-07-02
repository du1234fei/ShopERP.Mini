
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     用户余额表
    /// </summary>
    public partial class CoreCmsUserBalance
    {
        /// <summary>
        ///     操作类型说明
        /// </summary>
        [Display(Name = "操作类型说明")]
        [SugarColumn(IsIgnore = true)]
        public string typeName { get; set; }

        /// <summary>
        ///     用户昵称
        /// </summary>
        [Display(Name = "用户昵称")]
        [SugarColumn(IsIgnore = true)]
        public string userNickName { get; set; }
    }
}