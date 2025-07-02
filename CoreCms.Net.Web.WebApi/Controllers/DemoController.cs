
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Net.Web.WebApi.Controllers
{
    /// <summary>
    ///     默认接口示例
    /// </summary>
    public class DemoController : ControllerBase
    {
        /// <summary>
        ///     默认首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Content("已结束");
        }
    }
}