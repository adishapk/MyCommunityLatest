using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.HUMANRESOURCE.Models;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreatealertsController : Controller
    {
        private ICreatealertsService _createalertsService;
        private IHostingEnvironment _hostingEnvironment;
        public CreatealertsController(ICreatealertsService createalertsService, IHostingEnvironment hostingEnvironment)
        {
            _createalertsService = createalertsService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View("~/Views/Createalerts/Createalerts.cshtml");
        }

        public int alertsUpdate()
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


                CreatealertsDomain alertdata = new CreatealertsDomain();

                alertdata.employee_id = Convert.ToInt32(Request.Form["employee"].ToString());
                alertdata.alert_id = Convert.ToInt32(Request.Form["alertid"].ToString());
                alertdata.alert_message = Request.Form["alertmsge"].ToString();
                alertdata.alert_videolink = Request.Form["video"].ToString();
                alertdata.alert_image = Request.Form["alertphoto"].ToString();
                alertdata.alert_time = currenttime;
                alertdata.alert_date = currentdate;


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
                        alertdata.alert_image = newfilename1;
                    }

                }
                return _createalertsService.alertupdate(alertdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int alertsInsert()
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


                CreatealertsDomain alertdata = new CreatealertsDomain();

                alertdata.employee_id = Convert.ToInt32(Request.Form["employee"].ToString());
                alertdata.alert_message = Request.Form["alertmsge"].ToString();
                alertdata.alert_videolink = Request.Form["video"].ToString();
                alertdata.alert_time = currenttime;
                alertdata.alert_date = currentdate;


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
                        alertdata.alert_image = newfilename1;
                    }

                }
                return _createalertsService.alertinsert(alertdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAllalerts(int checkval)
        {
            try
            {
                return Json(_createalertsService.getallalerts(checkval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingalerts(int Idalert)
        {
            try
            {
                return _createalertsService.alertdelete(Idalert);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
