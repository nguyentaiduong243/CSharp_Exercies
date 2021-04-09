using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public Student GetStudentById(int id)
        {
            Student student = Students.Find(id);

            if (student == null) throw new NullReferenceException("Cannot find student");

            return student;
        }

        public Student AddNewStudent(Student newStudent)
        {
            if (newStudent.CheckEmptyFields()) return null;

            int currentCount = Students.Count();

            Students.Add(newStudent);

            SaveChanges();

            return CountChanged(currentCount) ? newStudent : null;
        }

        public bool EditStudent(int id, Student editedStudent)
        {
            if (editedStudent.CheckEmptyFields()) return false;

            Student existingStudent = Students.Find(id);

            if (existingStudent == null) throw new NullReferenceException("Cannot find student");

            existingStudent.Edit(editedStudent);

            SaveChanges();

            return true;
        }

        public bool DeleteStudent(int id)
        {
            Student student = Students.Find(id);

            if (student == null) return false;

            int currentCount = Students.Count();

            Students.Remove(student);

            SaveChanges();

            return CountChanged(currentCount);
        }

        private bool CountChanged(int count)
        {
            return count != Students.Count();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasData(
                new Student(1, "Nguyen Tai Duong", "Rookies", new DateTime(1998, 1, 6)),
                new Student(2, "Vu Tien Thanh", "Not rookies", new DateTime(1997, 5, 26))
            );
        }
    }
}