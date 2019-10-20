using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.Models
{
    public class ClassRequest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public TypeOfClass TypeOfClassId { get; set; }
        public TypeOfClass TypeOfClass { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public TimeSpan HourFrom { get; set; }
        public TimeSpan HourTo{ get; set; }
        public bool IsRead { get; set; }
        public bool IsAceppted { get; set; }
    }
}
