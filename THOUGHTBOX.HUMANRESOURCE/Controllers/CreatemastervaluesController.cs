using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreatemastervaluesController : Controller
    {
        private IMastertypeServicce _createmastertype;
        public CreatemastervaluesController(IMastertypeServicce createmastertype)
        {
            _createmastertype = createmastertype;
        }
        public IActionResult Index()
        {
            return View("~/Views/Createmastervalues/Createmastervalues.cshtml");
        }
        public JsonResult mastertypeget(int mastervalget)
        {
            try
            {
                return Json(_createmastertype.sgetcreatemastertype(mastervalget));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int mastervaluesInsert(MastertypeDomain mastervalues)
        {
            try
            {
                return _createmastertype.smastervaluesinsert(mastervalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Mastervaluesupdate(MastertypeDomain Mastervalueup)
        {
            try
            {
                return _createmastertype.smastervalueupdate(Mastervalueup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllmastervalues(int checkval)
        {
            try
            {
                return Json(_createmastertype.sgetfullmastervalues(checkval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingmastervalues(int Idmastervalues)
        {
            try
            {
                return _createmastertype.smastervaluedeleting(Idmastervalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult Getspecificmastervalues(string checkfield)
        {
            try
            {
                return Json(_createmastertype.Getspecificmastervalues(checkfield));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
