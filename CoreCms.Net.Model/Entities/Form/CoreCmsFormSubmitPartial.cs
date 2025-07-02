
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     用户对表的提交记录
    /// </summary>
    public partial class CoreCmsFormSubmit
    {
        /// <summary>
        ///     用户昵称
        /// </summary>
        [Display(Name = "微信昵称")]
        [SugarColumn(IsIgnore = true)]
        public string userName { get; set; }

        /// <summary>
        ///     用户头像
        /// </summary>
        [Display(Name = "用户头像")]
        [SugarColumn(IsIgnore = true)]
        public string avatarImage { get; set; }
    }
}