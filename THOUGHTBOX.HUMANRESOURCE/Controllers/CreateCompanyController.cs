using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateCompanyController : Controller
    {
        private ICreateCompanyService _createCompanyService;
        public CreateCompanyController(ICreateCompanyService createCompanyService)
        {
            _createCompanyService = createCompanyService;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateCompany/CreateCompany.cshtml");
        }
        public int CompanyInsert(CreateCompanyDomain companyvalues)
        {
            try
            {
                return _createCompanyService.companyinsert(companyvalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult SelectAllcompany(int checkval)
        {
            try
            {
                return Json(_createCompanyService.getallcompany(checkval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int companyupdate(CreateCompanyDomain companyupdate)
        {
            try
            {
                return _createCompanyService.companyupdate(companyupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletingcompany(int Idcomp)
        {
            try
            {
                return _createCompanyService.companydelete(Idcomp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult getallcomp(int companyget)
        {
            try
            {
                return Json(_createCompanyService.getallcompanyfordd(companyget));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

}
