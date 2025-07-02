using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Model.ViewModels.Excel
{
    /// <summary>
    /// 导出excel头字段名称信息
    /// </summary>
    public class CellValueItem
    {
        public string name { get; set; }
        public int width { get; set; } = 10 * 256;


    }
}
