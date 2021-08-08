using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;



namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class SalarystructureRepo : ISalarystructureRepo
    {
        ConnectionRepository salary_Con = new ConnectionRepository();
        DataSet salary_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<salarystructuredomain> Getsalarystructure(string Sub_node)
        {
            try
            {
                connection = salary_Con.GetPooledConnection();
                string TRR = "select salstruct_id,salstruct_head from tbl_mark_salarystructure where salstruct_type = '" + Sub_node + "' order by salstruct_head";
                salary_ds = salary_Con.PG_SelectMasterDS(TRR, connection, null);
                IList<salarystructuredomain> slrystruct_list = new List<salarystructuredomain>();
                foreach (DataRow redrow in salary_ds.Tables[0].Rows)
                {
                    slrystruct_list.Add(new salarystructuredomain
                    {
                        salstruct_id = Convert.ToInt32(redrow["salstruct_id"].ToString()),
                        salstruct_head = redrow["salstruct_head"].ToString(),
                    }
                    );
                }
                salary_ds.Dispose();
                connection.Dispose();
                return slrystruct_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //NpgsqlTransaction transaction = null;

        public IList<salarystructuredomain> rgetsalarystructure(int rgetslrystruct)
        {
            try
            {
                connection = salary_Con.GetPooledConnection();
                string TRR = "select salstruct_id,salstruct_type,salstruct_head from tbl_mark_salarystructure order by salstruct_type,salstruct_head";
                salary_ds = salary_Con.PG_SelectMasterDS(TRR, connection, null);
                IList<salarystructuredomain> slrystruct_list = new List<salarystructuredomain>();
                foreach (DataRow redrow in salary_ds.Tables[0].Rows)
                {
                    slrystruct_list.Add(new salarystructuredomain
                    {
                        salstruct_type = redrow["salstruct_type"].ToString(),
                        salstruct_head = redrow["salstruct_head"].ToString(),
                        salstruct_id = Convert.ToInt32(redrow["salstruct_id"].ToString()),
                    }
                    );
                }
                salary_ds.Dispose();
                connection.Dispose();
                return slrystruct_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int rsalrystructdelete(int rslrystrctdelt)
        {
            try
            {
                string DDD = "delete from tbl_mark_salarystructure where salstruct_id =" + rslrystrctdelt;
                salary_Con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int rsalrystructinsert(salarystructuredomain rslrystrct)
        {
            try
            {
                int dupvl = salary_Con.CheckDuplication("salstruct_head", "public.tbl_mark_salarystructure", " salstruct_type = '" + rslrystrct.salstruct_type + "' and salstruct_head = '" + rslrystrct.salstruct_head + "'", rslrystrct.salstruct_head.ToString());
                if (dupvl == 1)
                {
                    connection = salary_Con.GetPooledConnection();

                string mQuery = "insert into tbl_mark_salarystructure(salstruct_type,salstruct_head) values (@salstruct_type,@salstruct_head)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", rslrystrct.salstruct_type));
                    cmd.Parameters.Add(new NpgsqlParameter("@salstruct_head", rslrystrct.salstruct_head));

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

        public int rsalrystructupdate(salarystructuredomain rsalrystructup)
        {
            try
            {
                connection = salary_Con.GetPooledConnection();
                string Usql = "update tbl_mark_salarystructure set salstruct_type = @salstruct_type,salstruct_head = @salstruct_head where salstruct_id = @salstruct_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(Usql, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", rsalrystructup.salstruct_type));
                    cmd.Parameters.Add(new NpgsqlParameter("@salstruct_head", rsalrystructup.salstruct_head));
                    cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", rsalrystructup.salstruct_id));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

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
