using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Models
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; set;}
        Student GetStudentById(int id);
        Student AddNewStudent(Student student);
        bool EditStudent(int id, Student student);
        bool DeleteStudent(int id);
    }
}