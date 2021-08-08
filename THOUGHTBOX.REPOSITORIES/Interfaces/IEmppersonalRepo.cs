using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IEmppersonalRepo
    {
        int remppersonalinsert(EmppersonalDomain remppersinsrt, EmpsalaryDomain salstruct);
        IList<EmppersonalDomain> rgetallemppersonl(int rgetallperson);
        IList<EmppersonalDomain> rgetemployee(int rgetperson);
        int remppersonalupdate(EmppersonalDomain remppersupdate, EmpsalaryDomain salstruct);
        int remppersonaldelete(int remppersdelet);
        IList<EmpsalaryDomain> Getsalarystructure(int employid, string Transtype);
        IList<EmppersonalDomain> getEmployeereportedto(int sgetperson);
        IList<EmppersonalDomain> GetEmployeeforempview(int generalid);
        string GetReportedtoEmployee(int employeeid);
    }
}
