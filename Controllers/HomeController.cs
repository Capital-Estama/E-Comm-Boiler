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
                //setup session
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
                //setup session
                return RedirectToAction("Dashboard");

            } else {
                return View("Index");
            }
            
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            //setup session
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
