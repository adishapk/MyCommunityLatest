using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;
using Npgsql;
using System.Data;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
   public class CreatebusintargetmonthRepo : ICreatebusintargetmonthRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<Createbusintargetmonth> getallmonthtrgt(int getallmonth)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                string TRR = "select target_id,company_id,department_id,tgtyear_month,tgtyearmonth_amt from tbl_mark_bustgtmonth order by tgtyear_month";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<Createbusintargetmonth> emperson_list = new List<Createbusintargetmonth>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new Createbusintargetmonth
                    {
                        target_id = Convert.ToInt32(redrow["target_id"].ToString()),
                        company_id = Convert.ToInt32(redrow["company_id"].ToString()),
                        department_id = Convert.ToInt32(redrow["department_id"].ToString()),
                        tgtyear_month = redrow["tgtyear_month"].ToString(),
                        tgtyearmonth_amt = redrow["tgtyearmonth_amt"].ToString(),


                    }
                    );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Createbusintargetmonth> getamonthtrgt(int gettargt, string getmonth)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                string TRR = "select tgtyearmonth_amt from tbl_mark_bustgtmonth where target_id ="+ gettargt+ " and tgtyear_month='"+ getmonth+"'";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<Createbusintargetmonth> emperson_list = new List<Createbusintargetmonth>();
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new Createbusintargetmonth
                    {
                        
                        tgtyear_month = redrow["tgtyearmonth_amt"].ToString(),
                        
                    }
                    );
                }
                }
                else
                {
                    emperson_list.Add(new Createbusintargetmonth
                    {

                        tgtyear_month = "",

                    }
                                       );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int monthtargetdelete(int monthtargetdel, string idmonth)
        {
            try
            {
                string DDD = "delete from tbl_mark_bustgtmonth where target_id =" + monthtargetdel + " and tgtyear_month = '"+ idmonth+"'";
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int monthtargetinsert(Createbusintargetmonth mnthtargtin)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("tgtyearmonth_amt", "public.tbl_mark_bustgtmonth", "  company_id = " + mnthtargtin.company_id + " and department_id = " + mnthtargtin.department_id + " and tgtyear_month = '" + mnthtargtin.tgtyear_month + "'", mnthtargtin.tgtyearmonth_amt.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_bustgtmonth(target_id,company_id,department_id,tgtyear_month,tgtyearmonth_amt) values (@target_id,@company_id,@department_id,@tgtyear_month,@tgtyearmonth_amt)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@target_id", Convert.ToInt32(mnthtargtin.target_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(mnthtargtin.company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(mnthtargtin.department_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_month", mnthtargtin.tgtyear_month));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyearmonth_amt", mnthtargtin.tgtyearmonth_amt));


                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    connection.Dispose();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int monthtargetupdate(Createbusintargetmonth mnthtargtup)
        {
            try
            {
             
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "update tbl_mark_bustgtmonth set target_id = @target_id,company_id = @company_id,department_id = @department_id,tgtyear_month=@tgtyear_month,tgtyearmonth_amt=@tgtyearmonth_amt where target_id = @target_id and tgtyear_month = @tgtyear_month";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@target_id", Convert.ToInt32(mnthtargtup.target_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(mnthtargtup.company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(mnthtargtup.department_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_month", mnthtargtup.tgtyear_month));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyearmonth_amt", mnthtargtup.tgtyearmonth_amt));


                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    connection.Dispose();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
