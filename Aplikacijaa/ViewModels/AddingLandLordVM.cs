﻿using Aplikacijaa.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ViewModels
{
    public class AddingLandLordVM
    {
        public int LandLordId { get; set; }
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        public string FName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        public string LName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Age]
        public DateTime DateOfBirth { get; set; }


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


        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        [Remote(action: "UsernameCheck", controller: "Validation")]
        public string Username { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Polje ne smije biti prazno!")]
        public string Password { get; set; }

        [Required]
        [Remote(action: "CheckPassword", controller: "Validation", AdditionalFields = nameof(Password))]
        public string PasswordCheck { get; set; }

        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Citys { get; set; }

        public int GenderId { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }
    }
}
