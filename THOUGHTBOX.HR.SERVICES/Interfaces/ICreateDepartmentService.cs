using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreateDepartmentService
    {
        int departmentinsert(CreateDepartmentDomain departin);
        int departmentupdate(CreateDepartmentDomain departup);
        int departmentdelete(int departdelet);
        IList<CreateDepartmentDomain> getalldepartment(int getalldepart);
        IList<CreateDepartmentDomain> getalldepartmentdd(int getalldepartdd);
    }
}
