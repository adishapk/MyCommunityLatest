using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class UserdetailsService : IUserdetailsService
    {
        private IUserdetilsRepo _userdetilsRepo;
        public UserdetailsService(IUserdetilsRepo userdetilsRepo)
        {
            _userdetilsRepo = userdetilsRepo;
        }

        public int getusername(string userdupli)
        {
            try
            {
                return _userdetilsRepo.getusername(userdupli);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<UserdetailsDomain> sgetalluserdetails(int sgetalluser)
        {
            try

            {
                return _userdetilsRepo.rgetalluserdetails(sgetalluser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int suserdetailsdelete(int susrdetailsdelet)
        {
            try

            {
                return _userdetilsRepo.ruserdetailsdelete(susrdetailsdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int suserdetailsinsert(UserdetailsDomain susrdetailsinsrt)
        {
            try

            {
                return _userdetilsRepo.ruserdetailsinsert(susrdetailsinsrt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int suserdetailupdate(UserdetailsDomain susrdetailsupdt)
        {
            try
            {
                return _userdetilsRepo.ruserdetailupdate(susrdetailsupdt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
