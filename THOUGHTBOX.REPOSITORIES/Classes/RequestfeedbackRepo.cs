using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class RequestfeedbackRepo:IRequestfeedbackRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int feedbackempInsert(Requestfeedbackdomain requestfeedback)
        {
            try
            {
                     connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_requests_feedback(request_id,employee_id,feedback_comments,feedback_date,feedback_time,feedback_image,feedback_date_userentry) values (@request_id,@employee_id,@feedback_comments,@feedback_date,@feedback_time,@feedback_image,@feedback_date_userentry)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {

                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", requestfeedback.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", requestfeedback.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback_comments", requestfeedback.feedback_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback_date", requestfeedback.feedback_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback_time", requestfeedback.feedback_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback_image", requestfeedback.feedback_image));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback_date_userentry", requestfeedback.feedback_date_userentry));



                    cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    connection.Dispose();
                    return 1;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
