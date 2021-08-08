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
    public class AllocateEmployeesController : Controller
    {
        TempStore tmpst = new TempStore();
        private IAllocateEmployeesService _allocateEmployeesService;
        private IHostingEnvironment _hostingEnvironment;

        public AllocateEmployeesController(IAllocateEmployeesService allocateEmployeesService, IHostingEnvironment hostingEnvironment)
        {
            _allocateEmployeesService = allocateEmployeesService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View("~/Views/AllocateEmployees/AllocateEmployees.cshtml");
        }

        public IActionResult AllocateEmployees(int requestid)
        {
            tmpst.custid = requestid;
            return View(tmpst);
        }

        public int allocateempInsert()
        {
            try
            {
                AllocateEmployeesDomain allocateemp = new AllocateEmployeesDomain();
                CreateRequest createrequestdetails = new CreateRequest();

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

                allocateemp.request_id = Convert.ToInt32(Request.Form["request_id"].ToString());
                allocateemp.allemployeeids = Request.Form["allemployeeids"].ToString();
                allocateemp.allocated_comments = Request.Form["allocated_comments"].ToString();
                allocateemp.allocated_image = Request.Form["allocated_image"].ToString();
                allocateemp.allocated_date = currentdate;
                allocateemp.allocated_time = currenttime;

                createrequestdetails.request_title = Request.Form["reqttitle"].ToString();
                createrequestdetails.request_code = Request.Form["request_code"].ToString();
                createrequestdetails.request_status = "Finished";
                createrequestdetails.appliedby_id = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));

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
                        allocateemp.allocated_image = newfilename1;
                    }

                }

                return _allocateEmployeesService.allocateempinsert(allocateemp, createrequestdetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAllocateddetailsforempid(int requestval)
        {
            try
            {
                int empid = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));
                return Json(_allocateEmployeesService.SelectAllocateddetailsforempid(requestval, empid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
