using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Models;

namespace ParkingManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Process the search query here
                ViewBag.SearchTerm = searchQuery;
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public IActionResult Price()
        {
            return View();
        }
        public IActionResult Read_More()
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
