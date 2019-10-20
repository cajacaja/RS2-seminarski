using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class Proof
    {
        public int Id { get; set; }

        public int TutorRegistrationFormId { get; set; }
        public TutorRegistrationForm TutorRegistrationForm { get; set; }
        public string PictureName { get; set; }
    }
}
