namespace THOUGHTBOX.DOMAIN.Domain
{
    public class CreateDivisionDomain
    {
        public int division_id { get; set; }
        public string division_name { get; set; }
        public string division_code { get; set; }
        public string division_details { get; set; }
        public int company_id { get; set; }
        public int department_id { get; set; }
        public string companyname { get; set; }
        public string departmentname { get; set; }
    }
}
