using Marzlam2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Marzlam2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      

        private readonly IOptionsMonitor<configclass> _optionsMonitor;

        public HomeController(ILogger<HomeController> logger, IOptionsMonitor<configclass> optionsMonitor)
        {
            _logger = logger;
            _optionsMonitor = optionsMonitor;

        }

        public IActionResult Index()
        {
            //configclass aaa= new configclass();
            var s = "appsettings.json";
            _optionsMonitor.OnChange((configclass, s) =>
            {
                var a = configclass.Audience;
            });

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
