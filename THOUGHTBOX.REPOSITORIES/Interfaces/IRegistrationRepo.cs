using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IRegistrationRepo
    {
        IList<RegistrationDomain> rgetuser(string rusname);
        IList<RegistrationDomain> rgetemail(string remail);
        int rreginsert(RegistrationDomain rinsert);
        IList<UserdetailsDomain> rgetlogin(string ruser, string rpass);
    }
}
