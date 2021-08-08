using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
   public class CreatebusintargetyearDomain
    {
        public int target_id { get; set; }
        public int company_id { get; set; }
        public int department_id { get; set; }
        public string tgtyear_year { get; set; }
        public string tgtyear_amt { get; set; }
    }
}
