using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateCustomerRepo
    {
        int custinsert(CreateCustomerDomain customerinsrt);
        int custupdate(CreateCustomerDomain customerupdt);
        int customerdelete(int customerdelet);
        IList<CreateCustomerDomain> getallcustomer(int getallcust);
        IList<CreateCustomerDomain> getallassociate(string getallassoc);
    }
}
