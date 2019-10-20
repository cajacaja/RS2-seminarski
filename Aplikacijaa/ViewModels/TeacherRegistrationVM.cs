using Aplikacijaa.ContextFolder;
using Aplikacijaa.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ViewModels
{
    public class TeacherRegistrationVM
    {
       

        public int TeacherId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Polje moze samo sadrzavati slova!")]
        public string FName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Polje moze samo sadrzavati slova!")]
        public string LName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [TeacherAge]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Vas profil mora da ima sliku.")]
        public IFormFile ProfilePicture { get; set; }
        public string CollageName { get; set; }
        public List<IFormFile> Proof { get; set; }

        public decimal Price { get; set; }

        public int TitleId { get; set; }
        public IEnumerable<SelectListItem> Titles { get; set; }

        [Required(ErrorMessage = "Predmet mora da bude odabran.")]
        public int SubjectId { get; set; }
        public IEnumerable<SelectListItem> Subjects { get; set; }

        [StringLength(50)]
        [Remote(action: "EmailCheck", controller: "Validation")]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [EmailAddress(ErrorMessage = "Pogresan format e-maila!")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [Remote(action: "PhoneCheck", controller: "Validation")]
        public string PhoneNummber { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        public string Address { get; set; }


        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Citys { get; set; }


        public List<TypeOfStudentsFilter> typeOfStudents { get; set; }

        
        public int GenderId { get; set; }
        public List<SelectListItem> Gender { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [Remote(action: "UsernameCheck", controller: "Validation")]
        public string Username { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        public string Password { get; set; }

       public class TypeOfStudentsFilter
        {
            public int StudentTypeId { get; set; }
            public string Type { get; set; }
            public bool Checked { get; set; }
        }
    }
}
