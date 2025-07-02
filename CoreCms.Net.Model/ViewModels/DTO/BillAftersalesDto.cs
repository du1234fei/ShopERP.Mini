
using System.Collections.Generic;
using CoreCms.Net.Model.Entities;

namespace CoreCms.Net.Model.ViewModels.DTO
{
    /// <summary>
    ///     OrderToAftersales返回类
    /// </summary>
    public class OrderToAftersalesDto
    {
        public decimal refundMoney { get; set; } = 0;

        public Dictionary<int, reshipGoods> reshipGoods { get; set; } = null;

        public List<CoreCmsBillAftersales> billAftersales { get; set; } = new();
    }
}