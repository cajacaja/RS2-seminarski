using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aplikacijaa.ContextFolder;
using Aplikacijaa.Helper;
using Aplikacijaa.Models;
using Aplikacijaa.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Aplikacijaa.ViewModels.TeacherRegistrationVM;

namespace Aplikacijaa.Controllers
{
    public class TeacherResgistrationController : Controller
    {
        private readonly MyContext db;
        private readonly IHostingEnvironment hostingEnvironment;

        public TeacherResgistrationController(MyContext context, IHostingEnvironment e)
        {
            db = context;
            hostingEnvironment = e;

        }

        public IActionResult Index()
        {
            var ListOfTeacherRegistration = new List<TutorRegistrationForm>();
            ListOfTeacherRegistration = db.TutorRegistrationForm.ToList();
            var TeacherRegistrationVM = new List<ListOfTeachersVM>();
            if (ListOfTeacherRegistration != null) 
            {
                foreach (var registration in ListOfTeacherRegistration)
                {
                    var Teacher = new ListOfTeachersVM()
                    {
                        TeacherId = registration.Id,
                        FirstName = registration.FName,
                        LastName = registration.LName,
                        BirthDay = registration.DateOfBirth.ToShortDateString(),
                        City = db.City.FirstOrDefault(x => x.Id == registration.CityId).Name,
                        Gender = db.Gender.FirstOrDefault(x => x.Id == registration.GenderId).UserGender,
                        Title=db.Title.FirstOrDefault(x=>x.Id==registration.TitleId).TitleName,
                        Subject = db.Subject.FirstOrDefault(x => x.Id == registration.SubjectId).Name                       
                    
                    };
                    TeacherRegistrationVM.Add(Teacher);
                }
            }
            return View(TeacherRegistrationVM);
        }
        public IActionResult AddRegistration()
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

            return View(model: TeacherInput(newRegistration));
        }        
       
        [HttpPost]
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
                FName = model.FName,
                LName = model.LName,
                ProfileInfoId = profileInfo.Id,
                DateOfBirth = model.DateOfBirth,
                CollageName = model.CollageName,
                Price = model.Price,
                TitleId = model.TitleId,
                SubjectId = model.SubjectId,
                ContactInfoId = contact.Id,
                CityId = model.CityId,
                GenderId = model.GenderId,
                IsRead = false

            };



            if (model.ProfilePicture != null)
            {
                var fileExst = Path.GetExtension(model.ProfilePicture.FileName);
                var newFileName = Convert.ToString(Guid.NewGuid()) + fileExst;
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, "Profilepictures") + $@"\{newFileName}";
                var databaseName = "/Profilepictures/" + newFileName;
                model.ProfilePicture.CopyTo(new FileStream(fileName, FileMode.Create));
                newTutor.ProfilePicture = databaseName;
            }

            db.TutorRegistrationForm.Add(newTutor);
            db.SaveChanges();

            foreach (var item in model.typeOfStudents)
            {
                if (item.Checked)
                {

                    var PerferedType = new ListOfStudents()
                    {
                        TutorRegistrationFormId = newTutor.Id,
                        StudentTypeId = item.StudentTypeId
                    };

                    db.ListOfStudents.Add(PerferedType);
                    db.SaveChanges();
                }

            }

            foreach (var item in model.Proof)
            {
                var fileExst = Path.GetExtension(item.FileName);
                var newFileName = Convert.ToString(Guid.NewGuid()) + fileExst;
                var fileName = Path.Combine(hostingEnvironment.WebRootPath, "ProofPictures") + $@"\{newFileName}";
                item.CopyTo(new FileStream(fileName, FileMode.Create));
                var databaseName = "/ProofPictures/" + newFileName;

                var proofPicture = new Proof()
                {
                    TutorRegistrationFormId = newTutor.Id,
                    PictureName = databaseName
                };

                db.Proof.Add(proofPicture);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult PreviewTeacherRegistration(int id) 
        {
            var TeacherRegistration = db.TutorRegistrationForm.FirstOrDefault(x=>x.Id==id);
            var ContactInfo = db.Contact.FirstOrDefault(x=>x.Id== TeacherRegistration.ContactInfoId);
            if (TeacherRegistration == null)
                return NotFound();
            var RegistratonVM = new TeacherRegestrationPreviewVM()
            {
                Id = TeacherRegistration.Id,
                FullName = TeacherRegistration.FName + " " + TeacherRegistration.LName,
                Gender=db.Gender.FirstOrDefault(x=>x.Id== TeacherRegistration.GenderId).UserGender,
                Birthday= TeacherRegistration.DateOfBirth.ToShortDateString(),
                ProfileImage= TeacherRegistration.ProfilePicture,
                Title=db.Title.FirstOrDefault(x=>x.Id== TeacherRegistration.TitleId).TitleName,
                CollageName= TeacherRegistration.CollageName,
                Subject=db.Subject.FirstOrDefault(x=>x.Id== TeacherRegistration.SubjectId).Name,
                Email=ContactInfo.Email,
                Phone=ContactInfo.Phone,
                Address=ContactInfo.Address,
                City=db.City.FirstOrDefault(x=>x.Id== TeacherRegistration.CityId).Name,
                ProofPictures= db.Proof.Where(x => x.TutorRegistrationFormId == TeacherRegistration.Id).Select(x => x.PictureName).ToList(),

                PreferedStudents= (from registration in db.TutorRegistrationForm
                                   join list in db.ListOfStudents on registration.Id equals list.TutorRegistrationFormId
                                   join studentype in db.StudentType on list.StudentTypeId equals studentype.Id
                                   where registration.Id == TeacherRegistration.Id
                                   select studentype.Type).ToList()


        };

            return View(RegistratonVM);
        }

        public IActionResult AcceptRegistration(int Id) 
        {
            var registration = db.TutorRegistrationForm.FirstOrDefault(x => x.Id == Id);
            if (registration == null)
                return NotFound();
            registration.IsAceppted = true;
            registration.IsRead = true;

            db.TutorRegistrationForm.Update(registration);
           

            var newTeacher = new Teacher()
            {
                TutorRegistrationFormId = Id,
                DateAdded = DateTime.Now
            };

            db.Teacher.Add(newTeacher);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeclineRegistration(int Id) 
        {
            var registration = db.TutorRegistrationForm.FirstOrDefault(x => x.Id == Id);
            if (registration == null)
                return NotFound();
            registration.IsAceppted = false;
            registration.IsRead = true;

            db.TutorRegistrationForm.Update(registration);
            db.SaveChanges();

            return RedirectToAction("Index");
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