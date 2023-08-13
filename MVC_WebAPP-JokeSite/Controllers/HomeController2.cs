using Microsoft.AspNetCore.Mvc;
using MVC_WebAPP_JokeSite.Models;
using System.Diagnostics;

namespace MVC_WebAPP_JokeSite.Controllers
{
    public class HomeController2 : Controller
    {
        private readonly ILogger<HomeController2> _logger;

        public HomeController2(ILogger<HomeController2> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Id = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}