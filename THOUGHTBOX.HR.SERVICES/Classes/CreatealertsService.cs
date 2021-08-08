using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreatealertsService : ICreatealertsService
    {
        private ICreatealertsRepo _createalertsRepo;
        public CreatealertsService(ICreatealertsRepo createalertsRepo)
        {
            _createalertsRepo = createalertsRepo;
        }

        public int alertdelete(int alertdelet)
        {
            try
            {
                return _createalertsRepo.alertdelete(alertdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int alertinsert(CreatealertsDomain alertinsrt)
        {
            try
            {
                return _createalertsRepo.alertinsert(alertinsrt);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int alertupdate(CreatealertsDomain alertupt)
        {
            try
            {
                return _createalertsRepo.alertupdate(alertupt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreatealertsDomain> getallalerts(int getallval)
        {
            try
            {
                return _createalertsRepo.getallalerts(getallval);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
