namespace THOUGHTBOX.DOMAIN.Domain
{
    public class CreatealertsDomain
    {
        public int alert_id { get; set; }
        public int employee_id { get; set; }
        public string alert_message { get; set; }
        public string alert_image { get; set; }
        public string alert_videolink { get; set; }
        public int alert_sentby { get; set; }
        public string alert_date { get; set; }
        public string alert_time { get; set; }
        public string alert_viewed { get; set; }
        public string alert_vieweddate { get; set; }
        public string alert_viewedtime { get; set; }
        public string alert_editstatus { get; set; }
    }
}
