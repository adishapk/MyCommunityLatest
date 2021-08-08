using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ISalarystructureRepo
    {
        int rsalrystructinsert(salarystructuredomain rslrystrct);
        int rsalrystructdelete(int rslrystrctdelt);
        int rsalrystructupdate(salarystructuredomain rsalrystructup);
        IList<salarystructuredomain> rgetsalarystructure(int rgetslrystruct);
        IList<salarystructuredomain> Getsalarystructure(string Sub_node);
    }
}
