using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateDepartmentRepo
    {
        int departmentinsert(CreateDepartmentDomain departin);
        int departmentupdate(CreateDepartmentDomain departup);
        int departmentdelete(int departdelet);
        IList<CreateDepartmentDomain> getalldepartment(int getalldepart);
        IList<CreateDepartmentDomain> getalldepartmentdd(int getalldepartdd);
        string GetCompanyName(int companyid);
    }
}
