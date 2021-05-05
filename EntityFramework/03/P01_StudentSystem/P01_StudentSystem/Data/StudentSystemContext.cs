using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured == false)
                builder.UseSqlServer("Server=.;Database=Student System;Integrated Security=True;");

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Student>().Property(p => p.PhoneNumber).HasColumnType("varchar");
            //builder.Entity<Student>().HasCheckConstraint("Check_phone_number_lenght", "LEN(PhoneNumber)=10");
            builder.Entity<StudentCourse>().HasKey(k => new { k.CourseId, k.StudentId });


            base.OnModelCreating(builder);
        }
    }
}
