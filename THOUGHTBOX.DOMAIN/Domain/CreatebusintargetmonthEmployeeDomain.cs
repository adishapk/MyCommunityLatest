using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
   public class CreatebusintargetmonthEmployeeDomain
    {
        public int target_id { get; set; }
        public string targetyear { get; set; }
        public string targetmonth { get; set; }
        public int target_empid { get; set; }
        public string target_amt { get; set; }
        public string target_alldate { get; set; }
        public string target_status { get; set; }
    }
}
