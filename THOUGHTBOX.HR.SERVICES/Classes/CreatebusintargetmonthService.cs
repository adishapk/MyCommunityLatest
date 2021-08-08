using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
   public class CreatebusintargetmonthService : ICreatebusintargetmonthService
    {
        private ICreatebusintargetmonthRepo _createbusintargetmonthRepo;
        public CreatebusintargetmonthService(ICreatebusintargetmonthRepo createbusintargetmonthRepo)
        {
            _createbusintargetmonthRepo = createbusintargetmonthRepo;
        }

        public IList<Createbusintargetmonth> getallmonthtrgt(int getallmonth)
        {
            try
            {
                return _createbusintargetmonthRepo.getallmonthtrgt(getallmonth);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Createbusintargetmonth> getamonthtrgt(int gettargt, string getmonth)
        {
            try
            {
                return _createbusintargetmonthRepo.getamonthtrgt(gettargt, getmonth);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int monthtargetdelete(int monthtargetdel, string idmonth)
        {
            try
            {
                return _createbusintargetmonthRepo.monthtargetdelete(monthtargetdel, idmonth);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int monthtargetinsert(Createbusintargetmonth mnthtargtin)
        {
            try
            {
                return _createbusintargetmonthRepo.monthtargetinsert(mnthtargtin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int monthtargetupdate(Createbusintargetmonth mnthtargtup)
        {
            try
            {
                return _createbusintargetmonthRepo.monthtargetupdate(mnthtargtup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
