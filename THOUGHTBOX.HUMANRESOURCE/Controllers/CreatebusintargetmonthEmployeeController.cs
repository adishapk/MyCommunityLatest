using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreatebusintargetmonthEmployeeController : Controller
    {
        private ICreatebusintargetmonthEmployeeService _createbusintargetmonthEmployeeService;
        public CreatebusintargetmonthEmployeeController (ICreatebusintargetmonthEmployeeService createbusintargetmonthEmployeeService)
        {
            _createbusintargetmonthEmployeeService = createbusintargetmonthEmployeeService;
        }

        public IActionResult Index()
        {
            return View("~/Views/CreatebusintargetmonthEmployee/CreatebusintargetmonthEmployee.cshtml");
        }
        public int mnthlytargetempInsert (CreatebusintargetmonthEmployeeDomain empmontargetvalues)
        {
            try
            {
                return _createbusintargetmonthEmployeeService.empmonthtargetinsert(empmontargetvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAllempmonthtarget(int empmontargetval)
        {
            try
            {
                return Json(_createbusintargetmonthEmployeeService.getallempmonthtrgt(empmontargetval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getemptargtmonth (int target,string monthid,int selectemploy)
        {
            try
            {
                return _createbusintargetmonthEmployeeService.getemptargtmonth(target, monthid, selectemploy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int mnthlytargetempupdate(CreatebusintargetmonthEmployeeDomain empmonthtargetupdate)
        {
            try
            {
                return _createbusintargetmonthEmployeeService.empmonthtargetupdate(empmonthtargetupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletingtarget(int Idtarget, string Idmnth, int Idemp)
        {
            try
            {
                return _createbusintargetmonthEmployeeService.empmonthtargetdelete(Idtarget, Idmnth, Idemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
