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
            var administrators = db.Administrator.ToList();
            var administratorVm = new List<AdministratorIndexVM>();
            foreach (var administrator in administrators)
            {
                var administratorInput = new AdministratorIndexVM()
                {
                    Id = administrator.Id,
                    FullName = administrator.FName + " " + administrator.LName,
                    UserName = db.ProfileInfo.FirstOrDefault(x => x.Id == administrator.ProfileInfoId).Username,
                    DateAdded = administrator.DateAdded.ToString(),
                    AdministratorRole = db.AdministrastorRole.FirstOrDefault(x => x.Id == administrator.AdministrastorRoleId).Name,
                    AdministratorCity = db.City.FirstOrDefault(x => x.Id == administrator.CityId).Name,
                    Email=db.Contact.FirstOrDefault(x=>x.Id==administrator.ContactInfoId).Email,
                    Phone=db.Contact.FirstOrDefault(x=>x.Id==administrator.ContactInfoId).Phone
                };

                administratorVm.Add(administratorInput);
            };
          return View(administratorVm);
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

        [HttpPost]
        public IActionResult SaveAdministrator(AdministratorVM obj)
        {
            var contactInfo = new ContactInfo()
            {
                Address = obj.Address,
                Email = obj.Email,
                Phone = obj.Phone
            };
            db.Contact.Add(contactInfo);
            db.SaveChanges();

            var profileInfo = new ProfileInfo()
            {
                Username = obj.Username,
                PasswordSalt = PasswordHashAndSalt.GenerateSalt()
            };
            profileInfo.PasswordHash = PasswordHashAndSalt.GenerateHash(profileInfo.PasswordSalt, obj.Password);
            db.ProfileInfo.Add(profileInfo);
            db.SaveChanges();


            var newAdministrator = new Administrator()
            {
                FName = obj.FirstName,
                LName = obj.LastName,
                AdministrastorRoleId = obj.AdministrastorRoleId,
                CityId = obj.CityId,
                DateAdded = DateTime.Now.ToUniversalTime(),
                ProfileInfoId = profileInfo.Id,
                ContactInfoId = contactInfo.Id

            };

            db.Administrator.Add(newAdministrator);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditAdministrator(int id)
        {
            var administrator = db.Administrator.FirstOrDefault(x => x.Id == id);

            if (administrator == null)
                return NotFound();

            var contactInfo = db.Contact.FirstOrDefault(x => x.Id == administrator.ContactInfoId);
            var profileInfo = db.ProfileInfo.FirstOrDefault(x => x.Id == administrator.ProfileInfoId);



            var administratorVM = new AdministratorVM()
            {
                Id = administrator.Id,
                FirstName = administrator.FName,
                LastName = administrator.LName,
                CityId = administrator.CityId,
                AdministrastorRoleId = administrator.AdministrastorRoleId,
                Address = contactInfo.Address,
                Email = contactInfo.Email,
                Phone = contactInfo.Phone,
                Username = profileInfo.Username,
                Citys = CityFiller(),
                AdministrastorRoleList = AdministratorRoleFiller()
            };
            return View(administratorVM);
        }
        [HttpPut]
        public IActionResult UpdatedAdministrator(AdministratorVM obj)
        {
            var contactInfo = new ContactInfo()
            {
                Address = obj.Address,
                Email = obj.Email,
                Phone = obj.Phone
            };
            db.Contact.Update(contactInfo);
            db.SaveChanges();

            var profileInfo = new ProfileInfo()
            {
                Username = obj.Username,
               
            };
            if (!String.IsNullOrEmpty(obj.Password))
            {
                profileInfo.PasswordSalt = PasswordHashAndSalt.GenerateSalt();
                profileInfo.PasswordHash = PasswordHashAndSalt.GenerateHash(profileInfo.PasswordSalt, obj.Password);
            }
            
            db.ProfileInfo.Update(profileInfo);
            db.SaveChanges();


            var editedAdministrator = new Administrator()
            {
                FName = obj.FirstName,
                LName = obj.LastName,
                AdministrastorRoleId = obj.AdministrastorRoleId,
                CityId = obj.CityId,                
                ProfileInfoId = profileInfo.Id,
                ContactInfoId = contactInfo.Id

            };

            db.Administrator.Update(editedAdministrator);
            db.SaveChanges();


            return RedirectToAction();
        }


        
        public IActionResult RemoveAdministrator(int id) 
        {
            var administrator = db.Administrator.FirstOrDefault(x => x.Id == id);
            if (administrator == null)
                return NotFound();
            var contactInfo = db.Contact.FirstOrDefault(x => x.Id == administrator.ContactInfoId);
            if (contactInfo == null)
                return NotFound();
            var profileInfo = db.ProfileInfo.FirstOrDefault(x => x.Id == administrator.ProfileInfoId);
            if (profileInfo == null)
                return NotFound();

            db.Remove(contactInfo);
            db.Remove(profileInfo);
            db.Remove(administrator);
            db.SaveChanges();


            return RedirectToAction("Index");
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