
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using session3_home.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace session3_home.Controllers
{
    
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }

       
    }
}
