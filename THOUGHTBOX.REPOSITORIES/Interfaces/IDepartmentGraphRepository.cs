using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IDepartmentGraphRepository
    {
        IList<DepartmentGraph> GetDepartmentGraphs(string company, string reqType);
        IList<DepartmentGraph> GetDepartmentSubGraphStatus(string reqId, string Dtype);
        IList<DepartmentGraph> GetDHDepartmentGraphs(int empId,string Dtype, string reqType);
        IList<DepartmentGraph> GetDepartmentSubGraphByEmp(string empId,string status, string reqType);
    }
}
