using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IUserdetailsService
    {
        IList<UserdetailsDomain> sgetalluserdetails(int sgetalluser);
        int suserdetailsinsert(UserdetailsDomain susrdetailsinsrt);
        int suserdetailupdate(UserdetailsDomain susrdetailsupdt);
        int suserdetailsdelete(int susrdetailsdelet);
        int getusername(string userdupli);
    }
}
