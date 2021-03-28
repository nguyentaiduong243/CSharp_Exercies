using ModelMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<User> users = new List<User>()
        {
            new User()
            {
                UserId =1,
                Username ="admin",
                Password = "1234",
                RoleId =1,
            }
            ,new User()
            {
                UserId =2,
                Username ="visitor",
                Password = "1234",
                RoleId =2,
            }
        };
        static List<Role> _role = new List<Role>(){
            new Role{RoleId=1,RoleName="Admin"},
            new Role{RoleId=1,RoleName="Visitor"}

        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Login(string username, string password)
        {

            if (username != null && password != null && username.Equals(username) && password.Equals(password))
            {
                HttpContext.Session.SetString("username", username);
                return View("Success");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
