using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelMVC.Models;
using Microsoft.AspNetCore.Http;

namespace ModelMVC.Controllers{
    public class UserController : Controller{

        public static List<Member> _listMembers = new List<Member>
            {
                new Member
                {
                    FirstName = "Thanh",
                    LastName = "Le",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-30),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                 new Member
                {
                    FirstName = "Tung",
                    LastName = "Vu",
                    BirthPlace = "Bac Ninh",
                    DoB = DateTime.Now.AddYears(-24),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                  new Member
                {
                    FirstName = "Thao",
                    LastName = "Vu",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-26),
                    Gender = "Female",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                   new Member
                {
                    FirstName = "Thang",
                    LastName = "NGuyen",
                    BirthPlace = "Da Nang",
                    DoB = DateTime.Now.AddYears(-15),
                    Gender = "Male",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
                    new Member
                {
                    FirstName = "Phuong",
                    LastName = "Nguyen",
                    BirthPlace = "Ha Noi",
                    DoB = DateTime.Now.AddYears(-20),
                    Gender = "Female",
                    IsGraduated = true,
                    PhoneNumber = "0123456789",
                    StartDate = DateTime.Now.AddYears(-10),
                    EndDate = DateTime.Now.AddYears(5)
                },
            };
        public IActionResult Index(){
            return View();
        }
        public IActionResult Add(){
            return View();
        }
    }
}