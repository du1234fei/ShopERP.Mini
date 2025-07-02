
using System.Collections.Generic;
using SqlSugar;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    ///     商品类型属性表
    /// </summary>
    public partial class CoreCmsGoodsTypeSpec
    {
        /// <summary>
        ///     子类
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<CoreCmsGoodsTypeSpecValue> specValues { get; set; } = new();
    }
}