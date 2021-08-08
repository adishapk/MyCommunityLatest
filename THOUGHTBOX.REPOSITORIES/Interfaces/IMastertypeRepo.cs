using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IMastertypeRepo
    {
        int rmastertypeinsert(MastertypeDomain rmaster);
        int rmastertypeupdate(MastertypeDomain rmasterup);
        int rmastertypedeleting(int rmastertypdelt);
        int rmastervaluesinsert(MastertypeDomain rmastervaluein);
        int rmastervalueupdate(MastertypeDomain rmastervalueup);
        int rmastervaluedeleting(int rmastervaludelt);
        IList<MastertypeDomain> rgetfullmastertype(int rgetmastertype);
        IList<MastertypeDomain> rgetcreatemastertype(int rgetmastertypecreate);
        IList<MastertypeDomain> rgetfullmastervalues(int rgetmastervalues);
        IList<MastertypeDomain> Getspecificmastervalues(string checkfield);
        //------------------------------------Menu Creation-----------------------------
        IList<MastertypeDomain> selectAllMenu(string condition);
        int deleteMenu(int Id);
        int updateMenu(MastertypeDomain Masterupname);
        int insertMenu(MastertypeDomain Mastername);
        string GetmastertypeName(int mastertypenameval);

        string SelectmastervaluebyID(int masterid);

    }
}
