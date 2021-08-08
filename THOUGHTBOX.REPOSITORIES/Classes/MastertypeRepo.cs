using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class MastertypeRepo : IMastertypeRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;
        Log Log = new Log();
        public IList<MastertypeDomain> Getspecificmastervalues(string checkfield)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_id,master_valuename from tbl_mark_mastertypevalues where master_typename = (select master_id::varchar(255) from tbl_mark_mastertypevalues where master_typename = '" + checkfield + "')";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<MastertypeDomain> createmaster_list = new List<MastertypeDomain>();
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                    {
                        createmaster_list.Add(new MastertypeDomain
                        {
                            master_id = Convert.ToInt32(redrow["master_id"].ToString()),
                            master_valuename = redrow["master_valuename"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    createmaster_list.Add(new MastertypeDomain
                    {
                        master_id = -1,
                    }
                       );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return createmaster_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetmastertypeName(int mastertypenameval)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_typename from tbl_mark_mastertypevalues where master_id = " + mastertypenameval + "";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                string mastertypename = "";
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    mastertypename = Master_ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    mastertypename = "";
                }
                Master_ds.Dispose();
                connection.Dispose();
                return mastertypename;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<MastertypeDomain> rgetcreatemastertype(int rgetmastertypecreate)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_id,master_typename from tbl_mark_mastertypevalues where master_flag ='Y'";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<MastertypeDomain> createmaster_list = new List<MastertypeDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    createmaster_list.Add(new MastertypeDomain
                    {
                        master_typename = redrow["master_typename"].ToString(),
                        master_id = Convert.ToInt32(redrow["master_id"].ToString()),
                    }
                    );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return createmaster_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<MastertypeDomain> rgetfullmastertype(int rgetmastertype)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_id,master_typename,master_flag from tbl_mark_mastertypevalues where master_flag ='Y'";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<MastertypeDomain> mastertype_list = new List<MastertypeDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    mastertype_list.Add(new MastertypeDomain
                    {
                        master_typename = redrow["master_typename"].ToString(),
                        master_flag = redrow["master_flag"].ToString(),
                        master_id = Convert.ToInt32(redrow["master_id"].ToString()),
                    }
                    );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return mastertype_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<MastertypeDomain> rgetfullmastervalues(int rgetmastervalues)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_id,master_valuename,master_typename,master_valueremarks,master_valueflag from tbl_mark_mastertypevalues where master_flag ='N' order by master_typename,master_valuename";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<MastertypeDomain> mastervalue_list = new List<MastertypeDomain>();
                if (Master_ds.Tables[0].Rows.Count > 0)
                { 
                    foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    mastervalue_list.Add(new MastertypeDomain
                    {
                        master_valuename = redrow["master_valuename"].ToString(),
                        master_typename = redrow["master_typename"].ToString(),
                        master_valueremarks = redrow["master_valueremarks"].ToString(),
                        master_valueflag = redrow["master_valueflag"].ToString(),
                        master_id = Convert.ToInt32(redrow["master_id"].ToString()),

                    }
                    );
                }
                }
                else
                {
                    mastervalue_list.Add(new MastertypeDomain
                    {
                        master_id = -1,
                    }
                   );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return mastervalue_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int rmastertypedeleting(int rmastertypdelt)
        {
            try
            {
                string DDD = "delete from tbl_mark_mastertypevalues where master_id =" + rmastertypdelt;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int rmastertypeinsert(MastertypeDomain rmaster)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("master_typename", "public.tbl_mark_mastertypevalues", " master_flag = 'Y' and master_typename = '" + rmaster.master_typename + "'", rmaster.master_typename.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string mQuery = "insert into tbl_mark_mastertypevalues(master_typename,master_flag) values (@master_typename,@master_flag)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@master_typename", rmaster.master_typename));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_flag", rmaster.master_flag));

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

        public int rmastertypeupdate(MastertypeDomain rmasterup)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("master_typename", "public.tbl_mark_mastertypevalues", " master_flag = 'Y' and master_typename = '" + rmasterup.master_typename + "'", rmasterup.master_typename.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();
                    string Usql = "update tbl_mark_mastertypevalues set master_typename = @master_typename,master_flag = @master_flag where master_id = @master_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(Usql, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@master_typename", rmasterup.master_typename));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_flag", rmasterup.master_flag));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_id", rmasterup.master_id));

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

        public int rmastervaluedeleting(int rmastervaludelt)
        {
            try
            {
                string DDD = "delete from tbl_mark_mastertypevalues where master_id =" + rmastervaludelt;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int rmastervaluesinsert(MastertypeDomain rmastervaluein)
        {
            try
            {
                int dupvl = Master_con.CheckDuplication("master_valuename", "public.tbl_mark_mastertypevalues", " master_flag = 'N' and master_typename = '" + rmastervaluein.master_typename + "' and master_valuename = '" + rmastervaluein.master_valuename + "'", rmastervaluein.master_valuename.ToString());
                if (dupvl == 1)
                {
                    connection = Master_con.GetPooledConnection();

                    string mQuery = "insert into tbl_mark_mastertypevalues(master_valuename,master_typename,master_flag,master_valueremarks,master_valueflag) values (@master_valuename,@master_typename,@master_flag,@master_valueremarks,@master_valueflag)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@master_valuename", rmastervaluein.master_valuename));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_typename", rmastervaluein.master_typename));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_flag", rmastervaluein.master_flag));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_valueremarks", rmastervaluein.master_valueremarks == null ? "" : rmastervaluein.master_valueremarks));
                        cmd.Parameters.Add(new NpgsqlParameter("@master_valueflag", rmastervaluein.master_valueflag));

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

        public int rmastervalueupdate(MastertypeDomain rmastervalueup)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string Usql = "update tbl_mark_mastertypevalues set master_valuename = @master_valuename,master_typename = @master_typename,master_valueremarks = @master_valueremarks,master_valueflag = @master_valueflag where master_id = @master_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(Usql, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@master_valuename", rmastervalueup.master_valuename));
                    cmd.Parameters.Add(new NpgsqlParameter("@master_typename", rmastervalueup.master_typename));
                    cmd.Parameters.Add(new NpgsqlParameter("@master_valueremarks", rmastervalueup.master_valueremarks == null ? "" : rmastervalueup.master_valueremarks));
                    cmd.Parameters.Add(new NpgsqlParameter("@master_valueflag", rmastervalueup.master_valueflag));
                    cmd.Parameters.Add(new NpgsqlParameter("@master_id", rmastervalueup.master_id));

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

        //----------------------------Create Menu-----------------------------------------------------
        public IList<MastertypeDomain> selectAllMenu(string condition)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = @"SELECT menu_id, menu_name, parent_id, file_name, icon_name FROM public.tbl_mark_menu "+condition;
               
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                connection = Master_con.GetPooledConnection();
                IList<MastertypeDomain> mastervalue_list = new List<MastertypeDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    mastervalue_list.Add(new MastertypeDomain
                    {
                        master_valuename = redrow["menu_name"].ToString(),
                        master_typename = redrow["file_name"]==null?"": redrow["file_name"].ToString(),
                        master_valueremarks = redrow["icon_name"]==null?"":redrow["icon_name"].ToString(),
                        master_parent_text = Convert.ToInt32(redrow["parent_id"].ToString())==0? "NIL":Master_con.GetTableValue(connection, "public.tbl_mark_menu", "menu_name", "menu_id = '" + redrow["parent_id"].ToString() + "'"),

                        master_parentid = Convert.ToInt32(redrow["parent_id"].ToString()),
                        master_id = Convert.ToInt32(redrow["menu_id"].ToString()),
                    }
                    );
                }
                Master_ds.Dispose();
                connection.Dispose();
                return mastervalue_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int deleteMenu(int Id)
        {
            try
            {
                string mQuery = "DELETE FROM public.tbl_mark_menu where menu_id ="+Id;
                Master_con.PG_ManipulationMaster(mQuery);
                return 1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public int insertMenu(MastertypeDomain Mastername)
        { 
           try
            {
            connection = Master_con.GetPooledConnection();
            string fields = "menu_name, parent_id, file_name, icon_name";
            string values = "@menu_name, @parent_id, @file_name, @icon_name";
            string mQuery = @"insert into public.tbl_mark_menu(" + fields+") values ("+values+")";
            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
            {
                cmd.Parameters.Add(new NpgsqlParameter("@menu_name", Mastername.master_valuename));
                cmd.Parameters.Add(new NpgsqlParameter("@parent_id", Mastername.master_parentid));               
                cmd.Parameters.Add(new NpgsqlParameter("@file_name", Mastername.master_typename == null ? "" : Mastername.master_typename));
                cmd.Parameters.Add(new NpgsqlParameter("@icon_name", Mastername.master_valueremarks == null ? "" : Mastername.master_valueremarks));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
                connection.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public int updateMenu(MastertypeDomain Mastername)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = @"update public.tbl_mark_menu set menu_name=@menu_name, parent_id=parent_id, file_name=@file_name, icon_name=@icon_name where menu_id =@menu_id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@menu_name", Mastername.master_valuename));
                    cmd.Parameters.Add(new NpgsqlParameter("@parent_id", Mastername.master_parentid));
                    cmd.Parameters.Add(new NpgsqlParameter("@file_name", Mastername.master_typename == null ? "" : Mastername.master_typename));
                    cmd.Parameters.Add(new NpgsqlParameter("@icon_name", Mastername.master_valueremarks == null ? "" : Mastername.master_valueremarks));
                    cmd.Parameters.Add(new NpgsqlParameter("@menu_id", Mastername.master_id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                connection.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public string SelectmastervaluebyID(int masterid)
        {
            try
            {
                string masterval = "";
                connection = Master_con.GetPooledConnection();
                string TRR = "select master_valuename from tbl_mark_mastertypevalues where master_id =" + masterid + "";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
              
                if (Master_ds.Tables[0].Rows.Count > 0)
                {
                    masterval = Master_ds.Tables[0].Rows[0][0].ToString(); 
                }
             
                Master_ds.Dispose();
                connection.Dispose();
                return masterval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

