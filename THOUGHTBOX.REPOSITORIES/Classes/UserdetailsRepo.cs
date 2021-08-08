using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class UserdetailsRepo : IUserdetilsRepo
    {
        private ConnectionRepository Conect_con = new ConnectionRepository();
        DataSet data_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int getusername(string userdupli)
        {
            try
            {
                connection = Conect_con.GetPooledConnection();
                string Usql = "select count(*) from tbl_mark_userdetails where user_name = '"+ userdupli+"'";
                data_ds = Conect_con.PG_SelectMasterDS(Usql, connection, null);
                int counter = Convert.ToInt32(data_ds.Tables[0].Rows[0][0].ToString());
                data_ds.Dispose();
                connection.Dispose();
                return counter;
   

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserdetailsDomain> rgetalluserdetails(int rgetalluser)
        {
            try
            {
                connection = Conect_con.GetPooledConnection();
                string TRR = "select user_id,employee_id,user_name,user_password,user_status,user_type_id,user_category from tbl_mark_userdetails order by user_name";
                data_ds = Conect_con.PG_SelectMasterDS(TRR, connection, null);
                IList<UserdetailsDomain> user_list = new List<UserdetailsDomain>();
                if (data_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in data_ds.Tables[0].Rows)
                {
                    user_list.Add(new UserdetailsDomain
                    {
                        employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                        user_id = Convert.ToInt32(redrow["user_id"].ToString()),
                        user_name = redrow["user_name"].ToString(),
                        user_password = redrow["user_password"].ToString(),
                        user_status = redrow["user_status"].ToString(),
                        user_type_id = Convert.ToInt32(redrow["user_type_id"].ToString()),
                        user_category = redrow["user_category"].ToString(),

                    }
                    );
                }
                }
                else
                {
                    user_list.Add(new UserdetailsDomain
                    {
                        user_id = -1,
                    }
                    );
                }
                data_ds.Dispose();
                connection.Dispose();
                return user_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ruserdetailsdelete(int rusrdetailsdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_userdetails where user_id =" + rusrdetailsdelet;
                Conect_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ruserdetailsinsert(UserdetailsDomain rusrdetailsinsrt)
        {
            try
            {
                connection = Conect_con.GetPooledConnection();
                string mQuery = "insert into tbl_mark_userdetails(user_category,employee_id,user_name,user_password,user_status,user_type_id) values (@user_category,@employee_id,@user_name,@user_password,@user_status,@user_type_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@user_category", rusrdetailsinsrt.user_category));
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", rusrdetailsinsrt.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_name", rusrdetailsinsrt.user_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_password", rusrdetailsinsrt.user_password));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_status", rusrdetailsinsrt.user_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_type_id", rusrdetailsinsrt.user_type_id));


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

        public int ruserdetailupdate(UserdetailsDomain rusrdetailsupdt)
        {
            try
            {
                connection = Conect_con.GetPooledConnection();
                string mQuery = "update tbl_mark_userdetails set user_category = @user_category,employee_id = @employee_id,user_password=@user_password,user_status=@user_status,user_type_id=@user_type_id where user_id = @user_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@user_category", rusrdetailsupdt.user_category));
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", rusrdetailsupdt.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_password", rusrdetailsupdt.user_password));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_status", rusrdetailsupdt.user_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@user_type_id", rusrdetailsupdt.user_type_id));


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
    }
}
