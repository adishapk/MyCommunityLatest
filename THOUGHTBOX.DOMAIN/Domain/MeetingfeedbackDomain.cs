using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.DOMAIN.Domain
{
   public class MeetingfeedbackDomain
    {
        public int meeting_id { get; set; }
        public string meeting_refno { get; set; }
        public int meeting_sectorid { get; set; }
        public int client_id { get; set; }
        public string client_cperson { get; set; }
        public string client_cdesignation { get; set; }
        public string client_caddressdet { get; set; }
        public string meeting_appttakdate { get; set; }
        public string meeting_date { get; set; }
        public string meeting_time { get; set; }
        public string meeting_nextdate { get; set; }
        public string meeting_nexttime { get; set; }
        public string meet_remarks { get; set; }
        public string meet_status { get; set; }
        public string meet_document { get; set; }
        
    }
}
