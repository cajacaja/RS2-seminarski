using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class ListOfStudents
    {
        public int Id { get; set; }

        public int TutorRegistrationFormId { get; set; }
        public TutorRegistrationForm TutorRegistrationForm { get; set; }

        public int StudentTypeId { get; set; }
        public StudentType StudentType { get; set; }
    }
}
