    using System;
    using System.Collections.Generic;
    using System.Text;
    using THOUGHTBOX.DOMAIN.Domain;
    using THOUGHTBOX.HR.SERVICES.Interfaces;
    using THOUGHTBOX.REPOSITORIES.Interfaces;

    namespace THOUGHTBOX.HR.SERVICES.Classes
    {
        public class DepartmentGraphService: IDepartmentGraphService
        {
            private IDepartmentGraphRepository _departmentGraphRepository;
            Log Log = new Log();
            public DepartmentGraphService(IDepartmentGraphRepository departmentGraphRepository)
            {
                this._departmentGraphRepository=departmentGraphRepository;
            }

            public IList<DepartmentGraph> GetDepartmentGraphs(string company, string reqType)
            {
                try
                {
                    return this._departmentGraphRepository.GetDepartmentGraphs(company,reqType);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //
                }
            }

            public IList<DepartmentGraph> GetDepartmentSubGraphByEmp(string empId,string status, string reqType)
            {
                try
                {
                    return this._departmentGraphRepository.GetDepartmentSubGraphByEmp(empId,status,reqType);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //
                }
            }

            public IList<DepartmentGraph> GetDepartmentSubGraphStatus(string reqId, string Dtype)
            {
                try
                {
                    return this._departmentGraphRepository.GetDepartmentSubGraphStatus(reqId,Dtype);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //
                }
            }
            public IList<DepartmentGraph> GetDHDepartmentGraphs(int empId,string Dtype, string reqType)
            {
                try
                {
                    return this._departmentGraphRepository.GetDHDepartmentGraphs(empId,Dtype,reqType);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //
                }
            }
        }
    }
