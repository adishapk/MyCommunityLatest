using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
   public class CreatebusintargetyearRepo : ICreatebusintargetyearRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<CreatebusintargetyearDomain> getalltarget(int getalltarg)
        {
            try
            {
                connection = Master_con.GetPooledConnection();

                string TRR = "select target_id,company_id,department_id,tgtyear_year,tgtyear_amt from tbl_mark_bustgtyear order by tgtyear_year";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreatebusintargetyearDomain> emperson_list = new List<CreatebusintargetyearDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreatebusintargetyearDomain
                    {
                        target_id = Convert.ToInt32(redrow["target_id"].ToString()),
                        company_id = Convert.ToInt32(redrow["company_id"].ToString()),
                        department_id = Convert.ToInt32(redrow["department_id"].ToString()),
                        tgtyear_year = redrow["tgtyear_year"].ToString(),
                        tgtyear_amt = redrow["tgtyear_amt"].ToString(),


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

        public IList<CreatebusintargetyearDomain> getallyeartarget(int getyeartarg)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select tgtyear_year,tgtyear_amt from tbl_mark_bustgtyear where target_id = "+ getyeartarg+"";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreatebusintargetyearDomain> emperson_list = new List<CreatebusintargetyearDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreatebusintargetyearDomain
                    {
                        tgtyear_year = redrow["tgtyear_year"].ToString(),
                        tgtyear_amt = redrow["tgtyear_amt"].ToString(),
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

        public string gettargetyear(string getyear, int getcompany, int getdepartment)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select tgtyear_amt,target_id from tbl_mark_bustgtyear where company_id = " + getcompany+ " and department_id = "+getdepartment+ " and tgtyear_year = '"+getyear+"'";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);

                string targetid = "";
                string tgtamount = "";
                string tgtmonth = "";

                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                     tgtamount = Master_ds.Tables[0].Rows[0][0].ToString();
                    targetid = Master_ds.Tables[0].Rows[0][1].ToString();
                    tgtamount = tgtamount + "," + targetid;

                    TRR = "select sum(cast(tgtyearmonth_amt as integer)) from tbl_mark_bustgtmonth where target_id = " + targetid;
                    Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);

                    tgtmonth = Master_ds.Tables[0].Rows[0][0].ToString();
                    tgtamount = tgtamount + "," + tgtmonth;

                }
                else
                {
                    tgtamount = "";
                }

                Master_ds.Dispose();
                connection.Dispose();
                return tgtamount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int targetdelete(int targetdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_bustgtyear where target_id =" + targetdelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int targetinsert(CreatebusintargetyearDomain targetin)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("tgtyear_amt", "public.tbl_mark_bustgtyear", "  company_id = " + targetin.company_id + " and department_id = " + targetin.department_id + " and tgtyear_year = '" + targetin.tgtyear_year + "'", targetin.tgtyear_amt.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_bustgtyear(company_id,department_id,tgtyear_year,tgtyear_amt) values (@company_id,@department_id,@tgtyear_year,@tgtyear_amt)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(targetin.company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(targetin.department_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_year", targetin.tgtyear_year));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_amt", targetin.tgtyear_amt));
                        

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

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

        public int targetupdate(CreatebusintargetyearDomain targetup)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("tgtyear_amt", "public.tbl_mark_bustgtyear", "  company_id = " + targetup.company_id + " and department_id = " + targetup.department_id + " and tgtyear_year = '" + targetup.tgtyear_year + "'", targetup.tgtyear_amt.ToString());
                if (dupvl == 1)
                {

                    connection = Master_con.GetPooledConnection();
                    string mQuery = "update tbl_mark_bustgtyear set company_id = @company_id,department_id = @department_id,tgtyear_year=@tgtyear_year,tgtyear_amt=@tgtyear_amt where target_id = @target_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@target_id", Convert.ToInt32(targetup.target_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(targetup.company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(targetup.department_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_year", targetup.tgtyear_year));
                        cmd.Parameters.Add(new NpgsqlParameter("@tgtyear_amt", targetup.tgtyear_amt));


                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
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
    }
}
