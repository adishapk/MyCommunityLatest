using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
   public interface ICreatebusintargetmonthEmployeeService
    {
        int empmonthtargetinsert(CreatebusintargetmonthEmployeeDomain empmontargetinsrt);
        int empmonthtargetupdate(CreatebusintargetmonthEmployeeDomain empmontargetup);
        int getemptargtmonth(int target, string monthid, int selectemploy);
        int empmonthtargetdelete(int target, string monthid, int selectemploy);
        IList<CreatebusintargetmonthEmployeeDomain> getallempmonthtrgt(int getallempmonth);
    }
}
