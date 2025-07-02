
using System.Collections.Generic;

namespace CoreCms.Net.Model.FromBody
{
    public class FMSysMenuToImportButtonData
    {
        public int menuId { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string description { get; set; }
    }


    public class FMSysMenuToImportButton
    {
        public List<FMSysMenuToImportButtonData> data { get; set; }
    }
}