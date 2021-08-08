using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreateCustomerService
    {
        int custinsert(CreateCustomerDomain customerinsrt);
        int custupdate(CreateCustomerDomain customerupdt);
        IList<CreateCustomerDomain> getallcustomer(int getallcust);
        IList<CreateCustomerDomain> getallassociate(string getallassoc);
        int customerdelete(int customerdelet);
    }
}
