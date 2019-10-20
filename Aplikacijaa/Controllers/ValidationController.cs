using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplikacijaa.ContextFolder;
using Microsoft.AspNetCore.Mvc;

namespace Aplikacijaa.Controllers
{
    public class ValidationController : Controller
    {
        private readonly MyContext db;
        public ValidationController(MyContext context) => db = context;


        public IActionResult EmailCheck(string Email)
        {
            if (Email == null)
                return Json(true);

            var contact = db.Contact.FirstOrDefault(x => x.Email == Email);
            if(contact!=null)
                return Json("Email je vec zauzet!");

            
            return Json(true);
        }

        public IActionResult PhoneCheck(string PhoneNummber)
        {
            //if (PhoneNummber == null)
            //    return Json(true);

            var contact = db.Contact.FirstOrDefault(x => x.Phone == PhoneNummber);
            if (contact != null)
                return Json("Telefon je vec zauzet!");


            return Json(true);
        }

        public IActionResult UsernameCheck(string username)
        {
            if (username == null)
                return Json(true);

            var profileInfo = db.ProfileInfo.FirstOrDefault(x => x.Username == username);
            if (profileInfo != null)
                return Json("Korisnicko ime je vec zauzeto!");


            return Json(true);
        }

        

        public IActionResult CheckPassword(string Password,string Password2)
        {
           if(Password==Password2)
            return Json(true);

            return Json("Lozinke se ne podudaraju!");
        }

      
    }
}