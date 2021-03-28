using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelMVC.Models;
using Microsoft.AspNetCore.Http;

namespace ModelMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static List<User> SeedUser = new List<User>(){new User("Admin","1")};

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            // CookieOptions options = new CookieOptions();
            // options.Expires = DateTime.Now.AddMinutes(10);
            // Response.Cookies.Append("Username","Test user",options);
            return View();
        }

        public IActionResult Privacy()
        {
            // Response.Cookies.Delete("Username");
            return View();
        }
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User user= SeedUser.SingleOrDefault(a => a.Username == username && a.Password == password);
            if(user != null){
                HttpContext.Session.SetString("Username",user.Username);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append("Username",user.Username,options);
                return RedirectToAction("");
            }
            return View();
        }

        public IActionResult Logout(){
            HttpContext.Session.SetString("Username",null);
            Response.Cookies.Delete("Username");
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
