﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ViewModels
{
    public class AdministratorVM    {

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region Contactinfo
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        #endregion

        #region ProfileInfo
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        public int CityId { get; set; }
        public List<SelectListItem> Citys { get; set; }
        public int AdministrastorRoleId { get; set; }
        public List<SelectListItem> AdministrastorRoleList { get; set; }
    }
}
