using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ViewModels
{
    public class AdministratorIndexVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DateAdded { get; set; }
        public string AdministratorCity { get; set; }
        public string AdministratorRole { get; set; }

    }
}
