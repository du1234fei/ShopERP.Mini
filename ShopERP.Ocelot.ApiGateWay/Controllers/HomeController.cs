using Microsoft.AspNetCore.Mvc;
using ShopERP.Ocelot.ApiGateWay.Infrastructure;
using ShopERP.Ocelot.ApiGateWay.Models;
using System.Diagnostics;

namespace ShopERP.Ocelot.ApiGateWay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConsulServiceDiscover _consulServerDiscover;

        public HomeController(ILogger<HomeController> logger,ConsulServiceDiscover consulServiceDiscover)
        {
            _logger = logger;
            _consulServerDiscover = consulServiceDiscover;
        }

        public IActionResult Index()
        {
            //��ȡ api �����ַ
            var domain = _consulServerDiscover.GetApiDomin();
            ViewBag.domain = domain;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
