using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateDivisionRepo : ICreateDivisionRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int divisioninsert(CreateDivisionDomain divisnin)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("division_name", "public.tbl_mark_division", "  company_id = " + divisnin.company_id + " and department_id = " + divisnin.department_id + " and division_name = '" + divisnin.division_name + "'", divisnin.division_name.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_division(company_id,department_id,division_name,division_code,division_details) values (@company_id,@department_id,@division_name,@division_code,@division_details)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(divisnin.company_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(divisnin.department_id)));
                        cmd.Parameters.Add(new NpgsqlParameter("@division_name", divisnin.division_name));
                        cmd.Parameters.Add(new NpgsqlParameter("@division_code", divisnin.division_code));
                        cmd.Parameters.Add(new NpgsqlParameter("@division_details", divisnin.division_details == null ? "" : divisnin.division_details));

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

        public int divisndelete(int divisndelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_division where division_id =" + divisndelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int divisnupdate(CreateDivisionDomain divisnup)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_division set company_id = @company_id,department_id = @department_id,division_name=@division_name,division_code=@division_code,division_details=@division_details where division_id = @division_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@division_id", divisnup.division_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@company_id", Convert.ToInt32(divisnup.company_id)));
                    cmd.Parameters.Add(new NpgsqlParameter("@department_id", Convert.ToInt32(divisnup.department_id)));
                    cmd.Parameters.Add(new NpgsqlParameter("@division_name", divisnup.division_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@division_code", divisnup.division_code));
                    cmd.Parameters.Add(new NpgsqlParameter("@division_details", divisnup == null ? "" : divisnup.division_details));

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

        public IList<CreateDivisionDomain> getalldivisn(int getalldivisn)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select division_id,division_name,division_code,division_details,company_id,department_id from tbl_mark_division order by division_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateDivisionDomain> emperson_list = new List<CreateDivisionDomain>();
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                    {
                        emperson_list.Add(new CreateDivisionDomain
                        {
                            division_id = Convert.ToInt32(redrow["division_id"].ToString()),
                            division_name = redrow["division_name"].ToString(),
                            division_code = redrow["division_code"].ToString(),
                            division_details = redrow["division_details"].ToString(),
                            company_id = Convert.ToInt32(redrow["company_id"].ToString()),
                            department_id = Convert.ToInt32(redrow["department_id"].ToString()),
                        }
                        );
                    }
                }
                else
                {
                    emperson_list.Add(new CreateDivisionDomain
                    {
                        division_id = -1,
 
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

        public string GetDepartment(int departmentid)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select department_name from tbl_mark_department where department_id = " + departmentid + "";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                string deptname = "";
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    deptname = Master_ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    deptname = "";
                }
                Master_ds.Dispose();
                connection.Dispose();
                return deptname;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
