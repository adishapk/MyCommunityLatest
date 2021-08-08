namespace THOUGHTBOX.DOMAIN.Domain
{
    public class RegistrationForm
    {
        //tbl_re_reg_details
        public int Reg_Id { get; set; }
        public string Reg_User_Name { get; set; }
        public string Reg_Email_Id { get; set; }
        public string Reg_Company_Name { get; set; }
        public string Reg_Co_SAddress { get; set; }
        public string Reg_Co_City { get; set; }
        public string Reg_Co_State { get; set; }
        public string Reg_Co_Country { get; set; }
        public string Reg_Co_Pincode { get; set; }
        public string Reg_Date { get; set; }
        public string Reg_Code { get; set; }
        public string Reg_Time { get; set; }
        public string Reg_Type { get; set; }
        public string Reg_Ip { get; set; }

        //tbl_re_user_details
        public int User_Id { get; set; }
        public int User_Type_Id { get; set; }
        public int Employee_Id { get; set; }
        public string User_Password { get; set; }
        public string User_Active { get; set; }
        public string User_Type_Name { get; set; }


        //tbl_re_user_trans
        public string trans_login_time { get; set; }
        public string Trans_Logout_Date { get; set; }
        public string Trans_Logout_Time { get; set; }
        public string trans_login_date { get; set; }

    }
}
