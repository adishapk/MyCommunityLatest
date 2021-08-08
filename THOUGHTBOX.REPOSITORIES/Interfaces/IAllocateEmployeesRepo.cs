using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IAllocateEmployeesRepo
    {
        int allocateempinsert(AllocateEmployeesDomain allocateempin, CreateRequest createrequestdetails);
        IList<AllocateEmployeesDomain> SelectAllocateddetailsforempid(int requestval, int empid);

    }
}
