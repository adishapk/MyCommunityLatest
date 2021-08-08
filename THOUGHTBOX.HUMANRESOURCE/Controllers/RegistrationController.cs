using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class RegistrationController : Controller
    {
        private IRegistration _registration;
        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }
        public IActionResult Index()
        {
            return View("~/Views/Registration/Registration.cshtml");
        }
        public JsonResult usernameget(string user_name)
        {
            try
            {
                return Json(_registration.sgetuser(user_name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult emailget(string email_id)
        {
            try
            {
                return Json(_registration.sgetemail(email_id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int RegInsert(RegistrationDomain Registration)
        {
            try
            {
                return _registration.sreginsert(Registration);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
