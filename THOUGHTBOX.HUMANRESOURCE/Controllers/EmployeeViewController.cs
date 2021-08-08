using Microsoft.AspNetCore.Mvc;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class EmployeeViewController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/EmployeeView/EmployeeView.cshtml");
        }
    }
}
