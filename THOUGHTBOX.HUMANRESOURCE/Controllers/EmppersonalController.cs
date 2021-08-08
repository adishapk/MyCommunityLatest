using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using Microsoft.AspNetCore.Http;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class EmppersonalController : Controller
    {
        private IEmppersonalService _emppersonalService;
        private IHostingEnvironment _hostingEnvironment;
        private ISalarystructureService _salarystructureService;
        public EmppersonalController(IEmppersonalService emppersonalService, IHostingEnvironment hostingEnvironment, ISalarystructureService salarystructureService)
        {
            _emppersonalService = emppersonalService;
            _hostingEnvironment = hostingEnvironment;
            _salarystructureService = salarystructureService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Emppersonal/Emppersonal.cshtml");
        }
        public int PersonaldetailsInsert()
        {

            try
            {
                EmppersonalDomain empdet = new EmppersonalDomain();
                EmpsalaryDomain empsal = new EmpsalaryDomain();

                empdet.emp_reportedto = Convert.ToInt32(Request.Form["emp_reportedto"].ToString());
                empdet.emp_firstname = Request.Form["firstname"].ToString();
                empdet.emp_lastname = Request.Form["lastname"].ToString();
                empdet.emp_code = Request.Form["empcode"].ToString();
                empdet.emp_cardno = Request.Form["cardno"].ToString();
                empdet.emp_mobileno = Request.Form["mobno"].ToString() == null ? "" : Request.Form["mobno"].ToString();
                empdet.emp_status = Request.Form["status"].ToString();
                empdet.emp_dob = Request.Form["birthdate"].ToString() == null ? "" : Request.Form["birthdate"].ToString();
                empdet.emp_nationality = Convert.ToInt32(Request.Form["nation"].ToString() == "" ? "0" : Request.Form["nation"].ToString());
                empdet.emp_designation = Convert.ToInt32(Request.Form["design"].ToString() == "" ? "0" : Request.Form["design"].ToString());
                empdet.emp_dojoin = Request.Form["joindte"].ToString() == null ? "" : Request.Form["joindte"].ToString();
                empdet.emp_qid = Request.Form["qidno"].ToString();
                empdet.emp_qidexpiry = Request.Form["qidxp"].ToString();
                empdet.emp_healthcardid = Request.Form["hlthid"].ToString();
                empdet.emp_hcardexpiry = Request.Form["hthidxp"].ToString();
                empdet.emp_ppno = Request.Form["psprtno"].ToString();
                empdet.emp_ppexpiry = Request.Form["psprtxp"].ToString();
                empdet.emp_photo = Request.Form["empphoto"].ToString() == null ? "" : Request.Form["empphoto"].ToString();
                empdet.totalsalary = Request.Form["emp_totalsalary"].ToString() == null ? "" : Request.Form["emp_totalsalary"].ToString();
                empdet.emp_grosssalary = Request.Form["emp_grosssalary"].ToString() == null ? "" : Request.Form["emp_grosssalary"].ToString();
                empdet.emp_totaldeductions = Request.Form["emp_totaldeductions"].ToString() == null ? "" : Request.Form["emp_totaldeductions"].ToString();

                empsal.salaryheadsad = Request.Form["salaryheadsad"];
                empsal.salaryheadsded = Request.Form["salaryheadsded"];
                empsal.salaryamountad = Request.Form["salaryamountad"];
                empsal.salaryamountded = Request.Form["salaryamountded"];
                empsal.addcount = Request.Form["addcount"];
                empsal.dedcount = Request.Form["dedcount"];

                empsal.sal_from_date = Request.Form["sal_from_date"];
                empsal.sal_to_date = Request.Form["sal_to_date"];
                empsal.entry_date = Request.Form["entry_date"];

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
                        empdet.emp_photo = newfilename1;
                    }

                }
                return _emppersonalService.semppersonalinsert(empdet, empsal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int personaldetailsUpdate()
        {

            try
            {
                EmppersonalDomain empdet = new EmppersonalDomain();
                EmpsalaryDomain empsal = new EmpsalaryDomain();

                empdet.employee_id = Convert.ToInt32(Request.Form["employee_id"].ToString());
                empdet.emp_reportedto = Convert.ToInt32(Request.Form["emp_reportedto"].ToString());
                empdet.emp_firstname = Request.Form["firstname"].ToString();
                empdet.emp_lastname = Request.Form["lastname"].ToString();
                empdet.emp_code = Request.Form["empcode"].ToString();
                empdet.emp_cardno = Request.Form["cardno"].ToString();
                empdet.emp_mobileno = Request.Form["mobno"].ToString() == null ? "" : Request.Form["mobno"].ToString();
                empdet.emp_status = Request.Form["status"].ToString();
                empdet.emp_dob = Request.Form["birthdate"].ToString() == null ? "" : Request.Form["birthdate"].ToString();
                empdet.emp_nationality = Convert.ToInt32(Request.Form["nation"].ToString() == "" ? "0" : Request.Form["nation"].ToString());
                empdet.emp_designation = Convert.ToInt32(Request.Form["design"].ToString() == "" ? "0" : Request.Form["design"].ToString());
                empdet.emp_dojoin = Request.Form["joindte"].ToString() == null ? "" : Request.Form["joindte"].ToString();
                empdet.emp_qid = Request.Form["qidno"].ToString();
                empdet.emp_qidexpiry = Request.Form["qidxp"].ToString();
                empdet.emp_healthcardid = Request.Form["hlthid"].ToString();
                empdet.emp_hcardexpiry = Request.Form["hthidxp"].ToString();
                empdet.emp_ppno = Request.Form["psprtno"].ToString();
                empdet.emp_ppexpiry = Request.Form["psprtxp"].ToString();
                empdet.emp_photo = Request.Form["emp_photohide"].ToString() == null ? "" : Request.Form["emp_photohide"].ToString();
                empdet.totalsalary = Request.Form["emp_totalsalary"].ToString() == null ? "" : Request.Form["emp_totalsalary"].ToString();
                empdet.emp_grosssalary = Request.Form["emp_grosssalary"].ToString() == null ? "" : Request.Form["emp_grosssalary"].ToString();
                empdet.emp_totaldeductions = Request.Form["emp_totaldeductions"].ToString() == null ? "" : Request.Form["emp_totaldeductions"].ToString();

                empsal.salaryheadsad = Request.Form["salaryheadsad"];
                empsal.salaryheadsded = Request.Form["salaryheadsded"];
                empsal.salaryamountad = Request.Form["salaryamountad"];
                empsal.salaryamountded = Request.Form["salaryamountded"];
                empsal.addcount = Request.Form["addcount"];
                empsal.dedcount = Request.Form["dedcount"];

                empsal.sal_from_date = Request.Form["sal_from_date"];
                empsal.sal_to_date = Request.Form["sal_to_date"];
                empsal.entry_date = Request.Form["entry_date"];

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
                        empdet.emp_photo = newfilename1;
                    }

                }
                return _emppersonalService.semppersonalupdate(empdet, empsal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllpersonalvalues(int personalval)
        {
            try
            {
                return Json(_emppersonalService.sgetallemppersonl(personalval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult Getallsalarydetails(int empid, string Transtype)
        {
            try
            {
                return Json(_emppersonalService.Getsalarystructure(empid, Transtype));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingempperson(int Idempperson)
        {
            try
            {
                return _emppersonalService.semppersonaldelete(Idempperson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult getEmployee(int idval)
        {
            try
            {
                return Json(_emppersonalService.sgetemployee(idval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetEmployeeforempview(int idval)
        {
            try
            {
                return Json(_emppersonalService.GetEmployeeforempview(idval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult Getsalarystructure(string Sub_node)
        {
            try
            {
                return Json(_salarystructureService.Getsalarystructure(Sub_node));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult getEmployeereportedto(int idval)
        {
            try
            {
                idval = Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId").ToString());
                return Json(_emppersonalService.getEmployeereportedto(idval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
