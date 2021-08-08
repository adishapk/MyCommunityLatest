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
    public class RequestfeedbackController : Controller
    {
        TempStore tmpst = new TempStore();
        private IHostingEnvironment _hostingEnvironment;
        private IRequestfeedbackService _requestfeedbackService;

        public RequestfeedbackController(IHostingEnvironment hostingEnvironment, IRequestfeedbackService requestfeedbackService)
        {
            _hostingEnvironment = hostingEnvironment;
            _requestfeedbackService = requestfeedbackService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Requestfeedback/Requestfeedback.cshtml");
        }

        public IActionResult Requestfeedback(int requestid)
        {
            tmpst.custid = requestid;
            return View(tmpst);
        }

        public int feedbackempInsert()
        {
            try
            {
                //To get current date and time can use following function
                Server_Time tym1 = new Server_Time();
                string day2 = (Convert.ToInt32(tym1.GetDay())).ToString();

                if (day2.Length == 1)
                {
                    day2 = "0" + day2;
                }

                string month1 = tym1.GetMonth();
                string year1 = tym1.GetYear();

                string currentdate = day2 + "/" + month1 + "/" + year1;

                string mmyyyy = month1 + "/" + year1;
                string Hr1 = tym1.GetHour();
                string Mt1 = tym1.GetMinute();
                string Sec1 = tym1.GetSecond();

                string currenttime = Hr1 + ":" + Mt1 + ":" + Sec1;
                Requestfeedbackdomain requestfeedback = new Requestfeedbackdomain();

                requestfeedback.request_id = Convert.ToInt32(Request.Form["request_id"].ToString());
                requestfeedback.feedback_date_userentry = Request.Form["feedback_date_userentry"].ToString();
                requestfeedback.feedback_comments = Request.Form["feedback_comments"].ToString();
                requestfeedback.feedback_image = Request.Form["feedback_image"].ToString();
                requestfeedback.feedback_date = currentdate;
                requestfeedback.feedback_time = currenttime;
                requestfeedback.employee_id = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));

                long size = 0;
                var sss = Request.Form.Files;

                if (sss.Count > 0)
                {
                    var filename = ""; var filename1 = ""; string newfilename = ""; string newfilename1 = "";
                    foreach (var file in sss)
                    {
                        var random = RandomNumberGenerator.Create();
                        var bytes = new byte[sizeof(int)]; // 4 bytes
                        random.GetNonZeroBytes(bytes);
                        var result = BitConverter.ToInt32(bytes);
                        // var upname = file.Name;
                        var upname = "";

                        newfilename = ""; newfilename1 = "";
                        newfilename = _hostingEnvironment.WebRootPath + $@"\Webimages\Employee\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + result + ".";
                        newfilename1 = $@"/Webimages/Employee/" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + result + ".";
                        filename = ""; filename1 = "";
                        filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filename1 = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filename = _hostingEnvironment.WebRootPath + $@"\Webimages\EmployeeB" + $@"\{ filename}";
                        size += file.Length;
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        string[] ext = filename1.Split(char.Parse("."));
                        newfilename += $@"{ ext[1]}";
                        newfilename1 += $@"{ ext[1]}";
                        System.IO.File.Copy(filename, newfilename, true);
                        System.IO.File.Delete(filename);
                        upname = file.Name;
                        requestfeedback.feedback_image = newfilename1;
                    }

                }
                return _requestfeedbackService.feedbackempInsert(requestfeedback);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}