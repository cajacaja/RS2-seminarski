using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class ReportedTeacher
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher RepTeacher { get; set; }
        public DateTime DateOfReporting { get; set; }
        public bool IsRead { get; set; }
    }
}
