using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
   public class Createbusintargetmonth
    {
        public int target_id { get; set; }
        public int company_id { get; set; }
        public int department_id { get; set; }
        public string tgtyear_month { get; set; }
        public string tgtyearmonth_amt { get; set; }
    }
}
