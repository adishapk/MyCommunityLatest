using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using Microsoft.AspNetCore.Http;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class DashboardDHController : Controller
    {
        private IGeneralService _generalservice;

        public DashboardDHController(IGeneralService generalservice)
        {
            _generalservice = generalservice;

        }

        public IActionResult Index()
        {
            return View("~/Views/DashboardDH/DashboardDH.cshtml");
        }
    }
}