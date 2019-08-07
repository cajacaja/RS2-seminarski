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
        public DateTime DateAdded { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string CollageName { get; set; }
        public byte[] Proof { get; set; }
        public decimal Price { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

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
    }
}
