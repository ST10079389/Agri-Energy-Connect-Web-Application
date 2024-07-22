using Microsoft.AspNetCore.Mvc;
using ST10079389_Kaushil_Dajee_PROG7311.Models;
using System.Diagnostics;

namespace ST10079389_Kaushil_Dajee_PROG7311.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomePageEmployee()
        {
            return View();
        }

        public IActionResult HomePageFarmer()
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
