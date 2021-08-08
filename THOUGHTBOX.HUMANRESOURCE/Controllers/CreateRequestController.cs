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
    public class CreateRequestController : Controller
    {
        private ICreateRequestService _createRequestService;
        private IHostingEnvironment _hostingEnvironment;
        private IGeneralService _generalService;
      
        public CreateRequestController(ICreateRequestService createRequestService, IHostingEnvironment hostingEnvironment,IGeneralService generalService)
        {
            _createRequestService = createRequestService;
            _hostingEnvironment = hostingEnvironment;
            _generalService = generalService;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateRequest/CreateRequest.cshtml");
        }
        public int requestInsert()
        {

            try
            {
                Generaldomain gdomain = new Generaldomain();
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
                CreateRequest empdet = new CreateRequest();

                empdet.request_title = Request.Form["reqttitle"].ToString();
                empdet.request_date = Request.Form["rqstdate"].ToString();
                empdet.request_priority = Request.Form["priortytype"].ToString();
                empdet.request_details = Request.Form["rqstdetails"].ToString() == null ? "" : Request.Form["rqstdetails"].ToString();
                empdet.user_comments = Request.Form["user_comments"].ToString() == null ? "" : Request.Form["user_comments"].ToString();
                empdet.request_image = Request.Form["image"].ToString();
                empdet.requested_date = currentdate;
                empdet.requested_time = currenttime;
                empdet.request_code = Request.Form["request_code"].ToString();
                empdet.appliedby_id = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));


                gdomain = _generalService.GetGeneralValuesFromAnyTableTT("Designation", "MD","tbl_mark_emppersonnel", "employee_id", "emp_firstname", "emp_designation", "NIL", "NIL", "NIL", "VAL");
                empdet.approvedby_id = gdomain.Generalval1;
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
                        empdet.request_image = newfilename1;
                    }

                }
                return _createRequestService.requestinsert(empdet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult GetJobCard(string Cust_Type)
        {
            try
            {
                return Json(_createRequestService.getautonumber(Cust_Type));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllrequest(int requestval)
        {
            try
            {
                return Json(_createRequestService.getallrequest(requestval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAlljoballocate(int requestval)
        {
            try
            {
                return Json(_createRequestService.getalljoballoc(requestval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAlljoballocateEmp(int requestval)
        {
            try
            {
                return Json(_createRequestService.getalljoballocEmp(requestval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingrequest(int Idrequst)
        {
            try
            {
                return _createRequestService.requestdelete(Idrequst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int approvalupdate()
        {
            try
            {
                Generaldomain gdomain = new Generaldomain();

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

                CreateRequest empdet = new CreateRequest();

                empdet.request_id = Convert.ToInt32(Request.Form["rqstid"].ToString());
                empdet.request_stdate = Request.Form["jobstrtdate"].ToString();
                empdet.request_eddate = Request.Form["jobenddate"].ToString();
                empdet.request_apcomments = Request.Form["aprvcomnts"].ToString();
                empdet.request_priority = Request.Form["priortytype"].ToString();
                empdet.request_title = Request.Form["reqttitle"].ToString();
                empdet.request_code = Request.Form["request_code"].ToString();

                empdet.request_appimage = Request.Form["appimage"].ToString();
                empdet.request_apdate = currentdate;
                empdet.request_aptime = currenttime;
                empdet.request_status = "Approved";
                empdet.appliedby_id = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));

                gdomain = _generalService.GetGeneralValuesFromAnyTableTT("Designation", "Business Development Manager", "tbl_mark_emppersonnel", "employee_id", "emp_firstname", "emp_designation", "NIL", "NIL", "NIL", "VAL");
                empdet.approvedby_id = gdomain.Generalval1;
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
                        empdet.request_appimage = newfilename1;
                    }

                }
                return _createRequestService.reqaprveupdate(empdet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int verifyupdate()
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

                CreateRequest empdet = new CreateRequest();

                empdet.request_id = Convert.ToInt32(Request.Form["rqstid"].ToString());
                empdet.request_vericomments = Request.Form["request_vericomments"].ToString();
                empdet.request_veriimage = Request.Form["request_veriimage"].ToString();
                empdet.request_title = Request.Form["reqttitle"].ToString();
                empdet.request_code = Request.Form["request_code"].ToString();
                empdet.request_apdate = currentdate;
                empdet.request_aptime = currenttime;
                empdet.request_status = "Verified";
                empdet.appliedby_id = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId"));

                empdet.approvedby_id = _generalService.GetdeptheadID(Convert.ToInt32(Request.Form["rqstid"].ToString()), "Department Request", Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId").ToString()));
                
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
                        empdet.request_veriimage = newfilename1;
                    }

                }
                return _createRequestService.reqverifyupdate(empdet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
