using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class LandLord
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAdded { get; set; }

        public byte[] ProfilePicture { get; set; }

        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int ProfileInfoId { get; set; }
        public ProfileInfo ProfileInfo { get; set; }

        public int StatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
