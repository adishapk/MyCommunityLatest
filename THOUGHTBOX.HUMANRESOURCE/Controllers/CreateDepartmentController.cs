using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateDepartmentController : Controller
    {
        private ICreateDepartmentService _createDepartmentService;
        public CreateDepartmentController(ICreateDepartmentService createDepartmentService)
        {
            _createDepartmentService = createDepartmentService;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateDepartment/CreateDepartment.cshtml");
        }
        public int departmentInsert(CreateDepartmentDomain deptvalues)
        {
            try
            {
                return _createDepartmentService.departmentinsert(deptvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int departmntupdate(CreateDepartmentDomain departmentupdate)
        {
            try
            {
                return _createDepartmentService.departmentupdate(departmentupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletingdepart(int Iddepart)
        {
            try
            {
                return _createDepartmentService.departmentdelete(Iddepart);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public JsonResult SelectAlldepart(int deptval)
        {
            try
            {
                return Json(_createDepartmentService.getalldepartment(deptval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult getalldepart(int departget)
        {
            try
            {
                return Json(_createDepartmentService.getalldepartmentdd(departget));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
