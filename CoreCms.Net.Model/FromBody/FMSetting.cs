

using System.Collections.Generic;
using CoreCms.Net.Model.ViewModels.Basics;

namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    ///     配置文件更新类
    /// </summary>
    public class FMCoreCmsSettingDoSaveModel
    {
        /// <summary>
        ///     列表
        /// </summary>
        public List<DictionaryKeyValues> entity { get; set; }
    }
}