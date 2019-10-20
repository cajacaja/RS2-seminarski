using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aplikacijaa.Models;
using Aplikacijaa.ContextFolder;
using Aplikacijaa.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplikacijaa.Helper;
using static Aplikacijaa.ViewModels.TeacherRegistrationVM;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Aplikacijaa.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly MyContext db;

        public HomeController(MyContext context, IHostingEnvironment e)
        {
            db = context;
            hostingEnvironment = e;
        }
        public IActionResult Index()
        {


            return View();
        }

        public IActionResult StudentRegistration()
        {
            var studentReg = new StudentViewModel();
            return View(model: ListsInput(studentReg));
        }

        [HttpPost]
        public IActionResult SaveRegistration(StudentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("StudentRegistration", ListsInput(model));
            }

            var contact = new ContactInfo()
            {
                Email=model.Email,
                Phone=model.PhoneNummber,
                Address=model.Address
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
                FName=model.FName,
                LName=model.LName,
                DateOfBirth=model.DateOfBirth,
                DateAdded=DateTime.Today,
                ContactId=contact.Id,
                CityId=model.CityId,
                StudentTypeId=model.StudentTypeId,
                StatusId=1,
                GenderId=model.GenderId,
                ProfileInfoId=profileInfo.Id
            };

            db.Student.Add(newStudent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult LandLordRegistration()
        {
            var landLordReg = new AddingLandLordVM();
            return View(model: LListInput(landLordReg));
        }

        [HttpPost]
        public IActionResult SaveLandLordRegistration(AddingLandLordVM model)
        {

            if (!ModelState.IsValid)
            {
                return View("LandLordRegistration", LListInput(model));
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

            var newLandLord = new LandLord()
            {
                Fname = model.FName,
                LName = model.LName,
                DateOfBirth = model.DateOfBirth,
                DateAdded = DateTime.Today,
                ContactInfoId = contact.Id,
                CityId = model.CityId,               
                StatusId = 1,
                GenderId = model.GenderId,
                ProfileInfoId = profileInfo.Id
            };

            db.LandLord.Add(newLandLord);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult PictureTest()
        {
            var lstTeacher = new List<TutorRegistrationForm>();
            lstTeacher = db.TutorRegistrationForm.ToList();

            return View(lstTeacher);
        }
        public IActionResult TeacherRegistration()
        {
            var newRegistration = new TeacherRegistrationVM();

            newRegistration.typeOfStudents = new List<TypeOfStudentsFilter>();
            var studentTypes = db.StudentType.ToList();

            foreach (var type in studentTypes)
            {
                var newFilter = new TypeOfStudentsFilter()
                {
                    StudentTypeId = type.Id,
                    Type = type.Type,
                    Checked = false
                };

                newRegistration.typeOfStudents.Add(newFilter);
            }

            return View(model:TeacherInput(newRegistration));
        }

        public IActionResult SaveTeacherRegistration(TeacherRegistrationVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("TeacherRegistration", TeacherInput(model));
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

            var newTutor = new TutorRegistrationForm()
            {
                FName=model.FName,
                LName = model.LName,
                ProfileInfoId=profileInfo.Id,
                DateOfBirth = model.DateOfBirth,               
                CollageName = model.CollageName,
                Price = model.Price,
                TitleId = model.TitleId,
                SubjectId = model.SubjectId,
                ContactInfoId = contact.Id,                
                CityId=model.CityId,
                GenderId=model.GenderId,
                IsRead=false

            };

           

            if (model.ProfilePicture != null)
            {
                var fileExst = Path.GetExtension(model.ProfilePicture.FileName);
                var newFileName = Convert.ToString(Guid.NewGuid())+fileExst;
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, "Profilepictures")+$@"\{newFileName}";
                var databaseName = "/Profilepictures/" + newFileName;
                model.ProfilePicture.CopyTo(new FileStream(fileName, FileMode.Create));
                newTutor.ProfilePicture = databaseName;
            }

            db.TutorRegistrationForm.Add(newTutor);
            db.SaveChanges();

            foreach (var item in model.Proof)
            {
                var fileExst = Path.GetExtension(item.FileName);
                var newFileName = Convert.ToString(Guid.NewGuid()) + fileExst;
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, "ProofPictures") + $@"\{newFileName}";
                item.CopyTo(new FileStream(fileName, FileMode.Create));
                var databaseName = "/ProofPictures/" + newFileName;

                var proofPicture = new Proof()
                {
                    TutorRegistrationFormId=newTutor.Id,
                    PictureName= databaseName
                };

                db.Proof.Add(proofPicture);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private AddingLandLordVM LListInput(AddingLandLordVM viewModel)
        {

            if (viewModel.Citys == null)
            {
                viewModel.Citys = db.City.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
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

       

     
        public StudentViewModel ListsInput(StudentViewModel viewModel)
        {
            if (viewModel.Citys == null)
            {
                viewModel.Citys = db.City.Select(x => new SelectListItem
                {
                    Value=x.Id.ToString(),
                    Text=x.Name
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

        public TeacherRegistrationVM TeacherInput(TeacherRegistrationVM viewModel)
        {
            if (viewModel.Citys == null)
            {
                viewModel.Citys = db.City.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
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

            if (viewModel.Titles == null)
            {
                viewModel.Titles = db.Title.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.TitleName
                }).ToList();
            }


            if (viewModel.Subjects == null)
            {
                viewModel.Subjects = db.Subject.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            }

          
            return viewModel;
        }
    }
}
