using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class MastertypeController : Controller
    {
        private IMastertypeServicce _mastertypeServicce;
        public MastertypeController(IMastertypeServicce mastertypeServicce)
        {
            _mastertypeServicce = mastertypeServicce;
        }
        public IActionResult Index()
        {
            return View("~/Views/Mastertype/Mastertype.cshtml");
        }
        public int mastertypeInsert(MastertypeDomain Mastername)
        {
            try
            {
                return _mastertypeServicce.smastertypeinsert(Mastername);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Mastertypeupdate(MastertypeDomain Masterupname)
        {
            try
            {
                return _mastertypeServicce.smastertypeupdate(Masterupname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllmastertype(int selectmaster)
        {
            try
            {
                return Json(_mastertypeServicce.sgetfullmastertype(selectmaster));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingmastertype(int Idmastertype)
        {
            try
            {
                return _mastertypeServicce.smastertypedeleting(Idmastertype);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
