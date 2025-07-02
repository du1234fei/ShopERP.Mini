
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     表单
    /// </summary>
    public partial class CoreCmsForm
    {
        /// <summary>
        ///     表单字段
        /// </summary>
        [Display(Name = "表单字段")]
        [SugarColumn(IsIgnore = true)]
        public List<CoreCmsFormItem> Items { get; set; }
    }
}