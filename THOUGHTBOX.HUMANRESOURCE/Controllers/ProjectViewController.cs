using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class ProjectViewController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ProjectView/ProjectView.cshtml");
        }
    }
}