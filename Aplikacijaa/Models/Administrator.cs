using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateAdded { get; set; }

        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public int ProfileInfoId { get; set; }
        public ProfileInfo ProfileInfo { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int AdministrastorRoleId { get; set; }
        public AdministrastorRole AdministrastorRole { get; set; }
    }
}
