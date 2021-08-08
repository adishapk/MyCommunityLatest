using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class RegistrationRepo : IRegistrationRepo
    {
        ConnectionRepository user_con = new ConnectionRepository();
        DataSet user_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<RegistrationDomain> rgetemail(string remail)
        {
            try
            {
                connection = user_con.GetPooledConnection();

                string Esql = "select reg_userid from tbl_mark_reg_users where reg_emailid ='" + remail + "'";
                user_ds = user_con.PG_SelectMasterDS(Esql, connection, null);
                IList<RegistrationDomain> user_list = new List<RegistrationDomain>();

                if (user_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in user_ds.Tables[0].Rows)
                    {
                        user_list.Add(new RegistrationDomain
                        {
                            reg_userid = Convert.ToInt32(redrow["reg_userid"].ToString()),

                        }
                        );
                    }
                }
                else
                {
                    user_list.Add(new RegistrationDomain
                    {
                        reg_userid = 0,

                    }
                                            );
                }
                user_ds.Dispose();
                connection.Dispose();

                return user_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserdetailsDomain> rgetlogin(string ruser, string rpass)
        {
            try
            {
                connection = user_con.GetPooledConnection();
                //string Lsql = "select reg_userid from tbl_mark_reg_users where (reg_username = '" + ruser + "' or reg_emailid = '" + ruser + "') and reg_password = '" + rpass + "'";
                string Lsql = @"select user_id, employee_id, user_name,user_layout,user_type_id from tbl_mark_userdetails where user_name = '" + ruser + "' and  user_password = '" + rpass + "'";
                user_ds = user_con.PG_SelectMasterDS(Lsql, connection, null);
                IList<UserdetailsDomain> user_list = new List<UserdetailsDomain>();

               // connection = user_con.GetPooledConnection();
                if (user_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in user_ds.Tables[0].Rows)
                    {
                        user_list.Add(new UserdetailsDomain
                        {
                            user_id = Convert.ToInt32(redrow["user_id"].ToString()),
                            user_type_id = Convert.ToInt32(redrow["user_type_id"].ToString()),
                            user_name = redrow["user_name"].ToString(),
                            user_layout = redrow["user_layout"].ToString(),
                            employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                            employee_name = Convert.ToInt32(redrow["employee_id"].ToString()) == 0 ? "" : user_con.GetTableValue(connection, "tbl_mark_emppersonnel", "emp_firstname ||' ' || emp_lastname", "employee_id = '" + redrow["employee_id"].ToString() + "'"),
                            employee_image = Convert.ToInt32(redrow["employee_id"].ToString()) == 0 ? "" : user_con.GetTableValue(connection, "tbl_mark_emppersonnel", "emp_photo", "employee_id = '" + redrow["employee_id"].ToString() + "'"),

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
                user_ds.Dispose();
                connection.Close();
                return user_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<RegistrationDomain> rgetuser(string rusname)
        {
            try
            {
                connection = user_con.GetPooledConnection();

                string Usql = "select reg_userid from tbl_mark_reg_users where reg_username = '" + rusname + "'";
                user_ds = user_con.PG_SelectMasterDS(Usql, connection, null);
                IList<RegistrationDomain> user_list = new List<RegistrationDomain>();

                if (user_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in user_ds.Tables[0].Rows)
                    {
                        user_list.Add(new RegistrationDomain
                        {
                            reg_userid = Convert.ToInt32(redrow["reg_userid"].ToString()),

                        }
                        );
                    }
                }
                else
                {
                    user_list.Add(new RegistrationDomain
                    {
                        reg_userid = 0,

                    }
                                            );
                }
                user_ds.Dispose();
                connection.Dispose();

                return user_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int rreginsert(RegistrationDomain rinsert)
        {
            try
            {
                connection = user_con.GetPooledConnection();

                string mQuery = "insert into tbl_mark_reg_users(reg_username,reg_usertype,reg_emailid,reg_password,reg_active) values (@reg_username,@reg_usertype,@reg_emailid,@reg_password,@reg_active)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@reg_username", rinsert.reg_username));
                    cmd.Parameters.Add(new NpgsqlParameter("@reg_usertype", rinsert.reg_usertype));
                    cmd.Parameters.Add(new NpgsqlParameter("@reg_emailid", rinsert.reg_emailid));
                    cmd.Parameters.Add(new NpgsqlParameter("@reg_password", rinsert.reg_password));
                    cmd.Parameters.Add(new NpgsqlParameter("@reg_active", rinsert.reg_active));

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

