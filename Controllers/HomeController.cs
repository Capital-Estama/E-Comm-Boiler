using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using C_Sharp_Boiler.Models;
//added access to session
using Microsoft.AspNetCore.Http;
//  for password hasing 
using Microsoft.AspNetCore.Identity;

namespace C_Sharp_Boiler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // added
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost("users/add")]
        public IActionResult AddUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(a => a.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                if(_context.Users.Any(a => a.Username == newUser.Username))
                {
                    ModelState.AddModelError("Username", "Username already in use!");
                    return View("Index");
                }
                // hash password before sending to database
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                //setup session
                HttpContext.Session.SetInt32("Userid", newUser.UserID);
                return RedirectToAction("Dashboard");

            } else {
                return View("Index");
            }
            
        }

        [HttpPost("users/login")]
        public IActionResult LogUser(LoginUser loggedIn)
        {
            if(ModelState.IsValid)
            {
                // go find user
                User userInDB = _context.Users.FirstOrDefault(a => a.Email == loggedIn.LogEmail);
                if(userInDB == null)
                {
                    ModelState.AddModelError("LogEmail", "Invaild login attepmt");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loggedIn, userInDB.Password, loggedIn.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LogEmail", "Invaild login attepmt");
                    return View("Index");
                }
                //setup session
                HttpContext.Session.SetInt32("UserId", userInDB.UserID);
                return RedirectToAction("Dashboard");

            } else {
                return View("Index");
            }
            
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            //setup session
            if(HttpContext.Session.GetInt32("Userid") == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.loggedIn = _context.Users.FirstOrDefault( a => a.UserID == HttpContext.Session.GetInt32("UserId"));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
