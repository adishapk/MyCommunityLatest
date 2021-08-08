using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using Microsoft.AspNetCore.Http;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class LoginController : Controller
    {
        private IRegistration _registration;
        public LoginController(IRegistration registration)
        {
            _registration = registration;
        }
        public IActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }
        public JsonResult getlogin(UserdetailsDomain userdetailsDomain)
        {
            try
            {
                string em_user = userdetailsDomain.user_name;
                string pass_word = userdetailsDomain.user_password; ;
                IList<UserdetailsDomain> LoginDetails = _registration.sgetlogin(em_user, pass_word);

                if (LoginDetails[0].user_id != -1)
                {
                   
                    HttpContext.Session.SetString("userName", LoginDetails[0].user_name);
                    HttpContext.Session.SetString("employeeName", LoginDetails[0].employee_name);
                    HttpContext.Session.SetString("employeeImage", LoginDetails[0].employee_image);                    
                    HttpContext.Session.SetInt32("emloyeeId", LoginDetails[0].employee_id);
                    HttpContext.Session.SetInt32("userTypeId", LoginDetails[0].user_type_id);
                    HttpContext.Session.SetInt32("userId", LoginDetails[0].user_id);                   

                    if (LoginDetails[0].employee_id == 0)
                    {
                        HttpContext.Session.SetString("layoutName", "~/Views/Shared/_AdminLayout.cshtml");
                    }
                    else
                    {
                        HttpContext.Session.SetString("layoutName", "~/Views/Shared/" + LoginDetails[0].user_layout);
                    }

                }

                return Json(LoginDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
