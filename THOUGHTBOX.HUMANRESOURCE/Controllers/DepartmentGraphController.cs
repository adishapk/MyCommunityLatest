using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class DepartmentGraphController : Controller
    {
        private IDepartmentGraphService _departmentGraphService;
        public DepartmentGraphController(IDepartmentGraphService departmentGraphService)
        {
            this._departmentGraphService = departmentGraphService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetDepartmentGraphs(string company, string reqType)
        {
            try
            {
                return Json(this._departmentGraphService.GetDepartmentGraphs(company,reqType));
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
        public JsonResult GetDepartmentSubGraphStatus(string reqId,string Dtype)
        {
            try
            {
                return Json(this._departmentGraphService.GetDepartmentSubGraphStatus(reqId,Dtype));
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
        public JsonResult GetDepartmentSubGraphByEmp(string empId,string status,string reqType)
        {
            try
            {
                if (empId == "-1")
                {
                    empId = HttpContext.Session.GetInt32("emloyeeId").ToString();
                }
                return Json(this._departmentGraphService.GetDepartmentSubGraphByEmp(empId,status,reqType));
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

        public JsonResult GetDHDepartmentGraphs(string Dtype,string reqType)
        {
            try
            {
                int empId=  Convert.ToInt32(HttpContext.Session.GetInt32("emloyeeId").ToString());
                return Json(this._departmentGraphService.GetDHDepartmentGraphs(empId,Dtype,reqType));
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
