using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using THOUGHTBOX.HUMANRESOURCE.Models;
using Microsoft.AspNetCore.Http;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Login()
        {
            return View("Login");

        }
        public IActionResult Home()
        {
            // var message = _session.GetString("Test");
            string usertype = HttpContext.Session.GetInt32("userTypeId").ToString();
            if (usertype == "8")
            {
                return RedirectToAction("Index", "DashboardMD");
            }
            else if (usertype == "9")
            {
                return RedirectToAction("Index", "DashboardBDM");
            }
            else if (usertype == "29")
            {
                return RedirectToAction("Index", "DashboardDH");
            }
            else if (usertype == "10")
            {
                return RedirectToAction("Index", "DashboardME");
            }
            else
            { 
            return View("Home");
            }
        }
        public IActionResult Register()
        {
            return View("Register");

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
