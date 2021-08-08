using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
   public interface ICreatebusintargetmonthRepo
    {
        int monthtargetinsert(Createbusintargetmonth mnthtargtin);
        int monthtargetupdate(Createbusintargetmonth mnthtargtup);
        int monthtargetdelete(int monthtargetdel, string idmonth);
        IList<Createbusintargetmonth> getallmonthtrgt(int getallmonth);
        IList<Createbusintargetmonth> getamonthtrgt(int gettargt, string getmonth);
    }
}
