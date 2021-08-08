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
    public class ApprovalRequestController : Controller
    {
        TempStore tmpst = new TempStore();

        public IActionResult Index()
        {
            return View("~/Views/ApprovalRequest/ApprovalRequest.cshtml");
        }

        public IActionResult ApprovalRequest(int requestid)
        {
            tmpst.custid = requestid;
            return View(tmpst);
        }
    }
}
