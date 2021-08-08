namespace THOUGHTBOX.DOMAIN.Domain
{
    public class AllocateEmployeesDomain
    {
        public int request_id { get; set; }
        public int employee_id { get; set; }
        public string allocated_date { get; set; }
        public string allocated_time { get; set; }
        public string allocated_comments { get; set; }
        public string allocated_image { get; set; }
        public string allemployeeids { get; set; }
    }
}
