namespace THOUGHTBOX.DOMAIN.Domain
{
    public class CreateRequest
    {
        public int request_id { get; set; }
        public string request_code { get; set; }
        public string request_title { get; set; }
        public string request_date { get; set; }
        public string requested_date { get; set; }
        public string requested_time { get; set; }
        public string request_details { get; set; }
        public string request_priority { get; set; }
        public string request_image { get; set; }
        public string request_imagehide { get; set; }
        public string request_stdate { get; set; }
        public string request_eddate { get; set; }
        public string request_status { get; set; }
        public string request_apdate { get; set; }
        public string request_aptime { get; set; }
        public string request_apcomments { get; set; }
        public string request_appimage { get; set; }
        public string allocated_comments { get; set; }
        public int appliedby_id { get; set; }
        public int approvedby_id { get; set; }
        public string user_comments { get; set; }
        public string request_vericomments { get; set; }
        public string request_veriimage { get; set; }


    }
}
