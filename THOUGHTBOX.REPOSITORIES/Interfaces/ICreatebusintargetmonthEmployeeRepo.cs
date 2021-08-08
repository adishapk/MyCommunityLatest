using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
   public interface ICreatebusintargetmonthEmployeeRepo
    {
        int empmonthtargetinsert(CreatebusintargetmonthEmployeeDomain empmontargetinsrt);
        int empmonthtargetupdate(CreatebusintargetmonthEmployeeDomain empmontargetup);
        int empmonthtargetdelete(int target, string monthid, int selectemploy);
        int getemptargtmonth(int target, string monthid, int selectemploy);
        IList<CreatebusintargetmonthEmployeeDomain> getallempmonthtrgt(int getallempmonth);
    }
}
