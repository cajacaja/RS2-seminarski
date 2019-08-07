using Aplikacijaa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacijaa.ContextFolder
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);          

        }

        public DbSet<City> City { get; set; }
        public DbSet<ContactInfo> Contact { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<StudentType> StudentType { get; set; }
        public DbSet<ProfileInfo> ProfileInfo { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<ReportedStudent> ReportedStudent { get; set; }
        public DbSet<ReportedTeacher> ReportedTeacher { get; set; }







    }
}
