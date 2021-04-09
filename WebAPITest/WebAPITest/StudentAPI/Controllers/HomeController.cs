using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IStudentDbContext _context;

        public HomeController(IStudentDbContext context)
        {
            _context = context;
        }

        [Route("/GetStudentById/{id}")]
        public HttpResponseMessage GetStudentById(int id)
        {
            Student student = _context.GetStudentById(id);
            HttpResponseMessage response;
            if (student != null)
            {
                response = new(HttpStatusCode.OK);
                response.ReasonPhrase = $"Student was found with id: ${id}";
                response.Content = new StringContent(JsonSerializer.Serialize(student));
            }
            else
            {
                response = new(HttpStatusCode.NotFound);
                response.ReasonPhrase = $"Student was found with id: ${id}";
            }
            return response;
        }

        [Route("/AddNewStudent")]
        public HttpResponseMessage AddNewStudent(string name, string classroom, DateTime birthDate)
        {
            Student newStudent = new(name, classroom, birthDate);
            Student addedStudent = _context.AddNewStudent(newStudent);
            HttpResponseMessage response;
            if (addedStudent != null)
            {
                response = new(HttpStatusCode.OK);
                response.ReasonPhrase = $"Added new student with id: ${newStudent.Id}";
                response.Content = new StringContent(JsonSerializer.Serialize(newStudent));
            }
            else
            {
                response = new(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "New student cannot be created";
            }
            return response;
        }

        [Route("/EditStudent/{id}")]
        public HttpResponseMessage EditStudent(int id, string name, string classroom, DateTime birthDate)
        {
            Student editedStudent = new(name, classroom, birthDate);
            bool isEdited = _context.EditStudent(id, editedStudent);
            HttpResponseMessage response;
            if (isEdited)
            {
                response = new(HttpStatusCode.OK);
                response.ReasonPhrase = $"Student was edited with id: ${id}";
                response.Content = new StringContent(JsonSerializer.Serialize(editedStudent));
            }
            else
            {
                response = new(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Cannot edit student";
            }
            return response;
        }

        [Route("/DeleteStudent/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            bool isEdited = _context.DeleteStudent(id);
            HttpResponseMessage response;
            if (isEdited)
            {
                response = new(HttpStatusCode.OK);
                response.ReasonPhrase = $"Student was deleted with id: ${id}";
            }
            else
            {
                response = new(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Student was not deleted";
            }
            return response;
        }
    }
}