using Microsoft.AspNetCore.Mvc;
using System;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateCustomerController : Controller
    {
        private ICreateCustomerService _createCustomerService;
        public CreateCustomerController(ICreateCustomerService createCustomerService)
        {
            _createCustomerService = createCustomerService;
        }


        public IActionResult Index()
        {
            return View("~/Views/CreateCustomer/CreateCustomer.cshtml");
        }
        public int CustomerInsert(CreateCustomerDomain customervalues)
        {
            try
            {
                return _createCustomerService.custinsert(customervalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult SelectAllcustomer(int custval)
        {
            try
            {
                return Json(_createCustomerService.getallcustomer(custval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult getassociate(string idval)
        {
            try
            {
                return Json(_createCustomerService.getallassociate(idval));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int customerupdate(CreateCustomerDomain Customervalupdate)
        {
            try
            {
                return _createCustomerService.custupdate(Customervalupdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public int Deletingcustmrvalues(int Idcustomervalues)
        {
            try
            {
                return _createCustomerService.customerdelete(Idcustomervalues);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
