using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IUserdetilsRepo
    {
        IList<UserdetailsDomain> rgetalluserdetails(int rgetalluser);
        int ruserdetailsinsert(UserdetailsDomain rusrdetailsinsrt);
        int ruserdetailupdate(UserdetailsDomain rusrdetailsupdt);
        int ruserdetailsdelete(int rusrdetailsdelet);
        int getusername(string userdupli);
    }
}
