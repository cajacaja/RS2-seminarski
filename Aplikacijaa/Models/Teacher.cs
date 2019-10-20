﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public int TutorRegistrationFormId { get; set; }
        public TutorRegistrationForm TutorRegistrationForm { get; set; }
    }
}