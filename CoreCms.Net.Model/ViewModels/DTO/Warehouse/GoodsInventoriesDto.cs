using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Model.ViewModels.DTO
{
    /// <summary>
    /// 产品与库存
    /// </summary>
    public class GoodsInventoriesDto
    {
        public int InvID { get; set; }

        public string WarehouseID { get; set; }

        public string SKU { get; set; }

        public int Stocks { get; set; }

        public int QtyAllocation { get; set; }

        public int QtyRemain { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public string GoodsName { get; set; }

        public string GoodsImage { get; set; }

    }
}
