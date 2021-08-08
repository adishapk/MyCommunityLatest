using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;
using Npgsql;
using System.Data;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
   public class CreatebusintargetmonthEmployeeRepo : ICreatebusintargetmonthEmployeeRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int empmonthtargetdelete(int target, string monthid, int selectemploy)
        {
            try
            {
                string DDD = "delete from tbl_mark_bustgtmonth_employee where target_id =" + target + " and targetmonth = '" + monthid + "' and target_empid = "+ selectemploy+"";
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int empmonthtargetinsert(CreatebusintargetmonthEmployeeDomain empmontargetinsrt)
        {
            try
            {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_bustgtmonth_employee(target_id,targetyear,targetmonth,target_empid,target_amt,target_alldate,target_status) values (@target_id,@targetyear,@targetmonth,@target_empid,@target_amt,@target_alldate,@target_status)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@target_id", Convert.ToInt32(empmontargetinsrt.target_id)));
                    cmd.Parameters.Add(new NpgsqlParameter("@targetyear", empmontargetinsrt.targetyear));
                    cmd.Parameters.Add(new NpgsqlParameter("@targetmonth", empmontargetinsrt.targetmonth));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_empid", empmontargetinsrt.target_empid));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_amt", empmontargetinsrt.target_amt));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_alldate", empmontargetinsrt.target_alldate));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_status", empmontargetinsrt.target_status));

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

        public int empmonthtargetupdate(CreatebusintargetmonthEmployeeDomain empmontargetup)
        {
            try
            {

                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_bustgtmonth_employee set target_amt = @target_amt where target_id = @target_id and targetmonth = @targetmonth and target_empid = @target_empid";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@target_id", Convert.ToInt32(empmontargetup.target_id)));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_empid", Convert.ToInt32(empmontargetup.target_empid)));
                    cmd.Parameters.Add(new NpgsqlParameter("@targetmonth", empmontargetup.targetmonth));
                    cmd.Parameters.Add(new NpgsqlParameter("@target_amt", empmontargetup.target_amt));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();


                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreatebusintargetmonthEmployeeDomain> getallempmonthtrgt(int getallempmonth)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                string TRR = "select target_id,targetyear,targetmonth,target_empid,target_amt,target_alldate,target_status from tbl_mark_bustgtmonth_employee order by targetmonth";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreatebusintargetmonthEmployeeDomain> emperson_list = new List<CreatebusintargetmonthEmployeeDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreatebusintargetmonthEmployeeDomain
                    {
                        target_id = Convert.ToInt32(redrow["target_id"].ToString()),
                        targetyear = redrow["targetyear"].ToString(),
                        targetmonth = redrow["targetmonth"].ToString(),
                        target_empid = Convert.ToInt32(redrow["target_empid"].ToString()),
                        target_amt = redrow["target_amt"].ToString(),
                        target_alldate = redrow["target_alldate"].ToString(),
                        target_status = "OPEN"


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

        public int getemptargtmonth(int target, string monthid, int selectemploy)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                int empcount = 0;
                string Msql = "select count(*) from tbl_mark_bustgtmonth_employee where target_id =" + target + " and targetmonth = '" + monthid + "' and target_empid = " + selectemploy + "";
                Master_ds = Master_con.PG_SelectMasterDS(Msql, connection, null);
                empcount = Convert.ToInt32(Master_ds.Tables[0].Rows[0][0].ToString());
                Master_ds.Dispose();
                connection.Dispose();
                return empcount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
