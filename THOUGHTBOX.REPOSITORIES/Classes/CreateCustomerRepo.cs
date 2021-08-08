using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateCustomerRepo : ICreateCustomerRepo
    {
        ConnectionRepository Master_con = new ConnectionRepository();
        DataSet Master_ds = new DataSet();
        NpgsqlConnection connection = null;
        NpgsqlTransaction transaction = null;

        public int custinsert(CreateCustomerDomain customerinsrt)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "insert into tbl_mark_customerdetails(cust_name,cust_address,cust_city,cust_state,cust_phoneno,cust_emailaddress,cust_contactperson,cust_cpdesignation,cust_status,cust_paidstatus,cust_type,cust_paidamount,cust_employeeid) values (@cust_name,@cust_address,@cust_city,@cust_state,@cust_phoneno,@cust_emailaddress,@cust_contactperson,@cust_cpdesignation,@cust_status,@cust_paidstatus,@cust_type,@cust_paidamount,@cust_employeeid)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_name", customerinsrt.cust_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_address", customerinsrt.cust_address.ToString() == null ? "" : customerinsrt.cust_address.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_city", customerinsrt.cust_city.ToString() == null ? "" : customerinsrt.cust_city.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_state", customerinsrt.cust_state.ToString() == null ? "" : customerinsrt.cust_state.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_phoneno", customerinsrt.cust_phoneno.ToString() == null ? "" : customerinsrt.cust_phoneno.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_emailaddress", customerinsrt.cust_emailaddress.ToString() == null ? "" : customerinsrt.cust_emailaddress.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_contactperson", customerinsrt.cust_contactperson.ToString() == "" ? "0" : customerinsrt.cust_contactperson.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_cpdesignation", Convert.ToInt32(customerinsrt.cust_cpdesignation.ToString() == "" ? "0" : customerinsrt.cust_cpdesignation.ToString())));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_status", customerinsrt.cust_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_paidstatus", customerinsrt.cust_paidstatus));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_type", customerinsrt.cust_type));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_paidamount", customerinsrt.cust_paidamount.ToString() == null ? "" : customerinsrt.cust_paidamount.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_employeeid", customerinsrt.cust_employeeid));

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

        public int customerdelete(int customerdelet)
        {
            try
            {
                string DDD = "delete from tbl_mark_customerdetails where customer_id =" + customerdelet;
                Master_con.PG_ManipulationMaster(DDD);
                return 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int custupdate(CreateCustomerDomain customerupdt)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string mQuery = "update tbl_mark_customerdetails set cust_name = @cust_name,cust_address = @cust_address,cust_city=@cust_city,cust_state=@cust_state,cust_phoneno=@cust_phoneno,cust_emailaddress=@cust_emailaddress,cust_contactperson=@cust_contactperson,cust_cpdesignation=@cust_cpdesignation,cust_status=@cust_status,cust_paidstatus=@cust_paidstatus,cust_type=@cust_type,cust_paidamount=@cust_paidamount, cust_employeeid = @cust_employeeid where customer_id = @customer_id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(mQuery, connection))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@customer_id", customerupdt.customer_id));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_name", customerupdt.cust_name));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_address", customerupdt.cust_address.ToString() == null ? "" : customerupdt.cust_address.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_city", customerupdt.cust_city.ToString() == null ? "" : customerupdt.cust_city.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_state", customerupdt.cust_state.ToString() == null ? "" : customerupdt.cust_state.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_phoneno", customerupdt.cust_phoneno.ToString() == null ? "" : customerupdt.cust_phoneno.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_emailaddress", customerupdt.cust_emailaddress.ToString() == null ? "" : customerupdt.cust_emailaddress.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_contactperson", customerupdt.cust_contactperson.ToString() == "" ? "0" : customerupdt.cust_contactperson.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_cpdesignation", Convert.ToInt32(customerupdt.cust_cpdesignation.ToString() == "" ? "0" : customerupdt.cust_cpdesignation.ToString())));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_status", customerupdt.cust_status));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_paidstatus", customerupdt.cust_paidstatus));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_type", customerupdt.cust_type));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_paidamount", customerupdt.cust_paidamount.ToString() == null ? "" : customerupdt.cust_paidamount.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@cust_employeeid", customerupdt.cust_employeeid));

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

        public IList<CreateCustomerDomain> getallassociate(string custtype)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select customer_id,cust_name from tbl_mark_customerdetails where cust_type ='" + custtype + "' order by cust_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);
                IList<CreateCustomerDomain> emperson_list = new List<CreateCustomerDomain>();
                foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateCustomerDomain
                    {
                        customer_id = Convert.ToInt32(redrow["customer_id"].ToString()),
                        cust_name = redrow["cust_name"].ToString(),
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

        public IList<CreateCustomerDomain> getallcustomer(int getallcust)
        {
            try
            {
                connection = Master_con.GetPooledConnection();
                string TRR = "select customer_id,cust_name,cust_address,cust_city,cust_state,cust_phoneno,cust_emailaddress,cust_contactperson,cust_cpdesignation,cust_status,cust_paidstatus,cust_type,cust_paidamount,cust_employeeid from tbl_mark_customerdetails order by cust_name";
                Master_ds = Master_con.PG_SelectMasterDS(TRR, connection, null);

                IList<CreateCustomerDomain> emperson_list = new List<CreateCustomerDomain>();
                if (Master_ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow redrow in Master_ds.Tables[0].Rows)
                {
                    emperson_list.Add(new CreateCustomerDomain
                    {
                        customer_id = Convert.ToInt32(redrow["customer_id"].ToString()),
                        cust_name = redrow["cust_name"].ToString(),
                        cust_address = redrow["cust_address"].ToString(),
                        cust_city = redrow["cust_city"].ToString(),
                        cust_state = redrow["cust_state"].ToString(),
                        cust_phoneno = redrow["cust_phoneno"].ToString(),
                        cust_emailaddress = redrow["cust_emailaddress"].ToString(),
                        cust_contactperson = redrow["cust_contactperson"].ToString(),
                        cust_cpdesignation = Convert.ToInt32(redrow["cust_cpdesignation"].ToString()),
                        cust_status = redrow["cust_status"].ToString(),
                        cust_paidstatus = redrow["cust_paidstatus"].ToString(),
                        cust_type = redrow["cust_type"].ToString(),
                        cust_paidamount = redrow["cust_paidamount"].ToString(),
                        cust_employeeid = Convert.ToInt32(redrow["cust_employeeid"].ToString()),

                    }
                    );
                }
                }
                else
                {
                    emperson_list.Add(new CreateCustomerDomain
                    {
                        customer_id = -1,
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
