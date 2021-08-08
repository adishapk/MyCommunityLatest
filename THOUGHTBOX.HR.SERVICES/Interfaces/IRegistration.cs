using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IRegistration
    {
        IList<RegistrationDomain> sgetuser(string susname);
        IList<RegistrationDomain> sgetemail(string semail);
        int sreginsert(RegistrationDomain sinsert);
        IList<UserdetailsDomain> sgetlogin(string suser, string spass);
    }
}
