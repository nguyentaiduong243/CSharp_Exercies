using System;

namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classroom { get; set; }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                DateTime currentDate = DateTime.Now;
                Age = currentDate.Year - birthDate.Year;
                if (currentDate.Month < birthDate.Month
                    || (currentDate.Month == birthDate.Month && currentDate.Day > birthDate.Day))
                {
                    Age--;
                }
            }
        }
        public int Age { get; private set; }

        public Student(string name, string classroom, DateTime birthDate)
        {
            if (CheckEmptyFields(name, classroom, birthDate)) throw new ArgumentNullException("All fields have to be filled");
            Name = name;
            Classroom = classroom;
            BirthDate = birthDate;
        }

        public Student(int id, string name, string classroom, DateTime birthDate) : this(name, classroom, birthDate)
        {
            Id = id;
        }

        public bool CheckEmptyFields()
        {
            return string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(Classroom)
                || BirthDate == new DateTime();
        }

        private static bool CheckEmptyFields(string name, string classroom, DateTime birthDate)
        {
            return string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(classroom)
                || birthDate == new DateTime();
        }

        public void Edit(Student editedStudent)
        {
            Name = editedStudent.Name;
            Classroom = editedStudent.Classroom;
            BirthDate = editedStudent.BirthDate;
        }
    }
}