using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.HR.SERVICES.Classes
{
   public class CreatebusintargetyearService : ICreatebusintargetyearService
    {
        private ICreatebusintargetyearRepo _createbusintargetyearRepo;
        public CreatebusintargetyearService(ICreatebusintargetyearRepo createbusintargetyearRepo)
        {
            _createbusintargetyearRepo = createbusintargetyearRepo;
        }

        public IList<CreatebusintargetyearDomain> getalltarget(int getalltarg)
        {
            try
            {
                return _createbusintargetyearRepo.getalltarget(getalltarg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreatebusintargetyearDomain> getallyeartarget(int getyeartarg)
        {
            try
            {
                return _createbusintargetyearRepo.getallyeartarget(getyeartarg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string gettargetyear(string getyear, int getcompany, int getdepartment)
        {
            try
            {
                return _createbusintargetyearRepo.gettargetyear(getyear, getcompany, getdepartment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int targetdelete(int targetdelet)
        {
            try
            {
                return _createbusintargetyearRepo.targetdelete(targetdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int targetinsert(CreatebusintargetyearDomain targetin)
        {
            try
            {
                return _createbusintargetyearRepo.targetinsert(targetin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int targetupdate(CreatebusintargetyearDomain targetup)
        {
            try
            {
                return _createbusintargetyearRepo.targetupdate(targetup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
