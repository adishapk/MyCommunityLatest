using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateRequestRepo : ICreateRequestRepo
    {
        private ConnectionRepository person_con = new ConnectionRepository();
        DataSet person_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<CreateRequest> getalljoballoc(int getalljob)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select request_id,request_title,request_date,request_details,request_priority,request_image,request_stdate,request_eddate,request_apcomments,request_appimage from tbl_mark_requests where request_status = 'Approved' order by request_date";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateRequest> emperson_list = new List<CreateRequest>();
                foreach (DataRow redrow in person_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateRequest
                    {
                        request_id = Convert.ToInt32(redrow["request_id"].ToString()),
                        request_title = redrow["request_title"].ToString(),
                        request_date = redrow["request_date"].ToString(),
                        request_details = redrow["request_details"].ToString(),
                        request_priority = redrow["request_priority"].ToString(),
                        request_image = redrow["request_image"].ToString(),
                        request_stdate = redrow["request_stdate"].ToString(),
                        request_eddate = redrow["request_eddate"].ToString(),
                        request_apcomments = redrow["request_apcomments"].ToString(),
                        request_appimage = redrow["request_appimage"].ToString(),

                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateRequest> getalljoballocEmp(int getalljob)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select R.request_id,request_title,request_date,request_details,request_priority,request_image,request_stdate,request_eddate,request_apcomments,request_appimage,allocated_comments from tbl_mark_requests R inner join tbl_mark_requests_employee E on R.request_id = E.request_id where request_status = 'Approved' order by request_date";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateRequest> emperson_list = new List<CreateRequest>();
                foreach (DataRow redrow in person_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateRequest
                    {
                        request_id = Convert.ToInt32(redrow["request_id"].ToString()),
                        request_title = redrow["request_title"].ToString(),
                        request_date = redrow["request_date"].ToString(),
                        request_details = redrow["request_details"].ToString(),
                        request_priority = redrow["request_priority"].ToString(),
                        request_image = redrow["request_image"].ToString(),
                        request_stdate = redrow["request_stdate"].ToString(),
                        request_eddate = redrow["request_eddate"].ToString(),
                        request_apcomments = redrow["request_apcomments"].ToString(),
                        request_appimage = redrow["request_appimage"].ToString(),
                        allocated_comments = redrow["allocated_comments"].ToString(),

                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateRequest> getallrequest(int getallrqst)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select request_id,request_title,request_date,request_details,request_priority,request_image,request_stdate,request_eddate,request_apcomments,request_appimage,request_code,request_vericomments,request_veriimage from tbl_mark_requests where request_id = " + getallrqst + "";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateRequest> emperson_list = new List<CreateRequest>();
                foreach (DataRow redrow in person_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateRequest
                    {
                        request_id = Convert.ToInt32(redrow["request_id"].ToString()),
                        request_title = redrow["request_title"].ToString(),
                        request_date = redrow["request_date"].ToString(),
                        request_details = redrow["request_details"].ToString(),
                        request_priority = redrow["request_priority"].ToString(),
                        request_image = redrow["request_image"].ToString(),
                        request_stdate = redrow["request_stdate"].ToString(),
                        request_eddate = redrow["request_eddate"].ToString(),
                        request_apcomments = redrow["request_apcomments"].ToString(),
                        request_appimage = redrow["request_appimage"].ToString(),
                        request_code = redrow["request_code"].ToString(),
                        request_vericomments = redrow["request_vericomments"].ToString(),
                        request_veriimage = redrow["request_veriimage"].ToString(),

                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string getautonumber(string parameter)
        {
           
            try
            {
                connection = person_con.GetPooledConnection();
                string Ano = person_con.GetAutonumber(parameter, connection, transaction);
                connection.Dispose();
                return Ano;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int reqaprveupdate(CreateRequest reqstapveup)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string mQuery = "update tbl_mark_requests set request_stdate = @request_stdate,request_eddate = @request_eddate,request_apdate=@request_apdate,request_aptime=@request_aptime,request_apcomments=@request_apcomments,request_priority=@request_priority,request_appimage=@request_appimage,request_status=@request_status where request_id = @request_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", reqstapveup.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_stdate", reqstapveup.request_stdate));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_eddate", reqstapveup.request_eddate));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_apdate", reqstapveup.request_apdate));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_aptime", reqstapveup.request_aptime));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_apcomments", reqstapveup.request_apcomments));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_priority", reqstapveup.request_priority));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_appimage", reqstapveup.request_appimage));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_status", reqstapveup.request_status));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DocrequestsTrans doctrans = new DocrequestsTrans();
                ApprovalTransGeneral apptransgeneral = new ApprovalTransGeneral();
                apptransgeneral.request_id = reqstapveup.request_id;
                apptransgeneral.requ_date = reqstapveup.request_apdate;
                apptransgeneral.requ_time = reqstapveup.request_aptime;
                apptransgeneral.requ_appby = reqstapveup.appliedby_id;
                apptransgeneral.requ_type_id = "Department Request";
                apptransgeneral.requ_status = "Approved";
                apptransgeneral.requ_comments = "";
                apptransgeneral.requ_approvedby = reqstapveup.approvedby_id;
                apptransgeneral.requ_docstatus = "Pending";
                apptransgeneral.requ_details = "Employee Request of No " + reqstapveup.request_code + " of Request Title " + reqstapveup.request_title + " is approved by MD and forwarded to Business Development Manager";
                apptransgeneral.requ_addl1 = "0";
                apptransgeneral.requ_addl2 = "0";
                apptransgeneral.requ_addl3 = reqstapveup.request_priority;
                apptransgeneral.requ_addl4 = "0";
                apptransgeneral.requ_addl5 = reqstapveup.request_apcomments;

                doctrans.UpdateApprovalTrans1(apptransgeneral, connection, transaction);

                DocrequestsTrans doctransalert = new DocrequestsTrans();
                Generaldomain generalalert = new Generaldomain();

                //To fill alert procedure
                generalalert.Generalval1 = reqstapveup.request_id;
                generalalert.Generalval2 = "Department Request";
                generalalert.Gneralaval3 = "Employee Request of No " + reqstapveup.request_code + " of Request Title " + reqstapveup.request_title + " is approved by MD and forwarded to Business Development Manager";
                generalalert.Generalval11 = reqstapveup.approvedby_id;
                generalalert.Gneralaval4 = reqstapveup.request_apdate;
                generalalert.Gneralaval5 = reqstapveup.request_aptime;
                generalalert.Gneralaval6 = "Pending";
                generalalert.Gneralaval7 = "N";
                generalalert.Gneralaval8 = reqstapveup.request_aptime;
                generalalert.Gneralaval9 = "/WebImages/SystemImages/requestimage.jpg";

                //connection = connectionrepository.GetPooledConnection();
                doctransalert.InsertDashboardalerts(generalalert, connection, transaction);


                connection.Dispose();
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int requestdelete(int reqstdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_requests where request_id =" + reqstdelet;
                person_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int requestinsert(CreateRequest reqstin)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string Ano = person_con.GetAutonumber("Department Request", connection, transaction);

               // connection = person_con.GetPooledConnection();
                string mQuery = "insert into tbl_mark_requests(request_title,request_date,requested_date,requested_time,request_details,request_priority,request_image,request_status,request_code) values (@request_title,@request_date,@requested_date,@requested_time,@request_details,@request_priority,@request_image,@request_status,@request_code)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_title", reqstin.request_title));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_date", reqstin.request_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requested_date", reqstin.requested_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requested_time", reqstin.requested_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_details", reqstin.request_details));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_priority", reqstin.request_priority));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_image", reqstin.request_image));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_status", "Pending"));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_code", Ano));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

               // connection = person_con.GetPooledConnection();

                if (!person_con.UpdateAutonumber("Department Request", connection, transaction))
                {
                    throw new Exception("Error on Update Serial");
                }

                mQuery = "SELECT  currval('tbl_mark_requests_request_id_seq') as requestid";
                person_ds = person_con.PG_SelectMasterDS(mQuery, connection, null);
                int reqid = Convert.ToInt32(person_ds.Tables[0].Rows[0][0].ToString());

                //connection = person_con.GetPooledConnection();

                DocrequestsTrans doctrans = new DocrequestsTrans();
                ApprovalTransGeneral apptransgeneral = new ApprovalTransGeneral();
                apptransgeneral.request_id = reqid;
                apptransgeneral.requ_date = reqstin.request_date;
                apptransgeneral.requ_time = reqstin.requested_time;
                apptransgeneral.requ_appby = reqstin.appliedby_id;
                apptransgeneral.requ_type_id = "Department Request";
                apptransgeneral.requ_status = "Prepared";
                apptransgeneral.requ_comments = "";
                apptransgeneral.requ_approvedby = reqstin.approvedby_id;
                apptransgeneral.requ_docstatus = "Pending";
                apptransgeneral.requ_details = "New Employee Request of No " + Ano + " of Request Title " + reqstin.request_title + " is forwarded to MD";
                apptransgeneral.requ_addl1 = "0";
                apptransgeneral.requ_addl2 = "0";
                apptransgeneral.requ_addl3 = reqstin.request_priority;
                apptransgeneral.requ_addl4 = "0";
                apptransgeneral.requ_addl5 = reqstin.user_comments;

                doctrans.UpdateApprovalTrans(apptransgeneral, connection, transaction);
                              
                DocrequestsTrans doctransalert = new DocrequestsTrans();
                Generaldomain generalalert = new Generaldomain();

                  
                            //To fill alert procedure
                generalalert.Generalval1 = reqid;
                generalalert.Generalval2 = "Department Request";
                generalalert.Gneralaval3 = "New Employee Request of No " + Ano + " of Request Title " + reqstin.request_title + " is forwarded to MD";
                generalalert.Generalval11 = reqstin.approvedby_id;
                generalalert.Gneralaval4 = reqstin.request_date;
                generalalert.Gneralaval5 = reqstin.requested_time;
                generalalert.Gneralaval6 = "Pending";
                generalalert.Gneralaval7 = "N";
                generalalert.Gneralaval8 = reqstin.requested_time;
                generalalert.Gneralaval9 = "/WebImages/SystemImages/requestimage.jpg";

                //connection = connectionrepository.GetPooledConnection();
                doctransalert.InsertDashboardalerts(generalalert, connection, transaction);
                    

                connection.Dispose();
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int reqverifyupdate(CreateRequest reqstapveup)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string mQuery = "update tbl_mark_requests set request_vericomments = @request_vericomments,request_veriimage = @request_veriimage where request_id = @request_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", reqstapveup.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_vericomments", reqstapveup.request_vericomments));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_veriimage", reqstapveup.request_veriimage));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                DocrequestsTrans doctrans = new DocrequestsTrans();
                ApprovalTransGeneral apptransgeneral = new ApprovalTransGeneral();
                apptransgeneral.request_id = reqstapveup.request_id;
                apptransgeneral.requ_date = reqstapveup.request_apdate;
                apptransgeneral.requ_time = reqstapveup.request_aptime;
                apptransgeneral.requ_appby = reqstapveup.appliedby_id;
                apptransgeneral.requ_type_id = "Department Request";
                apptransgeneral.requ_status = "Verified";
                apptransgeneral.requ_comments = "";
                apptransgeneral.requ_approvedby = reqstapveup.approvedby_id;
                apptransgeneral.requ_docstatus = "Pending";
                apptransgeneral.requ_details = "Employee Request of No " + reqstapveup.request_code + " of Request Title " + reqstapveup.request_title + " is Verified by BDM and forwarded to Department Head";
                apptransgeneral.requ_addl1 = "0";
                apptransgeneral.requ_addl2 = "0";
                apptransgeneral.requ_addl3 = reqstapveup.request_title;
                apptransgeneral.requ_addl4 = "0";
                apptransgeneral.requ_addl5 = reqstapveup.request_vericomments;

                doctrans.UpdateApprovalTrans1(apptransgeneral, connection, transaction);

                DocrequestsTrans doctransalert = new DocrequestsTrans();
                Generaldomain generalalert = new Generaldomain();

                //To fill alert procedure
                generalalert.Generalval1 = reqstapveup.request_id;
                generalalert.Generalval2 = "Department Request";
                generalalert.Gneralaval3 = "Employee Request of No " + reqstapveup.request_code + " of Request Title " + reqstapveup.request_title + " is Verified by BDM and forwarded to Department Head";
                generalalert.Generalval11 = reqstapveup.approvedby_id;
                generalalert.Gneralaval4 = reqstapveup.request_apdate;
                generalalert.Gneralaval5 = reqstapveup.request_aptime;
                generalalert.Gneralaval6 = "Pending";
                generalalert.Gneralaval7 = "N";
                generalalert.Gneralaval8 = reqstapveup.request_aptime;
                generalalert.Gneralaval9 = "/WebImages/SystemImages/requestimage.jpg";

                //connection = connectionrepository.GetPooledConnection();
                doctransalert.InsertDashboardalerts(generalalert, connection, transaction);


                connection.Dispose();
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
    }
}
