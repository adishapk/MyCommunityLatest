using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IEmppersonalService
    {
        int semppersonalinsert(EmppersonalDomain semppersinsrt, EmpsalaryDomain salstruct);
        IList<EmppersonalDomain> sgetallemppersonl(int sgetallperson);
        IList<EmppersonalDomain> sgetemployee(int sgetperson);
        int semppersonalupdate(EmppersonalDomain semppersupdate, EmpsalaryDomain salstruct);
        int semppersonaldelete(int semppersdelet);
        IList<EmpsalaryDomain> Getsalarystructure(int employid, string Transtype);
        IList<EmppersonalDomain> getEmployeereportedto(int sgetperson);
        IList<EmppersonalDomain> GetEmployeeforempview(int generalid);

    }
}
