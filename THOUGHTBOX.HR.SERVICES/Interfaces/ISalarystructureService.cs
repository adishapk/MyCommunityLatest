using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ISalarystructureService
    {
        int ssalrystructinsert(salarystructuredomain sslrystrct);
        int ssalrystructdelete(int sslrystrctdelt);
        int ssalrystructupdate(salarystructuredomain ssalrystructup);
        IList<salarystructuredomain> sgetsalarystructure(int sgetslrystruct);
        IList<salarystructuredomain> Getsalarystructure(string Sub_node);
    }
}
