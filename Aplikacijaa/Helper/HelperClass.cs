using Aplikacijaa.ContextFolder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Helper
{
    public class HelperClass
    {
        private  MyContext db;

        private static HelperClass obj;
        public HelperClass(MyContext context)
        {
            db = context;
        }

        public static HelperClass GetInstance(MyContext context)
        {
            if (obj == null)
                obj = new HelperClass(context);
            return obj;
        }

        public  List<SelectListItem> CityFiller() 
        {
           var listofCitys = db.City.Select(x => new SelectListItem
            {
               Value=x.Id.ToString(),
               Text=x.Name
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
