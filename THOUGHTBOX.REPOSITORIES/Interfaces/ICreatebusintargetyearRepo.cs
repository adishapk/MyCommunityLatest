using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;


namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
   public interface ICreatebusintargetyearRepo
    {
        int targetinsert(CreatebusintargetyearDomain targetin);
        IList<CreatebusintargetyearDomain> getalltarget(int getalltarg);
        IList<CreatebusintargetyearDomain> getallyeartarget(int getyeartarg);
        int targetupdate(CreatebusintargetyearDomain targetup);
        int targetdelete(int targetdelet);
        string gettargetyear(string getyear, int getcompany, int getdepartment);
    }
}
