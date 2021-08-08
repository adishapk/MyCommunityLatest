using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreatealertsService
    {
        int alertinsert(CreatealertsDomain alertinsrt);
        int alertupdate(CreatealertsDomain alertupt);
        int alertdelete(int alertdelet);
        IList<CreatealertsDomain> getallalerts(int getallval);
    }
}
