using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
   public interface ICreatebusintargetmonthService
    {
        int monthtargetinsert(Createbusintargetmonth mnthtargtin);
        int monthtargetupdate(Createbusintargetmonth mnthtargtup);
        IList<Createbusintargetmonth> getallmonthtrgt(int getallmonth);
        IList<Createbusintargetmonth> getamonthtrgt(int gettargt, string getmonth );
        int monthtargetdelete(int monthtargetdel,string idmonth);
    }
}
