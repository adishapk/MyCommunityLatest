using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreateCompanyService
    {
        int companyinsert(CreateCompanyDomain companyin);
        int companyupdate(CreateCompanyDomain companyup);
        int companydelete(int companydelet);
        IList<CreateCompanyDomain> getallcompany(int getallcomp);
        IList<CreateCompanyDomain> getallcompanyfordd(int getallcompdd);
    }
}
