using BlockBusterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlockBusterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            List<string> colors = new List<string>
            {
                "Red",
                "Blue",
                "Yellow",
                "Black"
            };

            ViewData["colors"] = colors;

            return View();
        }        
        
        public IActionResult Hobbies()
        {
            List<string> hobbies = new List<string>
            {
                "Programming",
                "Swimming",
                "Eating",
                "Spending Money",
                "Video Games"
            };

            ViewData["hobbies"] = hobbies;

            return View();
        }

        public IActionResult Movies()
        {
            List<string> movies = new List<string>
            {
                "Saw",
                "Jumanji",
                "Avengers"
            };
            ViewBag.movies = movies;
            return View();
        }       
        
        public IActionResult Cities()
        {
            List<string> cities = new List<string>
            {
                "New York City",
                "Providence",
                "Atlanta",
                "Orlando",
                "Bakersfield"
            };
            ViewBag.cities = cities;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
