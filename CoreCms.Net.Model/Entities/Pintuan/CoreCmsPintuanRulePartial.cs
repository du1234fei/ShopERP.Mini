
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     拼团规则表
    /// </summary>
    public partial class CoreCmsPinTuanRule
    {
        /// <summary>
        ///     商品编码
        /// </summary>
        [Display(Name = "商品编码")]
        [SugarColumn(IsIgnore = true)]
        public int[] goods { get; set; }


        /// <summary>
        ///     判断拼团状态
        /// </summary>
        [Display(Name = "状态")]
        [SugarColumn(IsIgnore = true)]
        public int pinTuanStartStatus { get; set; } = 0;


        /// <summary>
        ///     剩余时间
        /// </summary>
        [Display(Name = "剩余时间")]
        [SugarColumn(IsIgnore = true)]
        public int lastTime { get; set; }
    }
}