using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplikacijaa.Models;
using Aplikacijaa.ContextFolder;

namespace Aplikacijaa.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext db;

        public HomeController(MyContext context) => db = context;
        public IActionResult Index()
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
