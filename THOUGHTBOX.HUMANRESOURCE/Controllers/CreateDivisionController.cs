using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateDivisionController : Controller
    {
        private ICreateDivision _createDivision;
        public CreateDivisionController(ICreateDivision createDivision)
        {
            _createDivision = createDivision;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateDivision/CreateDivision.cshtml");
        }
        public int divisionInsert(CreateDivisionDomain divisnvalues)
        {
            try
            {
                return _createDivision.divisioninsert(divisnvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAlldivisn(int divival)
        {
            try
            {
                return Json(_createDivision.getalldivisn(divival));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int divisionupdate(CreateDivisionDomain divisnupdate)
        {
            try
            {
                return _createDivision.divisnupdate(divisnupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletingdivisn(int Iddivisn)
        {
            try
            {
                return _createDivision.divisndelete(Iddivisn);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
