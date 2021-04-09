using System;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;

namespace StudentAPI.Models.Tests
{
    public class App_2021_04_01
    {
        private static IEnumerable<TestCaseData> GetStudentCorrectData()
        {
            yield return new TestCaseData("Duong", "Rookies", new DateTime(1998, 1, 6));
            yield return new TestCaseData("Thanh", "Rookies", new DateTime(2001, 4, 6));
            yield return new TestCaseData("Anh", "Rookies", new DateTime(2000, 4, 5));
            yield return new TestCaseData("Manh", "Rookies", new DateTime(1998, 4, 4));
        }

        private static IEnumerable<TestCaseData> GetStudentWithMissingFieldsData()
        {
            yield return new TestCaseData("Duong", "", new DateTime(1998, 1, 6));
            yield return new TestCaseData("", "Rookies", new DateTime(2001, 4, 3));
            yield return new TestCaseData("Thanh", "Rookies", new DateTime());
            yield return new TestCaseData("", "", new DateTime(1998, 4, 1));
            yield return new TestCaseData("", "Rookies", new DateTime());
            yield return new TestCaseData("Duong", "", new DateTime());
        }
        private static IEnumerable<TestCaseData> GetStudentCorrectDataWithAge()
        {
            yield return new TestCaseData("Duong", "Rookies", new DateTime(1998, 1, 6), 23);
            yield return new TestCaseData("Thanh", "Rookies", new DateTime(2001, 4, 6), 20);
            yield return new TestCaseData("Anh", "Rookies", new DateTime(2000, 4, 5), 21);
            yield return new TestCaseData("Manh", "Rookies", new DateTime(1998, 4, 4), 22);
        }

        [TestCaseSource(nameof(GetStudentCorrectData))]
        public void Constructor_CreateStudentWithNormalParameters_ShoudlPass(string name, string classroom, DateTime birthDate)
        {
            Student student = new(name, classroom, birthDate);

            Assert.AreEqual(name, student.Name, "Failed to create student");
        }

        [TestCaseSource(nameof(GetStudentWithMissingFieldsData))]
        public void Constructor_CreateStudentWithMissingFields_ShouldThrowException(string name, string classroom, DateTime birthdate)
        {
            object studentConstructor() => new Student(name, classroom, birthdate);

            Assert.That(studentConstructor, Throws.TypeOf<ArgumentNullException>(), "Student was created");
        }

        [TestCaseSource(nameof(GetStudentCorrectDataWithAge))]
        public void AgeSetter_WithCorrectDate_ShouldPass(string name, string classroom, DateTime birthdate, int age)
        {
            Student student = new(name, classroom, birthdate);

            Assert.AreEqual(age, student.Age, "Age is not set correctly");
        }
    }
}