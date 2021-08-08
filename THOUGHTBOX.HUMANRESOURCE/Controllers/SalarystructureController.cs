using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class SalarystructureController : Controller
    {
        private ISalarystructureService _salarystructureService;
        public SalarystructureController(ISalarystructureService salarystructureService)
        {
            _salarystructureService = salarystructureService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Salarystructure/Salarystructure.cshtml");
        }
        public int salrystructureInsert(salarystructuredomain salaryvalues)
        {
            try
            {
                return _salarystructureService.ssalrystructinsert(salaryvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int salrystructureupdate(salarystructuredomain salaryvalueup)
        {
            try
            {
                return _salarystructureService.ssalrystructupdate(salaryvalueup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllsalstruct(int salrystructval)
        {
            try
            {
                return Json(_salarystructureService.sgetsalarystructure(salrystructval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Deletingsalarystruct(int Idsalrystruct)
        {
            try
            {
                return _salarystructureService.ssalrystructdelete(Idsalrystruct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
