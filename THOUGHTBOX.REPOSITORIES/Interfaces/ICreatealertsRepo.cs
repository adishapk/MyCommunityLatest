using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreatealertsRepo
    {
        int alertinsert(CreatealertsDomain alertinsrt);
        int alertupdate(CreatealertsDomain alertupt);
        int alertdelete(int alertdelet);
        IList<CreatealertsDomain> getallalerts(int getallval);
    }
}
