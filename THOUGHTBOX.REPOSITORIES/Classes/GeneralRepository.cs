using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class GeneralRepository : IGeneralRepository
    {
        ConnectionRepository connectionrepository = new ConnectionRepository();
        Log Log = new Log();
        DataSet ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public string getautonumber(string parameter, int regionid)
        {
           
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string Ano = connectionrepository.GetAutonumber(parameter, connection, transaction);
                connection.Dispose();
                return Ano;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public IList<Generaldomain> getGetGeneralValuesallthree(int reg_id, string subparentid, string mastertype)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string mid = "0";
                string mQuery = "SELECT master_id FROM public.tbl_re_master_general where reg_id = " + reg_id + " and master_type = '" + mastertype + "'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    mid = ds.Tables[0].Rows[0][0].ToString();
                }

                mQuery = "SELECT master_id as generalid, master_name as generalname FROM public.tbl_re_master_general where reg_id = " + reg_id + " and master_parentid = (select master_id  FROM public.tbl_re_master_general where master_type='" + mid + "' and master_name='" + subparentid + "' ) and master_subparentid = 0 ";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["generalid"].ToString()),
                            Generalval2 = dr["generalname"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }

        public IList<Generaldomain> getGeneraltwovalueresultfromanytable(int reg_id, string condtionval, string tablename1, string tablename2, string innerjoinfield, string conditionfield)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();

                string mid = "0";
                string mQuery = "SELECT master_id FROM public.tbl_re_master_general where reg_id = " + reg_id + " and master_name = '" + condtionval + "'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    mid = ds.Tables[0].Rows[0][0].ToString();
                }

                mQuery = "SELECT Tb1.employ_id as Generalval1, concat(employ_fname, ' ',employ_lname) as Generalval2 FROM public." + tablename1 + " as Tb1 inner join public." + tablename2 + " as Tb2 on Tb1." + innerjoinfield + "= Tb2." + innerjoinfield + " where Tb1.reg_id = " + reg_id + " and " + conditionfield + " = " + mid + "";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }
        public IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();

                string mQuery = "";
                if (conditionval2 == "NIL")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield3 + " = '" + conditionval3 + "' and reg_id= " + Regid;
                }
                else
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield2 + " = '" + conditionval2 + "' and " + conditionfield3 + " = '" + conditionval3 + "' and reg_id= " + Regid;
                }

                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                            Gneralaval3 = dr["Generalval3"].ToString(),
                            Gneralaval4 = dr["Generalval4"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }
        public IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string mQuery = "";
                if (decisionvalue == "NIL1")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " as A inner join public." + Tablename2 + " as B on A." + Connectfield1 + " =  B." + Connectfield2 + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield2 + " = '" + conditionval2 + "'";
                }
                else if (decisionvalue == "NIL2")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " where " + conditionfield1 + " = '" + conditionval1 + "'";
                }
                else if (decisionvalue == "NIL3")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield2 + " = '" + conditionval2 + "'";
                }
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                            Gneralaval3 = dr["Generalval3"].ToString(),
                            Gneralaval4 = dr["Generalval4"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> fillgenerallistingpage(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2, string Orderby1, string Orderby2)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string mQuery = "";
                if (decisionvalue == "NIL1")
                {
                    if (Fieldname1 != "NIL")
                    {
                        mQuery = "SELECT " + Fieldname1 + " as Generalval1";
                    }
                    if (Fieldname2 != "NIL")
                    {
                        mQuery += ", " + Fieldname2 + " as Generalval2";
                    }
                    if (Fieldname3 != "NIL")
                    {
                        mQuery += ", " + Fieldname3 + " as Generalval3";
                    }
                    if (Fieldname4 != "NIL")
                    {
                        mQuery += ", " + Fieldname4 + " as Generalval4";
                    }
                    if (Fieldname5 != "NIL")
                    {
                        mQuery += ", " + Fieldname5 + " as Generalval5";
                    }
                    if (Fieldname6 != "NIL")
                    {
                        mQuery += ", " + Fieldname6 + " as Generalval6";
                    }
                    if (Fieldname7 != "NIL")
                    {
                        mQuery += ", " + Fieldname7 + " as Generalval7";
                    }
                    if (Fieldname8 != "NIL")
                    {
                        mQuery += ", " + Fieldname8 + " as Generalval8";
                    }
                    if (Fieldname9 != "NIL")
                    {
                        mQuery += ", " + Fieldname9 + " as Generalval9";
                    }
                    if (Fieldname10 != "NIL")
                    {
                        mQuery += ", " + Fieldname10 + " as Generalval10";
                    }

                    mQuery += " FROM public." + Tablename1 + " as A inner join public." + Tablename2 + " as B on A." + Connectfield1 + " =  B." + Connectfield2 + " where reg_id = " + Regid;

                    if (conditionfield1 != "NIL")
                    {
                        mQuery += " and " + conditionfield1 + " = '" + conditionval1 + "'";
                    }
                    if (conditionfield2 != "NIL")
                    {
                        mQuery += " and " + conditionfield2 + " = '" + conditionval2 + "'";
                    }
                    if (conditionfield3 != "NIL")
                    {
                        mQuery += " and " + conditionfield3 + " = '" + conditionval3 + "'";
                    }
                    if (Orderby1 != "NIL")
                    {
                        mQuery += " order by " + Orderby1;
                    }
                    if (Orderby2 != "NIL")
                    {
                        mQuery += "," + Orderby2;
                    }

                }

                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                            Gneralaval3 = dr["Generalval3"].ToString(),
                            Gneralaval4 = dr["Generalval4"].ToString(),
                            Gneralaval5 = dr["Generalval5"].ToString(),
                            Gneralaval6 = dr["Generalval6"].ToString(),
                            Gneralaval7 = dr["Generalval7"].ToString(),

                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
               ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> getdecisionhistory(int jobcardid, string Requtype)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string mQuery = "SELECT requ_appby as Generalval1,requ_date as Generalval2,requ_time as Generalval3,requ_status as Generalval4,requ_comments as Generalval5,requ_addl1 as Generalval6,requ_addl2 as Generalval7,requ_addl3 as Generalval8,requ_addl4 as Generalval9,requ_addl5 as Generalval10 FROM public.tbl_re_doc_decision_details where request_id = " + jobcardid + " and requ_type_id = '" + Requtype + "'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                            Gneralaval3 = dr["Generalval3"].ToString(),
                            Gneralaval4 = dr["Generalval4"].ToString(),
                            Gneralaval5 = dr["Generalval5"].ToString(),
                            Gneralaval6 = dr["Generalval6"].ToString(),
                            Gneralaval7 = dr["Generalval7"].ToString(),
                            Gneralaval8 = dr["Generalval8"].ToString(),
                            Gneralaval9 = dr["Generalval9"].ToString(),
                            Gneralaval10 = dr["Generalval10"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public int getalertcount(int dash_requ_by, string alertstat)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                int alercount = 0;
                string mQuery = "SELECT count(*) FROM public.tbl_re_dashboard_alerts where dash_requ_by = " + dash_requ_by + " and dash_viewstat = 'N'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    alercount = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                ds.Dispose();
                connection.Dispose();
                return alercount;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> getalertdata(int dash_requ_by, string alertstat)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();

                string mQuery = "SELECT dash_requ_id,dash_requ_type,dash_message,dash_datetime,dash_image,dash_requ_by FROM public.tbl_re_dashboard_alerts where dash_requ_by = " + dash_requ_by + " and dash_viewstat = 'N'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> alert_data = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        alert_data.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["dash_requ_id"].ToString()),
                            Generalval2 = dr["dash_requ_type"].ToString(),
                            Gneralaval3 = dr["dash_message"].ToString(),
                            Gneralaval4 = dr["dash_datetime"].ToString(),
                            Gneralaval5 = dr["dash_image"].ToString(),
                            Generalval11 = Convert.ToInt32(dr["dash_requ_by"].ToString()),
                        }
                        );
                    }
                }
                else
                {
                    alert_data.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return alert_data;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }

        public int setalertdata(int dash_requ_by, int alertstat)
        {
            try
            {

                connection = connectionrepository.GetPooledConnection();

                string mQuery = "UPDATE public.tbl_re_dashboard_alerts SET dash_viewstat =@dash_viewstat WHERE dash_requ_id = @dash_requ_id and dash_requ_by = @dash_requ_by";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_viewstat", "Y"));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_id", dash_requ_by));
                    cmd.Parameters.Add(new NpgsqlParameter("@dash_requ_by", alertstat));

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

        public IList<Generaldomain> generallistfillpopup(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Orderby1, string Orderby2)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                string mQuery = "";
                if (decisionvalue == "NIL1")
                {
                    if (Fieldname1 != "NIL")
                    {
                        mQuery = "SELECT " + Fieldname1 + " as Generalval1";
                    }
                    if (Fieldname2 != "NIL")
                    {
                        mQuery += ", " + Fieldname2 + " as Generalval2";
                    }
                    if (Fieldname3 != "NIL")
                    {
                        mQuery += ", " + Fieldname3 + " as Generalval3";
                    }
                    if (Fieldname4 != "NIL")
                    {
                        mQuery += ", " + Fieldname4 + " as Generalval4";
                    }
                    if (Fieldname5 != "NIL")
                    {
                        mQuery += ", " + Fieldname5 + " as Generalval5";
                    }
                    if (Fieldname6 != "NIL")
                    {
                        mQuery += ", " + Fieldname6 + " as Generalval6";
                    }
                    if (Fieldname7 != "NIL")
                    {
                        mQuery += ", " + Fieldname7 + " as Generalval7";
                    }
                    if (Fieldname8 != "NIL")
                    {
                        mQuery += ", " + Fieldname8 + " as Generalval8";
                    }
                    if (Fieldname9 != "NIL")
                    {
                        mQuery += ", " + Fieldname9 + " as Generalval9";
                    }
                    if (Fieldname10 != "NIL")
                    {
                        mQuery += ", " + Fieldname10 + " as Generalval10";
                    }

                    mQuery += " FROM public." + Tablename1 + " where  ";

                    if (conditionfield1 != "NIL")
                    {
                        mQuery += conditionfield1 + " = '" + conditionval1 + "'";
                    }
                    if (conditionfield2 != "NIL")
                    {
                        mQuery += " and " + conditionfield2 + " = '" + conditionval2 + "'";
                    }
                    if (conditionfield3 != "NIL")
                    {
                        mQuery += " and " + conditionfield3 + " = '" + conditionval3 + "'";
                    }
                    if (Orderby1 != "NIL")
                    {
                        mQuery += " order by " + Orderby1;
                    }
                    if (Orderby2 != "NIL")
                    {
                        mQuery += "," + Orderby2;
                    }

                }

                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval2 = dr["Generalval1"].ToString(),
                            Gneralaval3 = dr["Generalval2"].ToString(),
                            Gneralaval4 = dr["Generalval3"].ToString(),
                            Gneralaval5 = dr["Generalval4"].ToString(),

                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public Generaldomain GetGeneralValuesFromAnyTableTT(string Paramstring1, string Paramstring2, string paramTblname, string Field1, string Field2, string ConditionField1, string ConditionField2, string Condition1, string Condition2, string Decisionval)
        {
            connection = connectionrepository.GetPooledConnection();
            Generaldomain CreateGeneralValues = new Generaldomain();

            if (Decisionval == "NIL")
            {
                if (Condition2 == "NIL")
                {
                   string mQuery = "SELECT " + Field1 + " as Generalval1, " + Field2 + " as Generalval2 FROM public." + paramTblname + " where " + ConditionField1 + " = " + Condition1 + "";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CreateGeneralValues.Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString());
                            CreateGeneralValues.Generalval2 = dr["Generalval2"].ToString();
                        }
                    }
                    else
                    {
                        CreateGeneralValues.Generalval1 = -1;
                    }
                }

               // return CreateGeneralValues;
            }
       
            else
            { 
            string mid = "0";
            string mQuery = "select master_id from tbl_mark_mastertypevalues where master_valuename ='" + Paramstring2 + "' and master_typename = (select master_id from tbl_mark_mastertypevalues where master_typename = '" + Paramstring1 + "')::varchar(50)";
           // string mQuery = "SELECT master_id FROM public.tbl_mark_mastertypevalues where master_valuename = '" + Paramstring1 + "'";
            ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                if (ds.Tables[0].Rows.Count > 0)
            {
                mid = ds.Tables[0].Rows[0][0].ToString();
            }

            if (Condition2 == "NIL")
            {
                mQuery = "SELECT " + Field1 + " as Generalval1, " + Field2 + " as Generalval2 FROM public." + paramTblname + " where " + ConditionField1 + " = '" + mid + "'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                    if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                          CreateGeneralValues.Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString());
                          CreateGeneralValues.Generalval2 = dr["Generalval2"].ToString();
                    }
                }
                else
                {
                        CreateGeneralValues.Generalval1 = -1;
                }
                }

                //return CreateGeneralValues;
            }
            ds.Dispose();
            connection.Dispose();
            return CreateGeneralValues;
        }

        public IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();

                string mQuery = "";
                if (decisionvalue == "NIL1")
                {
                    mQuery = "SELECT A." + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " as A inner join public." + Tablename2 + " as B on A." + Connectfield1 + " =  B." + Connectfield2 + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield2 + " = '" + conditionval2 + "'";
                }
                else if (decisionvalue == "NIL2")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " where " + conditionfield1 + " = '" + conditionval1 + "'";
                }
                else if (decisionvalue == "NIL3")
                {
                    mQuery = "SELECT " + Fieldname1 + " as Generalval1," + Fieldname2 + " as Generalval2," + Fieldname3 + " as Generalval3," + Fieldname4 + " as Generalval4 FROM public." + Tablename1 + " where " + conditionfield1 + " = '" + conditionval1 + "' and " + conditionfield2 + " = '" + conditionval2 + "'";
                }
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<Generaldomain> CreateGeneralValues = new List<Generaldomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(dr["Generalval1"].ToString()),
                            Generalval2 = dr["Generalval2"].ToString(),
                            Gneralaval3 = dr["Generalval3"].ToString(),
                            Gneralaval4 = dr["Generalval4"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new Generaldomain
                    {
                        Generalval1 = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename)
        {
            throw new NotImplementedException();
        }

        public IList<MastertypeDomain> getGeneraltwovalueresultfromanytablelist(string tablename, string decisionvalue, string Fieldtoretrieve1, string Fieldtoretrieve2, string Fieldtoretrieve3, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionfield4)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                if (decisionvalue == "NIL")
                {
                    string mQuery = "SELECT count(*) as Generalval2 FROM public." + tablename + " where " + Fieldname1 + " = " + conditionfield1;
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                }
                else if (decisionvalue == "NIL1")
                {
                    string mQuery = "SELECT count(*) as Generalval2 FROM public." + tablename + " where " + Fieldname1 + " = '" + conditionfield1 + "' and " + Fieldname2 + " = '" + conditionfield2 + "'";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                }
                else if (decisionvalue == "NIL2")
                {
                    string mQuery = "SELECT count(*) as Generalval2 FROM public." + tablename + " where " + Fieldname1 + " = '" + conditionfield1 + "' and " + Fieldname2 + " = '" + conditionfield2  + "'";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                }
                else if (decisionvalue == "TwoTables1")
                {
                    string mQuery = "SELECT " + Fieldtoretrieve1 + " FROM public." + tablename + " where " + Fieldname1 + " = '" + conditionfield1 + "'";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                    int cstid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    mQuery = "SELECT cstmr_name as Generalval2 FROM public.tbl_re_customer_pdetails where customer_id = " + cstid;
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                    conditionfield1 = cstid.ToString();

                }
                else if (decisionvalue == "TwoTables2")
                {
                    string mQuery = "SELECT " + Fieldtoretrieve1 + " FROM public." + tablename + " where " + Fieldname1 + " = '" + conditionfield1 + "'";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                    int modelid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    mQuery = "SELECT master_name as Generalval2 FROM public.tbl_re_master_general where master_id = " + modelid;
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                    conditionfield1 = modelid.ToString();

                }
                else
                {
                    string mQuery = "SELECT " + Fieldtoretrieve1 + " as Generalval2 FROM public." + tablename + " where " + Fieldname1 + " = '" + conditionfield1 + "'";
                    ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);
                }

                IList<MastertypeDomain> CreateGeneralValues = new List<MastertypeDomain>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CreateGeneralValues.Add(new MastertypeDomain
                        {
                            master_id = Convert.ToInt32(conditionfield1),
                            master_typename = dr["Generalval2"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    CreateGeneralValues.Add(new MastertypeDomain
                    {
                        master_id = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return CreateGeneralValues;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public int GetdeptheadID(int Requestid, string Requesttype, int employid)
        {
            try
            {
                connection = connectionrepository.GetPooledConnection();
                int deptid = 0;
                int appbyid = 0;
                string mQuery = "SELECT requ_appby FROM public.tbl_mark_approval_summary where request_id = " + Requestid + " and requ_type_id = '" + Requesttype + "' and requ_status = 'Prepared'";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    appbyid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                mQuery = "SELECT emp_reportedto FROM public.tbl_mark_emppersonnel where employee_id = " + appbyid + "";
                ds = connectionrepository.PG_SelectMasterDS(mQuery, connection, null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    deptid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }

               

                if (deptid == employid)
                {
                    deptid = appbyid;
                }

                ds.Dispose();
                connection.Dispose();
                return deptid;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}






