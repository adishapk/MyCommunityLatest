using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreatebusintargetyearController : Controller
    {
        private ICreatebusintargetyearService _createbusintargetyearService;
        public CreatebusintargetyearController (ICreatebusintargetyearService createbusintargetyearService)
        {
            _createbusintargetyearService = createbusintargetyearService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Createbusintargetyear/Createbusintargetyear.cshtml");
        }
        public int targetInsert(CreatebusintargetyearDomain targetvalues)
        {
            try
            {
                return _createbusintargetyearService.targetinsert(targetvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAlltarget(int targetval)
        {
            try
            {
                return Json(_createbusintargetyearService.getalltarget(targetval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int bustargetupdate(CreatebusintargetyearDomain targetupdate)
        {
            try
            {
                return _createbusintargetyearService.targetupdate(targetupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletingtarget(int Idtarget)
        {
            try
            {
                return _createbusintargetyearService.targetdelete(Idtarget);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult getalltarget(string targetyear, int compid, int departid)
        {
            try
            {
                return Json (_createbusintargetyearService.gettargetyear(targetyear, compid, departid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult getyeartarget (int targetid)
        {
            try
            {
                return Json (_createbusintargetyearService.getallyeartarget(targetid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
