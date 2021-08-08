using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
    public class Requestfeedbackdomain
    {
        public int request_id { get; set; }
        public int employee_id { get; set; }
        public string feedback_comments { get; set; }
        public string feedback_date { get; set; }
        public string feedback_time { get; set; }
        public string feedback_image { get; set; }
        public string feedback_date_userentry { get; set; }

    }
}
