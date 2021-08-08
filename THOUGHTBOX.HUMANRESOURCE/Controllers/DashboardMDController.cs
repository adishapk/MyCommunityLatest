using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using Microsoft.AspNetCore.Http;

namespace THOUGHTBOX.HUMANRESOURCE.Controllers
{
    public class DashboardMDController : Controller
    {
        private IGeneralService _generalservice;

        public DashboardMDController(IGeneralService generalservice)
        {
            _generalservice = generalservice;
          
        }

        public IActionResult Index()
        {
            return View("~/Views/DashboardMD/DashboardMD.cshtml");
        }


        public JsonResult fillallbucketinnerjoin(string Decivalue, string Fiename1, string Fiename2, string Fiename3, string Fiename4, string condfield1, string condfield2, string condfield3, string condval1, string condval2, string condval3, string Tblname1, string Tblname2, string Confield1, string Confield2)
        {
            try
            {
                    if (condval1 != "-2")
                {
                    condval1 = HttpContext.Session.GetInt32("emloyeeId").ToString();
                }

                return Json(_generalservice.fillallbucketinnerjoin(Decivalue, Fiename1, Fiename2, Fiename3, Fiename4, condfield1, condfield2, condfield3, condval1, condval2, condval3, Tblname1, Tblname2, Confield1, Confield2));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult fillallbucket(string Fiename1, string Fiename2, string Fiename3, string Fiename4, string condfield1, string condfield2, string condfield3, string condval1, string condval2, string condval3, string Tblname)
        {
            try
            {
              
                condval1 = HttpContext.Session.GetInt32("emloyeeId").ToString();
                return Json(_generalservice.fillallbucket(Fiename1, Fiename2, Fiename3, Fiename4, condfield1, condfield2, condfield3, condval1, condval2, condval3, Tblname));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult selectAllAccordioncount(string tablenam, string decisionvalu, string Fieldtoretriev1, string Fieldtoretriev2, string Fieldtoretriev3, string Fieldnam1, string Fieldnam2, string Fieldnam3, string Fieldnam4, string conditionfied1, string conditionfied2, string conditionfied3, string conditionfied4)
        {
            try
            {
                if (conditionfied1 != "-2")
                {
                    conditionfied1 = HttpContext.Session.GetInt32("emloyeeId").ToString();
                }
                return Json(_generalservice.getGeneraltwovalueresultfromanytablelist(tablenam, decisionvalu, Fieldtoretriev1, Fieldtoretriev2, Fieldtoretriev3, Fieldnam1, Fieldnam2, Fieldnam3, Fieldnam4, conditionfied1, conditionfied2, conditionfied3, conditionfied4));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}