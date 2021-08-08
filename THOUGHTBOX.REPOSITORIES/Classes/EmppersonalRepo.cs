using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class EmppersonalRepo : IEmppersonalRepo
    {
        private ConnectionRepository person_con = new ConnectionRepository();
        DataSet person_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public IList<EmppersonalDomain> GetEmployeeforempview(int generalid)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select employee_id,emp_firstname,emp_lastname,emp_code,emp_cardno,emp_mobileno,emp_status,emp_dob,emp_nationality,emp_designation,emp_dojoin,emp_qid,emp_qidexpiry,emp_healthcardid,emp_hcardexpiry,emp_ppno,emp_ppexpiry,emp_photo,emp_reportedto,emp_totalsalary,emp_grosssalary,emp_totaldeductions from tbl_mark_emppersonnel order by emp_firstname";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<EmppersonalDomain> emperson_list = new List<EmppersonalDomain>();
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in person_ds.Tables[0].Rows)
                    {
                        emperson_list.Add(new EmppersonalDomain
                        {
                            employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                            emp_firstname = redrow["emp_firstname"].ToString(),
                            emp_lastname = redrow["emp_lastname"].ToString(),
                            emp_code = redrow["emp_code"].ToString(),
                            emp_cardno = redrow["emp_cardno"].ToString(),
                            emp_mobileno = redrow["emp_mobileno"].ToString(),
                            emp_status = redrow["emp_status"].ToString(),
                            emp_dob = redrow["emp_dob"].ToString(),
                            emp_nationality = Convert.ToInt32(redrow["emp_nationality"].ToString()),
                            emp_designation = Convert.ToInt32(redrow["emp_designation"].ToString()),
                            emp_dojoin = redrow["emp_dojoin"].ToString(),
                            emp_qid = redrow["emp_qid"].ToString(),
                            emp_qidexpiry = redrow["emp_qidexpiry"].ToString(),
                            emp_healthcardid = redrow["emp_healthcardid"].ToString(),
                            emp_hcardexpiry = redrow["emp_hcardexpiry"].ToString(),
                            emp_ppno = redrow["emp_ppno"].ToString(),
                            emp_ppexpiry = redrow["emp_ppexpiry"].ToString(),
                            emp_photo = redrow["emp_photo"].ToString(),
                            emp_reportedto = Convert.ToInt32(redrow["emp_reportedto"].ToString()),
                            totalsalary = redrow["emp_totalsalary"].ToString(),
                            emp_grosssalary = redrow["emp_grosssalary"].ToString(),
                            emp_totaldeductions = redrow["emp_totaldeductions"].ToString(),

                        }
                        );
                    }
                }
                else
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = -1,
                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmppersonalDomain> getEmployeereportedto(int sgetperson)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select employee_id,concat(emp_firstname,' ',emp_lastname) as Firstname from tbl_mark_emppersonnel where emp_reportedto = " + sgetperson + " and emp_status = 'Active' order by emp_firstname";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<EmppersonalDomain> emperson_list = new List<EmppersonalDomain>();
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in person_ds.Tables[0].Rows)
                    {
                        emperson_list.Add(new EmppersonalDomain
                        {
                            employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                            emp_firstname = redrow["Firstname"].ToString(),

                        }
                        );
                    }
                }
                else
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = -1,
                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetReportedtoEmployee(int employeeid)
        {
            try
            {
                string empname = "";
                connection = person_con.GetPooledConnection();
                string TRR = "select concat(emp_firstname, ' ', emp_lastname) as name from tbl_mark_emppersonnel where employee_id =" + employeeid + "";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
             
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    empname = person_ds.Tables[0].Rows[0][0].ToString();
                }
             
                person_ds.Dispose();
                connection.Dispose();
                return empname;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmpsalaryDomain> Getsalarystructure(int employid, string Transtype)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string mQuery = "SELECT salstruct_id,sal_amount FROM public.tbl_mark_employ_salary where employee_id = " + employid + " and salstruct_type = '" + Transtype + "' order by salstruct_id";
                person_ds = person_con.PG_SelectMasterDS(mQuery, connection, null);

                IList<EmpsalaryDomain> _employeesalary = new List<EmpsalaryDomain>();
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in person_ds.Tables[0].Rows)
                    {
                        _employeesalary.Add(new EmpsalaryDomain
                        {
                             emp_salaryheadid = Convert.ToInt32(dr["salstruct_id"].ToString()),
                            emp_salaryamount = dr["sal_amount"].ToString(),
                        }
                        );
                    }
                }
                else
                {
                    _employeesalary.Add(new EmpsalaryDomain
                    {
                        emp_salaryheadid = -1,
                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return _employeesalary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int remppersonaldelete(int remppersdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_emppersonnel where employee_id =" + remppersdelet;
                person_con.PG_ManipulationMaster(DDD);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int remppersonalinsert(EmppersonalDomain remppersinsrt, EmpsalaryDomain salstruct)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string mQuery = "insert into tbl_mark_emppersonnel(emp_firstname,emp_lastname,emp_code,emp_cardno,emp_mobileno,emp_status,emp_dob,emp_nationality,emp_designation,emp_dojoin,emp_qid,emp_qidexpiry,emp_healthcardid,emp_hcardexpiry,emp_ppno,emp_ppexpiry,emp_photo,emp_totalsalary,emp_grosssalary,emp_totaldeductions,emp_reportedto) values (@emp_firstname,@emp_lastname,@emp_code,@emp_cardno,@emp_mobileno,@emp_status,@emp_dob,@emp_nationality,@emp_designation,@emp_dojoin,@emp_qid,@emp_qidexpiry,@emp_healthcardid,@emp_hcardexpiry,@emp_ppno,@emp_ppexpiry,@emp_photo,@emp_totalsalary,@emp_grosssalary,@emp_totaldeductions,@emp_reportedto)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_firstname", remppersinsrt.emp_firstname));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_lastname", remppersinsrt.emp_lastname));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_code", remppersinsrt.emp_code));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_cardno", remppersinsrt.emp_cardno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_mobileno", remppersinsrt.emp_mobileno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_status", remppersinsrt.emp_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_dob", remppersinsrt.emp_dob));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_nationality", remppersinsrt.emp_nationality));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_designation", remppersinsrt.emp_designation));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_dojoin", remppersinsrt.emp_dojoin));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_qid", remppersinsrt.emp_qid));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_qidexpiry", remppersinsrt.emp_qidexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_healthcardid", remppersinsrt.emp_healthcardid));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_hcardexpiry", remppersinsrt.emp_hcardexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_ppno", remppersinsrt.emp_ppno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_ppexpiry", remppersinsrt.emp_ppexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_photo", remppersinsrt.emp_photo));

                    cmd.Parameters.Add(new NpgsqlParameter("@emp_reportedto", remppersinsrt.emp_reportedto));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_totalsalary", remppersinsrt.totalsalary));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_grosssalary", remppersinsrt.emp_grosssalary));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_totaldeductions", remppersinsrt.emp_totaldeductions));


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                mQuery = "SELECT  currval('tbl_mark_emppersonnel_employee_id_seq') as employeeid";
                person_ds = person_con.PG_SelectMasterDS(mQuery, connection, null);

                int empid = Convert.ToInt32(person_ds.Tables[0].Rows[0][0].ToString());

                int addcount = Convert.ToInt32(salstruct.addcount);
                if (addcount > 0)
                {
                    string addheads = salstruct.salaryheadsad.ToString();
                    string[] addheadssplit = addheads.Split(char.Parse(","));

                    string addamount = salstruct.salaryamountad.ToString();
                    string[] addamountsplit = addamount.Split(char.Parse(","));

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < addcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary(employee_id,salstruct_id,salstruct_type,sal_amount) VALUES(@employee_id,@salstruct_id,@salstruct_type,@sal_amount)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", empid));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(addheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", "Addition"));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", addamountsplit[i]));

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < addcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary_history(employee_id,salstruct_id,sal_amount,sal_from_date,sal_to_date,entry_date) VALUES(@employee_id,@salstruct_id,@sal_amount,@sal_from_date,@sal_to_date,@entry_date)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", empid));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(addheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", addamountsplit[i]));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_from_date", salstruct.sal_from_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_to_date", salstruct.sal_to_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@entry_date", salstruct.sal_from_date));

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }

                int dedcount = Convert.ToInt32(salstruct.dedcount);
                if (dedcount > 0)
                {
                    string dedheads = salstruct.salaryheadsded.ToString();
                    string[] dedheadssplit = dedheads.Split(char.Parse(","));

                    string dedamount = salstruct.salaryamountded.ToString();
                    string[] dedamountsplit = dedamount.Split(char.Parse(","));

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < dedcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary(employee_id,salstruct_id,salstruct_type,sal_amount) VALUES(@employee_id,@salstruct_id,@salstruct_type,@sal_amount)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", empid));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(dedheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", "Deletion"));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", dedamountsplit[i]));

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < dedcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary_history(employee_id,salstruct_id,sal_amount,sal_from_date,sal_to_date,entry_date) VALUES(@employee_id,@salstruct_id,@sal_amount,@sal_from_date,@sal_to_date,@entry_date)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", empid));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(dedheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", dedamountsplit[i]));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_from_date", salstruct.sal_from_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_to_date", salstruct.sal_to_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@entry_date", salstruct.sal_from_date));


                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                }
                person_ds.Dispose();
                connection.Dispose();
                return 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int remppersonalupdate(EmppersonalDomain remppersupdate, EmpsalaryDomain salstruct)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string mQuery = "update tbl_mark_emppersonnel set emp_firstname = @emp_firstname,emp_lastname = @emp_lastname,emp_code=@emp_code,emp_cardno=@emp_cardno,emp_mobileno=@emp_mobileno,emp_status=@emp_status,emp_dob=@emp_dob,emp_nationality=@emp_nationality,emp_designation=@emp_designation,emp_dojoin=@emp_dojoin,emp_qid=@emp_qid,emp_qidexpiry=@emp_qidexpiry,emp_healthcardid=@emp_healthcardid,emp_hcardexpiry=@emp_hcardexpiry,emp_ppno=@emp_ppno,emp_ppexpiry=@emp_ppexpiry,emp_photo=@emp_photo,emp_reportedto=@emp_reportedto,emp_totalsalary=@emp_totalsalary,emp_grosssalary=@emp_grosssalary,emp_totaldeductions=@emp_totaldeductions where employee_id = @employee_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", remppersupdate.employee_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_firstname", remppersupdate.emp_firstname));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_lastname", remppersupdate.emp_lastname));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_code", remppersupdate.emp_code));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_cardno", remppersupdate.emp_cardno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_mobileno", remppersupdate.emp_mobileno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_status", remppersupdate.emp_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_dob", remppersupdate.emp_dob));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_nationality", remppersupdate.emp_nationality));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_designation", remppersupdate.emp_designation));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_dojoin", remppersupdate.emp_dojoin));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_qid", remppersupdate.emp_qid));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_qidexpiry", remppersupdate.emp_qidexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_healthcardid", remppersupdate.emp_healthcardid));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_hcardexpiry", remppersupdate.emp_hcardexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_ppno", remppersupdate.emp_ppno));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_ppexpiry", remppersupdate.emp_ppexpiry));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_photo", remppersupdate.emp_photo));

                    cmd.Parameters.Add(new NpgsqlParameter("@emp_reportedto", remppersupdate.emp_reportedto));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_totalsalary", remppersupdate.totalsalary));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_grosssalary", remppersupdate.emp_grosssalary));
                    cmd.Parameters.Add(new NpgsqlParameter("@emp_totaldeductions", remppersupdate.emp_totaldeductions));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                int addcount = Convert.ToInt32(salstruct.addcount);
                if (addcount > 0)
                {
                   // connection = person_con.GetPooledConnection();

                    mQuery = "Delete from public.tbl_mark_employ_salary where employee_id = " + remppersupdate.employee_id + " and salstruct_type = 'Addition'";
                    person_con.PG_ManipulationMaster(mQuery);

                    string addheads = salstruct.salaryheadsad.ToString();
                    string[] addheadssplit = addheads.Split(char.Parse(","));

                    string addamount = salstruct.salaryamountad.ToString();
                    string[] addamountsplit = addamount.Split(char.Parse(","));

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < addcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary(employee_id,salstruct_id,salstruct_type,sal_amount) VALUES(@employee_id,@salstruct_id,@salstruct_type,@sal_amount)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", remppersupdate.employee_id));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(addheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", "Addition"));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", addamountsplit[i]));

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }

                    }

                    //connection = person_con.GetPooledConnection();

                    for (int i = 0; i < addcount; i++)
                    {
                        mQuery = "INSERT INTO public.tbl_mark_employ_salary_history(employee_id,salstruct_id,sal_amount,sal_from_date,sal_to_date,entry_date) VALUES(@employee_id,@salstruct_id,@sal_amount,@sal_from_date,@sal_to_date,@entry_date)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@employee_id", remppersupdate.employee_id));
                            cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(addheadssplit[i])));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", addamountsplit[i]));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_from_date", salstruct.sal_from_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@sal_to_date", salstruct.sal_to_date));
                            cmd.Parameters.Add(new NpgsqlParameter("@entry_date", salstruct.sal_from_date));

                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }

                    int dedcount = Convert.ToInt32(salstruct.dedcount);
                    if (dedcount > 0)
                    {
                       // connection = person_con.GetPooledConnection();

                        mQuery = "Delete from public.tbl_mark_employ_salary where employee_id = " + remppersupdate.employee_id + " and salstruct_type = 'Deletion'";
                        person_con.PG_ManipulationMaster(mQuery);

                        string dedheads = salstruct.salaryheadsded.ToString();
                        string[] dedheadssplit = dedheads.Split(char.Parse(","));

                        string dedamount = salstruct.salaryamountded.ToString();
                        string[] dedamountsplit = dedamount.Split(char.Parse(","));

                        //connection = person_con.GetPooledConnection();

                        for (int i = 0; i < dedcount; i++)
                        {
                            mQuery = "INSERT INTO public.tbl_mark_employ_salary(employee_id,salstruct_id,salstruct_type,sal_amount) VALUES(@employee_id,@salstruct_id,@salstruct_type,@sal_amount)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                            {
                                cmd.Parameters.Add(new NpgsqlParameter("@employee_id", remppersupdate.employee_id));
                                cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(dedheadssplit[i])));
                                cmd.Parameters.Add(new NpgsqlParameter("@salstruct_type", "Deletion"));
                                cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", dedamountsplit[i]));

                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                        }

                        //connection = person_con.GetPooledConnection();

                        for (int i = 0; i < dedcount; i++)
                        {
                            mQuery = "INSERT INTO public.tbl_mark_employ_salary_history(employee_id,salstruct_id,sal_amount,sal_from_date,sal_to_date,entry_date) VALUES(@employee_id,@salstruct_id,@sal_amount,@sal_from_date,@sal_to_date,@entry_date)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                            {
                                cmd.Parameters.Add(new NpgsqlParameter("@employee_id", remppersupdate.employee_id));
                                cmd.Parameters.Add(new NpgsqlParameter("@salstruct_id", Convert.ToInt32(dedheadssplit[i])));
                                cmd.Parameters.Add(new NpgsqlParameter("@sal_amount", dedamountsplit[i]));
                                cmd.Parameters.Add(new NpgsqlParameter("@sal_from_date", salstruct.sal_from_date));
                                cmd.Parameters.Add(new NpgsqlParameter("@sal_to_date", salstruct.sal_to_date));
                                cmd.Parameters.Add(new NpgsqlParameter("@entry_date", salstruct.sal_from_date));


                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }
                        }

                    }
                }
                connection.Dispose();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmppersonalDomain> rgetallemppersonl(int rgetallperson)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select employee_id,emp_firstname,emp_lastname,emp_code,emp_cardno,emp_mobileno,emp_status,emp_dob,emp_nationality,emp_designation,emp_dojoin,emp_qid,emp_qidexpiry,emp_healthcardid,emp_hcardexpiry,emp_ppno,emp_ppexpiry,emp_photo,emp_reportedto,emp_totalsalary,emp_grosssalary,emp_totaldeductions from tbl_mark_emppersonnel order by emp_firstname";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<EmppersonalDomain> emperson_list = new List<EmppersonalDomain>();
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in person_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                        emp_firstname = redrow["emp_firstname"].ToString(),
                        emp_lastname = redrow["emp_lastname"].ToString(),
                        emp_code = redrow["emp_code"].ToString(),
                        emp_cardno = redrow["emp_cardno"].ToString(),
                        emp_mobileno = redrow["emp_mobileno"].ToString(),
                        emp_status = redrow["emp_status"].ToString(),
                        emp_dob = redrow["emp_dob"].ToString(),
                        emp_nationality = Convert.ToInt32(redrow["emp_nationality"].ToString()),
                        emp_designation = Convert.ToInt32(redrow["emp_designation"].ToString()),
                        emp_dojoin = redrow["emp_dojoin"].ToString(),
                        emp_qid = redrow["emp_qid"].ToString(),
                        emp_qidexpiry = redrow["emp_qidexpiry"].ToString(),
                        emp_healthcardid = redrow["emp_healthcardid"].ToString(),
                        emp_hcardexpiry = redrow["emp_hcardexpiry"].ToString(),
                        emp_ppno = redrow["emp_ppno"].ToString(),
                        emp_ppexpiry = redrow["emp_ppexpiry"].ToString(),
                        emp_photo = redrow["emp_photo"].ToString(),
                        emp_reportedto = Convert.ToInt32(redrow["emp_reportedto"].ToString()),
                        totalsalary = redrow["emp_totalsalary"].ToString(),
                        emp_grosssalary = redrow["emp_grosssalary"].ToString(),
                        emp_totaldeductions = redrow["emp_totaldeductions"].ToString(),

                    }
                    );
                }
                }
                else
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = -1,
                    }
                    );
                }
                person_ds.Dispose();
                connection.Dispose();
                return emperson_list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmppersonalDomain> rgetemployee(int rgetperson)
        {
            try
            {
                connection = person_con.GetPooledConnection();
                string TRR = "select employee_id,concat(emp_firstname,' ',emp_lastname) as Firstname from tbl_mark_emppersonnel where emp_status = 'Active' order by emp_firstname";
                person_ds = person_con.PG_SelectMasterDS(TRR, connection, null);
                IList<EmppersonalDomain> emperson_list = new List<EmppersonalDomain>();
                if (person_ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow redrow in person_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = Convert.ToInt32(redrow["employee_id"].ToString()),
                        emp_firstname = redrow["Firstname"].ToString(),

                    }
                    );
                }
                }
                else
                {
                    emperson_list.Add(new EmppersonalDomain
                    {
                        employee_id = -1,
                    }
                    );
                }
                person_ds.Dispose();
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
