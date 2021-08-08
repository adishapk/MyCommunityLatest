using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IAllocateEmployeesService
    {
        int allocateempinsert(AllocateEmployeesDomain allocateempin, CreateRequest createrequestdetails);
        IList<AllocateEmployeesDomain> SelectAllocateddetailsforempid(int requestval, int empid);


    }
}
