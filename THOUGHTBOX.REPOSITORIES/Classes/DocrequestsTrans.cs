using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using Npgsql;
using System.Data;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class DocrequestsTrans
    {
        ConnectionRepository connectionRepository = new ConnectionRepository();
        Log Log = new Log();
        DataSet ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;
        public bool UpdateApprovalTrans(ApprovalTransGeneral apptransgeneral, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {
                string mQuery = "";
                mQuery = "INSERT INTO public.tbl_mark_approval_trans(request_id,requ_appby,requ_date,requ_time,requ_type_id) VALUES(@request_id,@requ_appby,@requ_date,@requ_time,@requ_type_id)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", apptransgeneral.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_approvedby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_type_id", apptransgeneral.requ_type_id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                mQuery = "INSERT INTO public.tbl_mark_approval_summary(request_id,requ_time,requ_details,requ_status,requ_comments,requ_date,requ_appby,requ_type_id,requ_approvedby) VALUES(@request_id,@requ_time,@requ_details,@requ_status,@requ_comments,@requ_date,@requ_appby,@requ_type_id,@requ_approvedby)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", apptransgeneral.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_details", apptransgeneral.requ_details));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_status", apptransgeneral.requ_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_comments", apptransgeneral.requ_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_appby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_type_id", apptransgeneral.requ_type_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_approvedby", apptransgeneral.requ_approvedby));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                mQuery = "INSERT INTO public.tbl_mark_doc_decision_details(request_id,requ_type_id,requ_status,requ_appby,requ_comments,requ_date,requ_time,requ_docstatus,requ_addl1,requ_addl2,requ_addl3,requ_addl4,requ_addl5) VALUES(@request_id,@requ_type_id,@requ_status,@requ_appby,@requ_comments,@requ_date,@requ_time,@requ_docstatus,@requ_addl1,@requ_addl2,@requ_addl3,@requ_addl4,@requ_addl5)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", apptransgeneral.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_type_id", apptransgeneral.requ_type_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_status", apptransgeneral.requ_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_appby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_comments", apptransgeneral.requ_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_docstatus", apptransgeneral.requ_docstatus));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl1", apptransgeneral.requ_addl1));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl2", apptransgeneral.requ_addl2));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl3", apptransgeneral.requ_addl3));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl4", apptransgeneral.requ_addl4));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl5", apptransgeneral.requ_addl5));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateApprovalTrans1(ApprovalTransGeneral apptransgeneral, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {
                string mQuery = "";
                mQuery = "update public.tbl_mark_approval_trans set requ_appby =@requ_appby,requ_date =@requ_date,requ_time =@requ_time where request_id=" + apptransgeneral.request_id + " and requ_type_id ='" + apptransgeneral.requ_type_id + "'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_approvedby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                mQuery = "INSERT INTO public.tbl_mark_approval_summary(request_id,requ_time,requ_details,requ_status,requ_comments,requ_date,requ_appby,requ_type_id,requ_approvedby) VALUES(@request_id,@requ_time,@requ_details,@requ_status,@requ_comments,@requ_date,@requ_appby,@requ_type_id,@requ_approvedby)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", apptransgeneral.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_details", apptransgeneral.requ_details));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_status", apptransgeneral.requ_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_comments", apptransgeneral.requ_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_appby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_type_id", apptransgeneral.requ_type_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_approvedby", apptransgeneral.requ_approvedby));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                mQuery = "INSERT INTO public.tbl_mark_doc_decision_details(request_id,requ_type_id,requ_status,requ_appby,requ_comments,requ_date,requ_time,requ_docstatus,requ_addl1,requ_addl2,requ_addl3,requ_addl4,requ_addl5) VALUES(@request_id,@requ_type_id,@requ_status,@requ_appby,@requ_comments,@requ_date,@requ_time,@requ_docstatus,@requ_addl1,@requ_addl2,@requ_addl3,@requ_addl4,@requ_addl5)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", apptransgeneral.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_type_id", apptransgeneral.requ_type_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_status", apptransgeneral.requ_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_appby", apptransgeneral.requ_appby));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_comments", apptransgeneral.requ_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_date", apptransgeneral.requ_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_time", apptransgeneral.requ_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_docstatus", apptransgeneral.requ_docstatus));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl1", apptransgeneral.requ_addl1));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl2", apptransgeneral.requ_addl2));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl3", apptransgeneral.requ_addl3));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl4", apptransgeneral.requ_addl4));
                    cmd.Parameters.Add(new NpgsqlParameter("@requ_addl5", apptransgeneral.requ_addl5));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

    
        public bool InsertDashboardalerts(Generaldomain gendomain, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {
                string mQuery = "";
                mQuery = "INSERT INTO public.tbl_mark_dashboard_alerts(dash_requ_id,dash_requ_type,dash_message,dash_requ_by,dash_requ_date,dash_requ_time,dash_requ_status,dash_viewstat,dash_datetime,dash_image) VALUES(@dash_requ_id,@dash_requ_type,@dash_message,@dash_requ_by,@dash_requ_date,@dash_requ_time,@dash_requ_status,@dash_viewstat,@dash_datetime,@dash_image)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_id", gendomain.Generalval1));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_type", gendomain.Generalval2));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_message", gendomain.Gneralaval3));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_by", gendomain.Generalval11));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_date", gendomain.Gneralaval4));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_time", gendomain.Gneralaval5));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_status", gendomain.Gneralaval6));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_viewstat", gendomain.Gneralaval7));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_datetime", gendomain.Gneralaval8));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_image", gendomain.Gneralaval9));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteApprovalTrans(int id, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {
                string mQuery = "";
                mQuery = "Delete from public.tbl_mark_approval_trans where request_id = @request_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", id));
                  
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

     
    }
}
