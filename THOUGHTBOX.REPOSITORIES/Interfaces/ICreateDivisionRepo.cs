using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateDivisionRepo
    {
        int divisioninsert(CreateDivisionDomain divisnin);
        int divisnupdate(CreateDivisionDomain divisnup);
        int divisndelete(int divisndelet);
        IList<CreateDivisionDomain> getalldivisn(int getalldivisn);
        string GetDepartment(int departmentid);
    }
}
