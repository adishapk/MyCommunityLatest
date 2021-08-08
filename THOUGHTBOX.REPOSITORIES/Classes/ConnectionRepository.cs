using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;
using System.IO;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class ConnectionRepository
    {
        NpgsqlConnection _conn;
        Log Log = new Log();
        public DataSet PG_SelectMasterDS(string mQuery, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            try
            {
                _conn = GetPooledConnection();
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(dt);
                    ds.Tables.Add(dt);
                    cmd.Dispose();
                    //_conn.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }
        }

        public string PG_SelectMaster(string mQuery, NpgsqlConnection connection, NpgsqlTransaction transaction)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection, transaction))
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmd.Dispose();
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0][0].ToString();
                    else

                        return "";
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }
        }

        public void PG_ManipulationMaster(string mQuery)
        {

            _conn = GetPooledConnection();
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
                {
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                _conn.Close();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }

        }
        public NpgsqlConnection GetPooledConnection()


        {
            try
            {
                if (_conn == null || _conn.State == ConnectionState.Closed)
                {

                    string strConnString = "Server=localhost;Port=5433;Database=MarketingLTE;User Id=postgres;Password=system";

                    //string strConnString = "Server=localhost;Port=5432;Database=finapp;User Id=postgres;Password=system";
                    _conn = new NpgsqlConnection();
                    _conn.ConnectionString = strConnString.Trim();
                    _conn.Open();
                }
                else if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }
                return _conn;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }
        }

        public int CheckDuplication(string col, string tbl, string condition, string parameter)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            _conn = GetPooledConnection();
            string mQuery = "select " + col + " from " + tbl + " where " + condition;
            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
            {
                cmd.Parameters.Add(new NpgsqlParameter(col, parameter));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                ds.Tables.Add(dt);
                cmd.Dispose();
            }
            _conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int CheckDuplication1(string col, string tbl, string condition, string parameter, int regid)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            _conn = GetPooledConnection();
            string mQuery = "select " + col + " from " + tbl + " where reg_id =" + regid + " and " + condition;
            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
            {
                cmd.Parameters.Add(new NpgsqlParameter(col, parameter));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                ds.Tables.Add(dt);
                cmd.Dispose();
            }
            _conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string AutonumberUpdate(string parameter, int regid)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            _conn = GetPooledConnection();
            string mQuery = "select concat(proc_year,doc_prefix) as docpref, doc_serial from tbl_re_doc_serial where reg_id = " + regid + " and doc_type = @doc_type";
            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
            {
                cmd.Parameters.Add(new NpgsqlParameter("@doc_type", parameter));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                ds.Tables.Add(dt);
                cmd.Dispose();
            }
            _conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string finaldocserial = "";
                string finaldocserial1 = "";

                int docserialincre = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                docserialincre = docserialincre + 1;
                string docserial = ds.Tables[0].Rows[0][1].ToString();
                if (docserial.Length == 1)
                {
                    finaldocserial = "000" + docserial;
                }
                else if (docserial.Length == 2)
                {
                    finaldocserial = "00" + docserial;
                }
                else if (docserial.Length == 3)
                {
                    finaldocserial = "0" + docserial;
                }
                else
                {
                    finaldocserial = docserial;
                }
                finaldocserial1 = ds.Tables[0].Rows[0][0].ToString() + finaldocserial;
                _conn = GetPooledConnection();
                mQuery = "UPDATE public.tbl_re_doc_serial SET doc_serial =@doc_serial WHERE doc_type = @doc_type and reg_id = " + regid;
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, _conn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@doc_serial", docserialincre));
                    cmd.Parameters.Add(new NpgsqlParameter("@doc_type", parameter));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                _conn.Close();


                return finaldocserial1;
            }
            else
            {
                return "0";
            }
        }

        public string GetAutonumber(string parameter, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            string mQuery = "select concat(proc_year,doc_prefix) as docpref, doc_serial from tbl_mark_doc_serial where doc_type = @doc_type";
            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
            {
                cmd.Parameters.Add(new NpgsqlParameter("@doc_type", parameter));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
                ds.Tables.Add(dt);
                cmd.Dispose();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                string finaldocserial = "";
                string finaldocserial1 = "";

                int docserialincre = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                docserialincre = docserialincre + 1;
                string docserial = ds.Tables[0].Rows[0][1].ToString();
                if (docserial.Length == 1)
                {
                    finaldocserial = "000" + docserial;
                }
                else if (docserial.Length == 2)
                {
                    finaldocserial = "00" + docserial;
                }
                else if (docserial.Length == 3)
                {
                    finaldocserial = "0" + docserial;
                }
                else
                {
                    finaldocserial = docserial;
                }
                finaldocserial1 = ds.Tables[0].Rows[0][0].ToString() + finaldocserial;

                return finaldocserial1;
            }
            else
            {
                return "0";
            }
        }

        public bool UpdateAutonumber(string parameter, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {

                string mQuery = "";
                mQuery = "UPDATE public.tbl_mark_doc_serial SET doc_serial = doc_serial + 1  WHERE doc_type = @doc_type";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@doc_type", parameter));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public string GetTableValue(NpgsqlConnection conn, string tableName, string fieldName, string condition = "")
        {
            string value = "";
            NpgsqlDataReader npgsqlDataReader = null;
            NpgsqlCommand npgsqlCommand = null;
            try
            {
                npgsqlCommand = conn.CreateCommand();
                if (condition.Equals(""))
                {
                    npgsqlCommand.CommandText = "SELECT " + fieldName + " From " + tableName + "";
                }
                else
                {
                    npgsqlCommand.CommandText = "SELECT " + fieldName + " From " + tableName + " Where " + condition + "";
                }

                npgsqlDataReader = npgsqlCommand.ExecuteReader();
                if (npgsqlDataReader.HasRows)
                {
                    if (npgsqlDataReader.Read())
                    {
                        value = npgsqlDataReader[0].ToString();
                    }
                }

                return value;
            }
            catch (Exception exception)
            {
                Log.LogError(exception.ToString());
                throw exception;
            }
            finally
            {
                if (npgsqlCommand != null)
                {
                    npgsqlCommand.Dispose();
                }
                if (npgsqlDataReader != null)
                {
                    npgsqlDataReader.Close();
                }
            }
        }

        public bool UpdateVoucherAutonumber(string parameter, int regid, NpgsqlConnection con, NpgsqlTransaction tr)
        {
            try
            {
                string mQuery = "";
                mQuery = "UPDATE public.tbl_re_doc_serial SET doc_serial = doc_serial + 1  WHERE upper(doc_prefix) = @serialtype and reg_id = " + regid;
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, con, tr))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@serialtype", parameter.ToUpper()));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }


    }
}
