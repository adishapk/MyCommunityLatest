using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
    public class ApprovalTransGeneral
    {
        public int request_id { get; set; }
        public string requ_type_id { get; set; }
        public string requ_date { get; set; }
        public string requ_time { get; set; }
        public int requ_appby { get; set; }
        public string requ_status { get; set; }
        public string requ_comments { get; set; }
        public string requ_details { get; set; }
        public int requ_approvedby { get; set; }
        public string requ_docstatus { get; set; }
        public string requ_addl1 { get; set; }
        public string requ_addl2 { get; set; }
        public string requ_addl3 { get; set; }
        public string requ_addl4 { get; set; }
        public string requ_addl5 { get; set; }

    }
}
