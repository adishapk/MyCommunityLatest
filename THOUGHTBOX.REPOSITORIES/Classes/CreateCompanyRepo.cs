using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateCompanyRepo : ICreateCompanyRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int companydelete(int companydelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_company where company_id =" + companydelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int companyinsert(CreateCompanyDomain companyin)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("company_name", "public.tbl_mark_company", " company_name = '" + companyin.company_name + "'", companyin.company_name.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_company(company_name,company_code,company_details) values (@company_name,@company_code,@company_details)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {

                        cmd.Parameters.Add(new NpgsqlParameter("@company_name", companyin.company_name));
                        cmd.Parameters.Add(new NpgsqlParameter("@company_code", companyin.company_code));
                        cmd.Parameters.Add(new NpgsqlParameter("@company_details", companyin.company_details == null ? "" : companyin.company_details));





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

        public int companyupdate(CreateCompanyDomain companyup)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_company set company_name = @company_name,company_code = @company_code,company_details=@company_details where company_id = @company_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {

                    cmd.Parameters.Add(new NpgsqlParameter("@company_id", companyup.company_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@company_name", companyup.company_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@company_code", companyup.company_code));
                    cmd.Parameters.Add(new NpgsqlParameter("@company_details", companyup.company_details == null ? "" : companyup.company_details));


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

        public IList<CreateCompanyDomain> getallcompany(int getallcomp)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select company_id,company_name,company_code,company_details from tbl_mark_company order by company_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateCompanyDomain> emperson_list = new List<CreateCompanyDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateCompanyDomain
                    {
                        company_id = Convert.ToInt32(redrow["company_id"].ToString()),
                        company_name = redrow["company_name"].ToString(),
                        company_code = redrow["company_code"].ToString(),
                        company_details = redrow["company_details"].ToString(),


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

        public IList<CreateCompanyDomain> getallcompanyfordd(int getallcompdd)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select company_id,company_name from tbl_mark_company order by company_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateCompanyDomain> emperson_list = new List<CreateCompanyDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateCompanyDomain
                    {
                        company_id = Convert.ToInt32(redrow["company_id"].ToString()),
                        company_name = redrow["company_name"].ToString(),
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
    }
}
