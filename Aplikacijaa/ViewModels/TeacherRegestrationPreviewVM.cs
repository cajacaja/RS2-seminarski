using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ViewModels
{
    public class TeacherRegestrationPreviewVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Birthday { get; set; }

        public string ProfileImage { get; set; }

        public string Title { get; set; }

        public string CollageName { get; set; }

        public string Subject { get; set; }

        public List<string> ProofPictures { get; set; }

        public List<string> PreferedStudents { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Address { get; set; }        
    }
}
