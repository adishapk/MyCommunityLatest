using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using Microsoft.AspNetCore.Http;
using THOUGHTBOX.HUMANRESOURCE.Models;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class ApprovalRequestBDMController : Controller
    {
        TempStore tmpst = new TempStore();

        public IActionResult Index()
        {
            return View("~/Views/ApprovalRequestBDM/ApprovalRequestBDM.cshtml");
        }

        public IActionResult ApprovalRequestBDM(int requestid)
        {
            tmpst.custid = requestid;
            return View(tmpst);
        }

    }
}