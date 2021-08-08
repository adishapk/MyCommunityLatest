using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class RegistrationService : IRegistration
    {
        private IRegistrationRepo _registrationRepo;
        public RegistrationService(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        public IList<RegistrationDomain> sgetemail(string semail)
        {
            try
            {
                return _registrationRepo.rgetemail(semail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserdetailsDomain> sgetlogin(string suser, string spass)
        {
            try
            {
                return _registrationRepo.rgetlogin(suser, spass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IList<RegistrationDomain> sgetuser(string susname)
        {
            try
            {
                return _registrationRepo.rgetuser(susname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int sreginsert(RegistrationDomain sinsert)
        {
            try
            {
                return _registrationRepo.rreginsert(sinsert);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
