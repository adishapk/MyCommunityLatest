namespace THOUGHTBOX.DOMAIN.Domain
{
    public class CreateDepartmentDomain
    {
        public int department_id { get; set; }
        public int Company_id { get; set; }
        public string department_name { get; set; }
        public string department_code { get; set; }
        public string department_details { get; set; }
        public string companyname { get; set; }

    }
}
