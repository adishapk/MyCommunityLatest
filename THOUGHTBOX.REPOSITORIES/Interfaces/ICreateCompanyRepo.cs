using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateCompanyRepo
    {
        int companyinsert(CreateCompanyDomain companyin);
        int companyupdate(CreateCompanyDomain companyup);
        int companydelete(int companydelet);
        IList<CreateCompanyDomain> getallcompany(int getallcomp);
        IList<CreateCompanyDomain> getallcompanyfordd(int getallcompdd);
    }
}
