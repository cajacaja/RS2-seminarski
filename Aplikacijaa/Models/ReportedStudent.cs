using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class ReportedStudent
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public Student RepStudent { get; set; }
        public string ResaonForReport { get; set; }
        public DateTime DateOfReporting { get; set; }
        public bool IsRead { get; set; }
    }
}
