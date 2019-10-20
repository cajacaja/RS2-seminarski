using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class TutorRegistrationForm
    {
        public int Id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public string ProfilePicture { get; set; }
        public string CollageName { get; set; }
        
        public decimal Price { get; set; }

        public int ProfileInfoId { get; set; }
        public ProfileInfo ProfileInfo { get; set; }


        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public bool IsRead { get; set; }
        public bool IsAceppted { get; set; }
    }
}
