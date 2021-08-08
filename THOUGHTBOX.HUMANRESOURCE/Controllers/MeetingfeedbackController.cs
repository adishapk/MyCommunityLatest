using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.HUMANRESOURCE.Models;
using Microsoft.AspNetCore.Http;


namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class MeetingfeedbackController : Controller
    {
        TempStore tmpst = new TempStore();

        public IActionResult Index()
        {
            return View("~/Views/Meetingfeedback/Meetingfeedback.cshtml");
        }

        public IActionResult Meetingfeedback(int requestid)
        {
            tmpst.custid = requestid;
            return View(tmpst);
        }

    }
}
