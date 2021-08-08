using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface IMastertypeServicce
    {
        int smastertypeinsert(MastertypeDomain smaster);
        int smastertypeupdate(MastertypeDomain smasterup);
        int smastertypedeleting(int smastertypdelt);
        int smastervaluesinsert(MastertypeDomain smastervaluein);
        int smastervalueupdate(MastertypeDomain smastervalueup);
        int smastervaluedeleting(int smastervaludelt);
        IList<MastertypeDomain> sgetfullmastertype(int sgetmastertype);
        IList<MastertypeDomain> sgetcreatemastertype(int sgetmastertypecreate);
        IList<MastertypeDomain> sgetfullmastervalues(int sgetmastervalues);
        IList<MastertypeDomain> Getspecificmastervalues(string checkfield);

        //------------------------------------Menu Creation-----------------------------
        IList<MastertypeDomain> selectAllMenu(string condition);
        int deleteMenu(int Id);
        int updateMenu(MastertypeDomain Masterupname);
        int insertMenu(MastertypeDomain Mastername);
    }
}
