using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplikacijaa.ContextFolder;
using Aplikacijaa.Helper;
using Aplikacijaa.Models;
using Aplikacijaa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aplikacijaa.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly MyContext db;

        public AdministratorController(MyContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdministrator() 
        {
            var administrator = new AdministratorVM() 
            {
                Citys = HelperClass.GetInstance(db).CityFiller(),
                AdministrastorRoleList=HelperClass.GetInstance(db).AdministratorRoleFiller()
        };
           
            return View(administrator);
        }
    }
}