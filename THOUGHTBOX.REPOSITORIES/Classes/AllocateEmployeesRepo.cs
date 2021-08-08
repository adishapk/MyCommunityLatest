using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class AllocateEmployeesRepo : IAllocateEmployeesRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

      
        public int allocateempinsert(AllocateEmployeesDomain allocateempin, CreateRequest createrequestdetails)
        {
            try
            {
                string mQuery = "";
                connection = Master_con.GetPooledConnection();
                DocrequestsTrans doctrans = new DocrequestsTrans();
                ApprovalTransGeneral apptransgeneral = new ApprovalTransGeneral();

                mQuery = "update tbl_mark_requests set request_status = @request_status where request_id = @request_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", allocateempin.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@request_status", createrequestdetails.request_status));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                string[] all_ids = allocateempin.allemployeeids.Split(',');
                for (int j = 0; j < all_ids.Length; j++)
                {
                    if (all_ids[j] != "")
                    {
                mQuery = "insert into tbl_mark_requests_employee(request_id,employee_id,allocated_date,allocated_time,allocated_comments,allocated_image) values (@request_id,@employee_id,@allocated_date,@allocated_time,@allocated_comments,@allocated_image)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@request_id", allocateempin.request_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@employee_id", Convert.ToInt32(all_ids[j])));
                    cmd.Parameters.Add(new NpgsqlParameter("@allocated_date", allocateempin.allocated_date));
                    cmd.Parameters.Add(new NpgsqlParameter("@allocated_time", allocateempin.allocated_time));
                    cmd.Parameters.Add(new NpgsqlParameter("@allocated_comments", allocateempin.allocated_comments));
                    cmd.Parameters.Add(new NpgsqlParameter("@allocated_image", allocateempin.allocated_image));
                    
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }


                       
                        apptransgeneral.request_id = allocateempin.request_id;
                        apptransgeneral.requ_date = allocateempin.allocated_date;
                        apptransgeneral.requ_time = allocateempin.allocated_time;
                        apptransgeneral.requ_appby = createrequestdetails.appliedby_id;
                        apptransgeneral.requ_type_id = "Department Request";
                        apptransgeneral.requ_status = "Approved";
                        apptransgeneral.requ_comments = "";
                        apptransgeneral.requ_approvedby = Convert.ToInt32(all_ids[j]);
                        apptransgeneral.requ_docstatus = "Finished";
                        apptransgeneral.requ_details = "Employee Request of No " + createrequestdetails.request_code + " of Request Title " + createrequestdetails.request_title + " is allocated by Department Manager";
                        apptransgeneral.requ_addl1 = "0";
                        apptransgeneral.requ_addl2 = "0";
                        apptransgeneral.requ_addl3 = createrequestdetails.request_title;
                        apptransgeneral.requ_addl4 = "0";
                        apptransgeneral.requ_addl5 = allocateempin.allocated_comments;

                        if (j == 0)
                        {
                            doctrans.UpdateApprovalTrans1(apptransgeneral, connection, transaction);
                        }
                        else
                        { 
                        doctrans.UpdateApprovalTrans(apptransgeneral, connection, transaction);
                        }

                        DocrequestsTrans doctransalert = new DocrequestsTrans();
                        Generaldomain generalalert = new Generaldomain();

                        //To fill alert procedure
                        generalalert.Generalval1 = allocateempin.request_id;
                        generalalert.Generalval2 = "Department Request";
                        generalalert.Gneralaval3 = "Employee Request of No " + createrequestdetails.request_code + " of Request Title " + createrequestdetails.request_title + " is allocated by Department Manager";
                        generalalert.Generalval11 = Convert.ToInt32(all_ids[j]);
                        generalalert.Gneralaval4 = allocateempin.allocated_date;
                        generalalert.Gneralaval5 = allocateempin.allocated_time;
                        generalalert.Gneralaval6 = "Finished";
                        generalalert.Gneralaval7 = "Y";
                        generalalert.Gneralaval8 = allocateempin.allocated_time;
                        generalalert.Gneralaval9 = "/WebImages/SystemImages/requestimage.jpg";

                        //connection = connectionrepository.GetPooledConnection();
                        doctransalert.InsertDashboardalerts(generalalert, connection, transaction);


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

        public IList<AllocateEmployeesDomain> SelectAllocateddetailsforempid(int requestval, int empid)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select allocated_comments,allocated_image,allocated_date,allocated_time from tbl_mark_requests_employee where request_id = " + requestval + " and employee_id = " + empid + "";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<AllocateEmployeesDomain> emperson_list = new List<AllocateEmployeesDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new AllocateEmployeesDomain
                    {
                        allocated_comments = redrow["allocated_comments"].ToString(),
                        allocated_image = redrow["allocated_image"].ToString(),
                        allocated_date = redrow["allocated_date"].ToString(),
                        allocated_time = redrow["allocated_time"].ToString(),

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
