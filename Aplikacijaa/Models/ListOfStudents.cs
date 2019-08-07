using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class ListOfStudents
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentTypeId { get; set; }
        public StudentType StudentType { get; set; }
    }
}
