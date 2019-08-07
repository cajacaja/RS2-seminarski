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
    }
}
