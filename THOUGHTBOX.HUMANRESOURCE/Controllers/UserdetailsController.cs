using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class UserdetailsController : Controller
    {
        private IUserdetailsService _userdetailsService;
        public UserdetailsController(IUserdetailsService userdetailsService)
        {
            _userdetailsService = userdetailsService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Userdetails/Userdetails.cshtml");
        }
        public JsonResult SelectAlluserdetails(int userval)
        {
            try

            {
                return Json(_userdetailsService.sgetalluserdetails(userval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int uservaluesInsert(UserdetailsDomain uservalues)
        {
            try

            {
                return _userdetailsService.suserdetailsinsert(uservalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int uservaluesupdate(UserdetailsDomain uservaluesup)
        {
            try
            {
                return _userdetailsService.suserdetailupdate(uservaluesup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletinguservalues(int Iduservalues)
        {
            try
            {
                return _userdetailsService.suserdetailsdelete(Iduservalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getusername(string userget)
        {
            try
            {
                return _userdetailsService.getusername(userget);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
