using System;

namespace THOUGHTBOX.DOMAIN.Domain
{
    public class CreateCustomerDomain
    {
        public int customer_id { get; set; }
        public int cust_employeeid { get; set; }
        public String cust_name { get; set; }
        public String cust_address { get; set; }
        public String cust_city { get; set; }
        public String cust_state { get; set; }
        public String cust_phoneno { get; set; }
        public String cust_emailaddress { get; set; }
        public String cust_contactperson { get; set; }
        public int cust_cpdesignation { get; set; }
        public String cust_status { get; set; }
        public String cust_paidstatus { get; set; }
        public String cust_type { get; set; }
        public String cust_paidamount { get; set; }
    }
}
