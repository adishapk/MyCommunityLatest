using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreatealertsRepo : ICreatealertsRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int alertdelete(int alertdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_alerts where alert_id =" + alertdelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int alertinsert(CreatealertsDomain alertinsrt)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "insert into tbl_mark_alerts(employee_id,alert_message,alert_videolink,alert_time,alert_date) values (@employee_id,@alert_message,@alert_videolink,@alert_time,@alert_date)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", alertinsrt.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_message", alertinsrt.alert_message));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_videolink", alertinsrt.alert_videolink));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_time", alertinsrt.alert_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_date", alertinsrt.alert_date));




                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int alertupdate(CreatealertsDomain alertupt)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_alerts set alert_message = @alert_message,alert_image = @alert_image,alert_videolink=@alert_videolink,alert_date=@alert_date,alert_time=@alert_time where alert_id = @alert_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_id", alertupt.alert_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", alertupt.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_message", alertupt.alert_message));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_image", alertupt.alert_image));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_videolink", alertupt.alert_videolink));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_date", alertupt.alert_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@alert_time", alertupt.alert_time));




                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreatealertsDomain> getallalerts(int getallval)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                string TRR = "select alert_id,employee_id,alert_message,alert_image,alert_videolink,alert_date from tbl_mark_alerts order by alert_date";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreatealertsDomain> alerts_list = new List<CreatealertsDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    alerts_list.Add(new CreatealertsDomain
                    {
                        alert_id = Convert.ToInt32(redrow["alert_id"].ToString()),
                        employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                        alert_message = redrow["alert_message"].ToString(),
                        alert_image = redrow["alert_image"].ToString(),
                        alert_videolink = redrow["alert_videolink"].ToString(),
                        alert_date = redrow["alert_date"].ToString(),

                    }
                    );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return alerts_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
