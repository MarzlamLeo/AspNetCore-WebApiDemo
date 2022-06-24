using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marzlam1.Controllers
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
    }
}
