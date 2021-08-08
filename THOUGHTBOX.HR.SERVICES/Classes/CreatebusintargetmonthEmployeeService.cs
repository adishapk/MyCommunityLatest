using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
   public class CreatebusintargetmonthEmployeeService : ICreatebusintargetmonthEmployeeService
    {
        private ICreatebusintargetmonthEmployeeRepo _createbusintargetmonthEmployeeRepo;
        public CreatebusintargetmonthEmployeeService (ICreatebusintargetmonthEmployeeRepo createbusintargetmonthEmployeeRepo)
        {
            _createbusintargetmonthEmployeeRepo = createbusintargetmonthEmployeeRepo;
        }

        public int empmonthtargetdelete(int target, string monthid, int selectemploy)
        {
            try
            {
                return _createbusintargetmonthEmployeeRepo.empmonthtargetdelete(target, monthid, selectemploy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int empmonthtargetinsert(CreatebusintargetmonthEmployeeDomain empmontargetinsrt)
        {
            try
            {
                return _createbusintargetmonthEmployeeRepo.empmonthtargetinsert(empmontargetinsrt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int empmonthtargetupdate(CreatebusintargetmonthEmployeeDomain empmontargetup)
        {
            try
            {
                return _createbusintargetmonthEmployeeRepo.empmonthtargetupdate(empmontargetup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreatebusintargetmonthEmployeeDomain> getallempmonthtrgt(int getallempmonth)
        {
            try
            {
                return _createbusintargetmonthEmployeeRepo.getallempmonthtrgt(getallempmonth);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int getemptargtmonth(int target, string monthid, int selectemploy)
        {
            try
            {
                return _createbusintargetmonthEmployeeRepo.getemptargtmonth(target, monthid, selectemploy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
