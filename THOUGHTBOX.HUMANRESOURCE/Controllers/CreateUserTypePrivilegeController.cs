using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.HUMANRESOURCE.Models;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateUserTypePrivilegeController : Controller
    {
        private ICreateUserService _createUserTypePrivilegeService;     
        Log Log = new Log();
        public CreateUserTypePrivilegeController(ICreateUserService createUserTypePrivilegeService)
        {
            this._createUserTypePrivilegeService = createUserTypePrivilegeService;           
        }
        public IActionResult Index()
        {            
           return View("~/Views/CreateUserTypePrivilege/CreateUserTypePrivilege.cshtml");
        }

        public JsonResult GetUserType()
        {
            try
            {
                return Json(this._createUserTypePrivilegeService.GetUserType("", "UserType"));
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
        public JsonResult GetPrivilegeRoles()
        {
            try
            {  
                    return Json(this._createUserTypePrivilegeService.GetRoles());                
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

        public int checkDuplication(string col, string tbl, string cond, string para)
        {
            return this._createUserTypePrivilegeService.checkDuplication(col, tbl, cond, para);
        }
        public JsonResult SelectPrvileges(string previlege_type)
        {
            try
            {
                return Json(this._createUserTypePrivilegeService.SelectPrvileges(previlege_type));
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
        public bool InsertPrivilege(IList<UserType> userTypes,int count, string previlege_type)
        {
            try
            {
                return this._createUserTypePrivilegeService.InsertPrivilege(userTypes,count,previlege_type);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //
            }
        }
        public bool UpdateUserTypePrivilege(IList<UserType> userTypes, int count, string previlege_type)
  
        {
            try
            {
                return this._createUserTypePrivilegeService.UpdateUserTypePrivilege(userTypes,count,previlege_type);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //
            }
        }

        public bool Delete(int Id,string previlege_type)
        {
            try
            {
                return this._createUserTypePrivilegeService.DeletePrivilege(Id,previlege_type);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
