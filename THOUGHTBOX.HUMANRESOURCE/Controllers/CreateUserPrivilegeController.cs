using System;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.HUMANRESOURCE.Models;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateUserPrivilegeController : Controller
    {
        private ICreateUserService _CreateUserService;
        Log Log = new Log();
        public CreateUserPrivilegeController(ICreateUserService CreateUserService)
        {
            _CreateUserService = CreateUserService;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateUserPrivilege/CreateUserPrivilege.cshtml");
        }

        public JsonResult GetUsers()
        {
            try
            {
                return Json(this._CreateUserService.GetUsers());
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString().Trim());
            }
            finally
            {
                //
            }
        }
        public JsonResult GetSelectedUserTypePrvileges(int userTypeId,string previlege_type)
        {
            try
            {
                return Json(this._CreateUserService.GetSelectedUserTypePrvileges(userTypeId,previlege_type));
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString().Trim());
            }
            finally
            {
                //
            }
        } 
        public JsonResult SelectedUserPrvileges(int userTypeId,string previlege_type)
        {
            try
            {
                return Json(this._CreateUserService.GetSelectedUserTypePrvileges(userTypeId,previlege_type));
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString().Trim());
            }
            finally
            {
                //
            }
        }
    }
}
