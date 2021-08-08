using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class DepartmentGraphRepository: IDepartmentGraphRepository
    {
        ConnectionRepository connectionRepository = new ConnectionRepository();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        Log Log = new Log();
        NpgsqlConnection connection = null;

        public IList<DepartmentGraph> GetDepartmentGraphs(string company,string reqType)
        {
            List<DepartmentGraph> DepartmentGraphs = new List<DepartmentGraph>();
            try
            {
                string mQuery = "",empid="", reqId="";
                connection = connectionRepository.GetPooledConnection();
                mQuery = @"SELECT employee_id FROM public.tbl_mark_emppersonnel where company_id="+company;
                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        empid += "," + dr["employee_id"].ToString();
                    }
                    empid = empid.Substring(1);
                    connection = connectionRepository.GetPooledConnection();
                    mQuery = @"SELECT request_id FROM public.tbl_mark_requests_employee where employee_id in ("+empid+")"; ;
                    ds1 = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    connection.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds1.Tables[0].Rows)
                        {
                            reqId += "," + dr["request_id"].ToString();

                        }
                    }
                    else
                    {
                        DepartmentGraphs = null;
                    }
                }
                else
                {
                    DepartmentGraphs = null;
                }

                if (DepartmentGraphs != null)
                {
                    reqId = reqId.Substring(1);
                    connection = connectionRepository.GetPooledConnection();
                    mQuery = @"SELECT request_id,request_title, request_eddate, request_status FROM public.tbl_mark_requests where request_type='" + reqType + "' and request_id in(" + reqId+")";
                    ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    connection.Close();
                    string reqIdComp = "", reqIdNotComp = "", reqIdPending = "";
                    int countComp = 0;
                    int countNotComp = 0;
                    int countPending = 0;
                    DateTime currDate = DateTime.Now.Date;
                    // connection = connectionRepository.GetPooledConnection();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["request_eddate"].ToString() != null)
                            {
                                DateTime endDate = DateTime.Parse(dr["request_eddate"].ToString());
                                string status = dr["request_status"].ToString();
                                if (endDate >= currDate && status == "Finished")
                                {
                                    countComp++;
                                    reqIdComp += "^" + dr["request_id"].ToString();
                                }
                                if (endDate < currDate && status == "Pending")
                                {
                                    countNotComp++;
                                    reqIdNotComp += "^" + dr["request_id"].ToString();
                                }
                                if (endDate >= currDate && status == "Pending")
                                {
                                    countPending++;
                                    reqIdPending += "^" + dr["request_id"].ToString();
                                }
                            }
                        }

                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countComp,
                            reqId = reqIdComp,
                            // no_task = 5,
                            status = "Completed",
                        }
                        );
                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countNotComp,
                            reqId = reqIdNotComp,
                            //  no_task = 3,
                            status = "Not Completed",
                        }
                        );
                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countPending,
                            reqId = reqIdPending,
                            //no_task = 2,
                            status = "Pending",
                        }
                        );
                    }
                    else
                    {
                        DepartmentGraphs = null;
                    }
                }                
              
                return DepartmentGraphs;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }

        public IList<DepartmentGraph> GetDepartmentSubGraphByEmp(string empId,string status, string reqType)
        {
            List<DepartmentGraph> DepartmentGraphs = new List<DepartmentGraph>();
            try
            {
                connection = connectionRepository.GetPooledConnection();
                string mQuery = "",reqId="";
                mQuery = @"SELECT request_id FROM public.tbl_mark_requests_employee where employee_id=" + empId ;
                ds1 = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                connection.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        reqId += "," + dr["request_id"].ToString();
                       
                    }
                }
                else
                {
                    DepartmentGraphs = null;
                }
                var count = ds1.Tables[0].Rows.Count;
                if (count > 0)
                {
                    reqId = reqId.Substring(1);
                    connection = connectionRepository.GetPooledConnection();
                    string currDate = DateTime.Now.ToString("yyyy-MM-dd");
                    if (status == "Completed")
                    {
                        mQuery = @"SELECT request_id,request_title,count(request_id) as no_tasks FROM public.tbl_mark_requests where request_type='" + reqType + "' and  request_id in (" + reqId + ") and to_date(request_eddate, 'yyyy-mm-dd')>=to_date('" + currDate + "', 'yyyy-mm-dd') and request_status='Finished' group by request_id,request_title";
                        ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    }
                    if (status == "Not Completed")
                    {
                        mQuery = @"SELECT request_id,request_title,count(request_id) as no_tasks FROM public.tbl_mark_requests where request_type='" + reqType + "' and  request_id in (" + reqId + ") and to_date(request_eddate, 'yyyy-mm-dd')<to_date('" + currDate + "', 'yyyy-mm-dd') and request_status='Pending' group by request_id,request_title";
                        ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    }
                    if (status == "Pending")
                    {
                        mQuery = @"SELECT request_id,request_title,count(request_id) as no_tasks FROM public.tbl_mark_requests where request_type='" + reqType + "' and  request_id in (" + reqId + ") and to_date(request_eddate, 'yyyy-mm-dd')>=to_date('" + currDate + "', 'yyyy-mm-dd') and request_status='Pending' group by request_id,request_title";
                        ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {

                            DepartmentGraphs.Add(new DepartmentGraph
                            {
                                no_task = Convert.ToInt32(dr["no_tasks"].ToString()),
                                dept = dr["request_title"].ToString() ,
                            }
                            );
                        }
                    }
                    else
                    {
                        DepartmentGraphs = null;
                    }

                }
                connection.Close();
                return DepartmentGraphs;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }

        public IList<DepartmentGraph> GetDepartmentSubGraphStatus(string reqId,string Dtype)
        {
            List<DepartmentGraph> DepartmentGraphs = new List<DepartmentGraph>();
            try
            {               
                if (reqId != null)
                {
                    connection = connectionRepository.GetPooledConnection();
                    string[] reqId1 = reqId.Split("^");
                    int chk_id = 0;
                    List<int> termsList = new List<int>();
                    termsList.Add(chk_id);
                    string empid="",empname="",dheadId="";
                    string mQuery = "";
                    for (int i = 1; i < reqId1.Length; i++)
                    {
                        mQuery = @"SELECT employee_id FROM public.tbl_mark_requests_employee where request_id=" + reqId1[i] + " order by employee_id";
                        ds1 = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                       
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                           
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                connection = connectionRepository.GetPooledConnection();
                                empid += "," + dr1["employee_id"].ToString();                                
                                chk_id = Convert.ToInt32(dr1["employee_id"].ToString());                              
                                
                                    if (termsList.Contains(chk_id))
                                    {
                                    }
                                    else
                                    {
                                        empname += "," + connectionRepository.GetTableValue(connection, "public.tbl_mark_emppersonnel", "emp_firstname||' '||emp_lastname as name", "employee_id = '" + dr1["employee_id"].ToString() + "'") + "^" + Convert.ToInt32(dr1["employee_id"].ToString());
                                    }
                                termsList.Add(chk_id);
                            }                           
                        }
                        else
                        {
                            DepartmentGraphs = null;
                        }
                        ds1.Dispose();
                        connection.Close();
                    }
                    empid = empid.Substring(1);

                    connection = connectionRepository.GetPooledConnection();
                    mQuery = @"SELECT emp_reportedto,count(emp_reportedto) as no_tasks FROM public.tbl_mark_emppersonnel where employee_id in (" + empid + ") group by emp_reportedto";
                    ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                   
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dheadId += "," + dr["emp_reportedto"].ToString();
                        if (Dtype != "MD")
                        {
                            DepartmentGraphs.Add(new DepartmentGraph
                            {
                                emp_name = empname.Substring(1),
                                emp_id = dr["emp_reportedto"].ToString(),
                                no_task = Convert.ToInt32(dr["no_tasks"].ToString()),
                                dept = Convert.ToInt32(dr["emp_reportedto"].ToString()) == 0 ? "" : connectionRepository.GetTableValue(connection, "public.tbl_mark_emppersonnel", "emp_firstname||' '||emp_lastname as name", "employee_id = '" + dr["emp_reportedto"].ToString() + "'"),
                            }                                                   
                            );
                        }
                       
                    }
                    connection.Close();
                    if (Dtype == "MD")
                    {
                        dheadId = dheadId.Substring(1);
                        connection = connectionRepository.GetPooledConnection();
                        mQuery = @"SELECT emp_reportedto,count(emp_reportedto) as no_tasks FROM public.tbl_mark_emppersonnel where employee_id in (" + dheadId + ") group by emp_reportedto";
                        ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                        
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                           // dheadId += "," + dr["emp_reportedto"].ToString();
                            DepartmentGraphs.Add(new DepartmentGraph
                            {
                                emp_name = empname.Substring(1),
                                emp_id = dr["emp_reportedto"].ToString(),
                                no_task = Convert.ToInt32(dr["no_tasks"].ToString()),
                                dept = Convert.ToInt32(dr["emp_reportedto"].ToString()) == 0 ? "" : connectionRepository.GetTableValue(connection, "public.tbl_mark_emppersonnel", "emp_firstname||' '||emp_lastname as name", "employee_id = '" + dr["emp_reportedto"].ToString() + "'"),
                            }
                            );
                        }
                        connection.Close();
                    }
                } 

                return DepartmentGraphs;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }

        public IList<DepartmentGraph> GetDHDepartmentGraphs(int empId,string Dtype, string reqType)
        {
            List<DepartmentGraph> DepartmentGraphs = new List<DepartmentGraph>();
            try
            {
                
                string mQuery = "", reqId = "", depId = "";
                if (Dtype == "BDM")
                {
                    connection = connectionRepository.GetPooledConnection();
                    mQuery = @"select employee_id from public.tbl_mark_emppersonnel where emp_reportedto=" + empId;
                    ds1 = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    connection.Close();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds1.Tables[0].Rows)
                        {
                            depId += "," + dr["employee_id"].ToString();

                        }
                        depId = depId.Substring(1);
                        connection = connectionRepository.GetPooledConnection();
                        mQuery = @"SELECT request_id FROM public.tbl_mark_requests_employee where employee_id in(select employee_id from public.tbl_mark_emppersonnel where emp_reportedto in (" + depId + "))";

                    }
                    else
                    {
                        DepartmentGraphs = null;
                    }
                  
                }
                if (Dtype == "DH")
                {
                    mQuery = @"SELECT request_id FROM public.tbl_mark_requests_employee where employee_id in(select employee_id from public.tbl_mark_emppersonnel where emp_reportedto=" + empId + ")";

                }
                if (Dtype == "ME")
                {
                    mQuery = @"SELECT request_id FROM public.tbl_mark_requests_employee where employee_id = " + empId ;

                }
                connection = connectionRepository.GetPooledConnection();
                ds1 = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                connection.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        reqId += "," + dr["request_id"].ToString();

                    }
                }
                else
                {
                    DepartmentGraphs = null;
                }
                var count = ds1.Tables[0].Rows.Count;
                if (count > 0)
                {
                    reqId = reqId.Substring(1);
                    connection = connectionRepository.GetPooledConnection();
                    mQuery = @"SELECT request_id,request_title, request_eddate, request_status FROM public.tbl_mark_requests where request_type='" + reqType + "' and request_id in(" + reqId+")";
                    ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    connection.Close();
                    string reqIdComp = "", reqIdNotComp = "", reqIdPending = "";
                    int countComp = 0;
                    int countNotComp = 0;
                    int countPending = 0;
                    DateTime currDate = DateTime.Now.Date;
                    // connection = connectionRepository.GetPooledConnection();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["request_eddate"].ToString() != null)
                            {
                                DateTime endDate = DateTime.Parse(dr["request_eddate"].ToString());
                                string status = dr["request_status"].ToString();
                                if (endDate >= currDate && status == "Finished")
                                {
                                    countComp++;
                                    reqIdComp += "^" + dr["request_id"].ToString();
                                }
                                if (endDate < currDate && status == "Pending")
                                {
                                    countNotComp++;
                                    reqIdNotComp += "^" + dr["request_id"].ToString();
                                }
                                if (endDate >= currDate && status == "Pending")
                                {
                                    countPending++;
                                    reqIdPending += "^" + dr["request_id"].ToString();
                                }
                            }
                        }

                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countComp,
                            reqId = reqIdComp,
                            // no_task = 5,
                            status = "Completed",
                        }
                        );
                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countNotComp,
                            reqId = reqIdNotComp,
                            //  no_task = 3,
                            status = "Not Completed",
                        }
                        );
                        DepartmentGraphs.Add(new DepartmentGraph
                        {
                            no_task = countPending,
                            reqId = reqIdPending,
                            //no_task = 2,
                            status = "Pending",
                        }
                        );
                    }
                    else
                    {
                        DepartmentGraphs = null;
                    }

                }


                return DepartmentGraphs;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
        }
    }
}


