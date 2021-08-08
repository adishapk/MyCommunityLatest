using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateDepartmentRepo : ICreateDepartmentRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int departmentdelete(int departdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_department where department_id =" + departdelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int departmentinsert(CreateDepartmentDomain departin)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("department_name", "public.tbl_mark_department", "  company_id = " + departin.Company_id + " and department_name = '" + departin.department_name + "'", departin.department_name.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_department(company_id,department_name,department_code,department_details) values (@company_id,@department_name,@department_code,@department_details)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(departin.Company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_name", departin.department_name));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_code", departin.department_code));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_details", departin.department_details == null ? "" : departin.department_details));

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

        public int departmentupdate(CreateDepartmentDomain departup)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_department set department_name = @department_name,department_code = @department_code,department_details=@department_details,company_id=@company_id where department_id = @department_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@department_id", departup.department_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@department_name", departup.department_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@department_code", departup.department_code));
                    cmd.Parameters.Add(new NpgsqlParameter("@department_details", departup.department_details == null ? "" : departup.department_details));
                    cmd.Parameters.Add(new NpgsqlParameter("@company_id", departup.Company_id));

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

        public IList<CreateDepartmentDomain> getalldepartment(int getalldepart)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select department_id,department_name,department_code,department_details,company_id from tbl_mark_department order by department_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateDepartmentDomain> emperson_list = new List<CreateDepartmentDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateDepartmentDomain
                    {
                        department_id = Convert.ToInt32(redrow["department_id"].ToString()),
                        department_name = redrow["department_name"].ToString(),
                        department_code = redrow["department_code"].ToString(),
                        department_details = redrow["department_details"].ToString(),
                        Company_id = Convert.ToInt32(redrow["company_id"].ToString()),

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

        public IList<CreateDepartmentDomain> getalldepartmentdd(int getalldepartdd)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select department_id,department_name from tbl_mark_department where company_id =" + getalldepartdd + " order by department_name ";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateDepartmentDomain> emperson_list = new List<CreateDepartmentDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateDepartmentDomain
                    {
                        department_id = Convert.ToInt32(redrow["department_id"].ToString()),
                        department_name = redrow["department_name"].ToString(),
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

        public string GetCompanyName(int companyid)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select company_name from tbl_mark_company where company_id = " + companyid + "";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                string compname = "";
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    compname = Master_ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    compname = "";
                }
                Master_ds.Dispose();
                connection.Dispose();
                return compname;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
