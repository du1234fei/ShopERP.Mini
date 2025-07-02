

using System.Collections.Generic;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Model.FromBody
{
    public class FMCreateStock
    {
        /// <summary>
        ///     广告位置
        /// </summary>
        public CoreCmsStock model { get; set; }


        public List<FMCreateStockItem> items { get; set; }
    }

    public class FMCreateStockItem
    {
        public int nums { get; set; }
        public int productId { get; set; }
    }
}