using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplikacijaa.ContextFolder;
using Aplikacijaa.Helper;
using Aplikacijaa.Models;
using Aplikacijaa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var administrator = new AdministratorVM()
            {
                Citys =CityFiller(),
                AdministrastorRoleList = AdministratorRoleFiller()
            };

            return View(administrator);
        }

        [HttpGet]
        public IActionResult AddAdministrator()
        {
            var administrator = new AdministratorVM()
            {
                Citys = CityFiller(),
                AdministrastorRoleList = AdministratorRoleFiller()
            };

            return View(administrator);
        }

        public List<SelectListItem> CityFiller()
        {
            var listofCitys = db.City.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return listofCitys;
        }

        public List<SelectListItem> AdministratorRoleFiller()
        {

            var listofRoles = db.AdministrastorRole.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return listofRoles;
        }
    }
}