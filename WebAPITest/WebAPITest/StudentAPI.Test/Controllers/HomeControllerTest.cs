using StudentAPI.Controllers;
using StudentAPI.Models;
using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace StudentAPI.Controllers.Tests
{
    public class HomeControllerTest
    {
        private StudentDbContext context;
        private HomeController controller;
        private static IEnumerable<TestCaseData> GetStudentCorrectData()
        {
            yield return new TestCaseData("Duong", "Rookies", new DateTime(1998, 1, 6));
            yield return new TestCaseData("Thanh", "Rookies", new DateTime(2001, 4, 3));
            yield return new TestCaseData("Anh", "Rookies", new DateTime(2000, 4, 2));
            yield return new TestCaseData("Manh", "Rookies", new DateTime(1998, 4, 1));
        }

        [OneTimeSetUp]
        public void ClassInit()
        {
            ServiceCollection services = new();

            services.AddDbContext<StudentDbContext>(
                opt => opt.UseInMemoryDatabase(databaseName: "StudentAPI"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped
            );

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            context = serviceProvider.GetService<StudentDbContext>();

            controller = new(context);
        }

        [Test, Order(1)]
        [TestCaseSource(nameof(GetStudentCorrectData))]
        public void AddNewStudent_WithFilledFields_ShouldPass(string name, string classroom, DateTime birthDate)
        {
            HttpResponseMessage result = controller.AddNewStudent(name, classroom, birthDate);

            Assert.That(result.ReasonPhrase, Contains.Substring("Added new student"), "Cannot add new student");
        }

        [TestCase("Duong", "")]
        [TestCase("", "Rookies")]
        [TestCase("", "")]
        [TestCase("Duong", null)]
        [TestCase(null, "Rookies")]
        [TestCase(null, null)]
        [Test, Order(2)]
        public void AddNewStudent_WithEmptyOrNullFields_ShouldThrowException(string name, string classroom)
        {
            object addStudent() => controller.AddNewStudent(name, classroom, new DateTime());

            Assert.That(addStudent, Throws.TypeOf<ArgumentNullException>(), "Added new student");
        }

        [TestCase(1)]
        [TestCase(4)]
        [Test, Order(3)]
        public void GetStudentById_WithExistingId_ShouldPass(int id)
        {
            HttpResponseMessage result = controller.GetStudentById(id);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Not found");
        }

        [TestCase(5)]
        [TestCase(6)]
        [Test, Order(4)]
        public void GetStudentById_WithNonexistingId_ShouldThrowException(int id)
        {
            object studentDelegate() => controller.GetStudentById(id);

            Assert.That(studentDelegate, Throws.TypeOf<NullReferenceException>(), "Found student");
        }

        [TestCase(1, "Duong Nguyen", "Rookies")]
        [TestCase(2, "Thanh Tien", "Rookies")]
        [Order(5)]
        public void EditStudent_WithCorrectFields_ShouldPass(int id, string name, string classroom)
        {
            HttpResponseMessage result = controller.EditStudent(id, name, classroom, new DateTime(1998, 6, 1));

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Student was not edited.");
        }

        [TestCase(1, "Duong Nguyen", "")]
        [TestCase(2, "", "Rookies")]
        [Test, Order(6)]
        public void EditStudent_WithEmptyFields_ShouldFail(int id, string name, string classroom)
        {
            object editStudent() => controller.EditStudent(id, name, classroom, new DateTime(1998, 6, 1));

            Assert.That(editStudent, Throws.TypeOf<ArgumentNullException>(), "Student was edited");
        }

        [TestCase(5, "Duong Nguyen", "Rookies")]
        [TestCase(100, "Thanh Tien", "Rookies")]
        [Test, Order(7)]
        public void EditStudent_ByNonexistingId_ShouldThrowException(int id, string name, string classroom)
        {
            object editStudent() => controller.EditStudent(id, name, classroom, new DateTime(1998, 6, 1));

            Assert.That(editStudent, Throws.TypeOf<NullReferenceException>(), "Found student.");
        }

        [TestCase(1)]
        [TestCase(4)]
        [Order(8)]
        public void DeleteStudent_ByExistingId_ShouldPass(int id)
        {
            HttpResponseMessage result = controller.DeleteStudent(id);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Student was not deleted");
        }

        [TestCase(5)]
        [TestCase(4)]
        [Test, Order(9)]
        public void DeleteStudent_ByNonexistingId_ShouldFail(int id)
        {
            HttpResponseMessage result = controller.DeleteStudent(id);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode, "Student was not deleted");
        }
    }
}