using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class StudentController : Controller
    {

        // Moras napravit Viewve za ovaj kontroler
        private readonly MyContext db;

        public StudentController(MyContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            var studentReg = new StudentViewModel();
            return View(model: ListsInput(studentReg));
        }
        [HttpPost]
        public IActionResult SaveStudent(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("StudentRegistration", ListsInput(model));
            }

            var contact = new ContactInfo()
            {
                Email = model.Email,
                Phone = model.PhoneNummber,
                Address = model.Address
            };
            db.Contact.Add(contact);
            db.SaveChanges();

            var profileInfo = new ProfileInfo()
            {
                Username = model.Username,
                PasswordSalt = PasswordHashAndSalt.GenerateSalt()
            };
            profileInfo.PasswordHash = PasswordHashAndSalt.GenerateHash(profileInfo.PasswordSalt, model.Password);
            db.ProfileInfo.Add(profileInfo);
            db.SaveChanges();

            var newStudent = new Student()
            {
                FName = model.FName,
                LName = model.LName,
                DateOfBirth = model.DateOfBirth,
                DateAdded = DateTime.Today,
                ContactId = contact.Id,
                CityId = model.CityId,
                StudentTypeId = model.StudentTypeId,
                StatusId = 1,
                GenderId = model.GenderId,
                ProfileInfoId = profileInfo.Id
            };

            db.Student.Add(newStudent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditStudent(int id)
        {
            var student = db.Student.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();
            var studentContactInfo = db.Contact.FirstOrDefault(x => x.Id == student.ContactId);
            var profileInfo = db.ProfileInfo.FirstOrDefault(x => x.Id == student.ProfileInfoId);

            //Password ce bit empty pa ako ostane empty nista se ne mjenja
            var studentVM = new StudentViewModel()
            {
                StudentId = student.Id,//readonly
                FName = student.FName,//readonly
                LName = student.LName,//readonly
                DateOfBirth = student.DateOfBirth,//readonly
                DateAdded = student.DateAdded,//readonly
                Email = studentContactInfo.Email,
                Address = studentContactInfo.Address,
                PhoneNummber = studentContactInfo.Phone,
                CityId = student.CityId,
                Username = profileInfo.Username,
                ProfilePicture = student.ProfilePicture,
                StudentTypeId = student.StudentTypeId

            };
            studentVM = ListsInput(studentVM);

            return View(studentVM);
        }

        public IActionResult UpdateStudent(StudentViewModel model)
        {
            //Treba validacija za Email i telefon, za addrtesu ne treba jer neki useri mogu da dijele adresu


            var editedStudent = db.Student.FirstOrDefault(x => x.Id == model.StudentId);
            var contactInfo = db.Contact.FirstOrDefault(x => x.Id == editedStudent.ContactId);
            var profileInfo = db.ProfileInfo.FirstOrDefault(x => x.Id == editedStudent.ProfileInfoId);

            contactInfo.Email = model.Email;
            contactInfo.Phone = model.PhoneNummber;
            contactInfo.Address = model.Address;


            db.Contact.Update(contactInfo);
            db.SaveChanges();
            
            profileInfo.Username = model.Username;
            if (!String.IsNullOrEmpty(model.Password))
            {
                profileInfo.PasswordSalt = PasswordHashAndSalt.GenerateSalt();
                profileInfo.PasswordHash = PasswordHashAndSalt.GenerateHash(profileInfo.PasswordSalt, model.Password);
            }

            db.Update(profileInfo); 
            db.SaveChanges();

            editedStudent.FName = model.FName;//readonly
            editedStudent.LName = model.LName;//readonly
            editedStudent.DateOfBirth = model.DateOfBirth;//readonly
            editedStudent.DateAdded = model.DateAdded;//readonly
            editedStudent.ContactId = contactInfo.Id;
            editedStudent.ProfileInfoId = profileInfo.Id;
            editedStudent.CityId = model.CityId;
            editedStudent.StudentTypeId = model.StudentTypeId;
            editedStudent.ProfilePicture = model.ProfilePicture;//ako su isti biti ko vec nemjenjaj nista ako nisu onda mjenjaj treba dodat isto treba kompresovat sliku



            db.Update(editedStudent);
            db.SaveChanges();

            //Redirekcija se treba stavit 
            return RedirectToAction("Index", "Home");
        }

        //Moze se dodat mod za aktivnost usera to jest da stavi da li je aktivan ili ne ili to se moze stavit samo za tutore

        public StudentViewModel ListsInput(StudentViewModel viewModel)
        {
            if (viewModel.Citys == null)
            {
                viewModel.Citys = db.City.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            }

            if (viewModel.StudentTypes == null)
            {
                viewModel.StudentTypes = db.StudentType.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Type
                }).ToList();


            }

            if (viewModel.Gender == null)
            {
                viewModel.Gender = db.Gender.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.UserGender
                }).ToList();
            }
            return viewModel;
        }


    }
}