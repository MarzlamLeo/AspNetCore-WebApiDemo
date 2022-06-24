using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Marzlam3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        public  ITest _test { get; set; }
        public HomeController(ITest test)
        {
            _test = test;
            
        }

        public String Twww()
        {
            return _test.testautofac("123");
        }
       

    }
}
