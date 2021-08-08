using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class CreateMenuController : Controller
    {
        private IMastertypeServicce _mastertypeServicce;
        public CreateMenuController(IMastertypeServicce mastertypeServicce)
        {
            _mastertypeServicce = mastertypeServicce;
        }
        public IActionResult Index()
        {
            return View("~/Views/CreateMenu/CreateMenu.cshtml");
        }
        public int insertMenu(MastertypeDomain Mastername)
        {
            try
            {
                return _mastertypeServicce.insertMenu(Mastername);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateMenu(MastertypeDomain Mastername)
        {
            try
            {
                return _mastertypeServicce.updateMenu(Mastername);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JsonResult selectAllMenu(string condition)
        {
            try
            {
                return Json(_mastertypeServicce.selectAllMenu(condition));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int deleteMenu(int Id)
        {
            try
            {
                return _mastertypeServicce.deleteMenu(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
