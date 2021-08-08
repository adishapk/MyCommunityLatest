using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreateDivision
    {
        int divisioninsert(CreateDivisionDomain divisnin);
        int divisnupdate(CreateDivisionDomain divisnup);
        int divisndelete(int divisndelet);
        IList<CreateDivisionDomain> getalldivisn(int getalldivisn);
    }
}
