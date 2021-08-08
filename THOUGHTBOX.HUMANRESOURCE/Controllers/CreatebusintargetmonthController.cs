using System;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;


namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreatebusintargetmonthController : Controller
    {
        private ICreatebusintargetmonthService _createbusintargetmonthService;
        public CreatebusintargetmonthController(ICreatebusintargetmonthService createbusintargetmonthService)
        {
            _createbusintargetmonthService = createbusintargetmonthService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Createbusintargetmonth/Createbusintargetmonth.cshtml");
        }
        public int mnthlytargetInsert(Createbusintargetmonth montargetvalues)
        {
            try
            {
                return _createbusintargetmonthService.monthtargetinsert(montargetvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAllmonthtarget(int montargetval)
        {
            try
            {
                return Json(_createbusintargetmonthService.getallmonthtrgt(montargetval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public JsonResult gettargetmonth (int target, string monthid)
        {
            try
            {
                return Json(_createbusintargetmonthService.getamonthtrgt(target, monthid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int montargetupdate(Createbusintargetmonth monthtargetupdate)
        {
            try
            {
                return _createbusintargetmonthService.monthtargetupdate(monthtargetupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingmonthtarget (int Idmontarget, string Idmonth)
        {
            try
            {
                return _createbusintargetmonthService.monthtargetdelete(Idmontarget, Idmonth);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
