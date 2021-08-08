using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreateCompanyService : ICreateCompanyService
    {

        ICreateCompanyRepo _createCompanyRepo;
        public CreateCompanyService(ICreateCompanyRepo createCompanyRepo)
        {
            _createCompanyRepo = createCompanyRepo;
        }

        public int companydelete(int companydelet)
        {
            try
            {
                return _createCompanyRepo.companydelete(companydelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int companyinsert(CreateCompanyDomain companyin)
        {
            try
            {
                return _createCompanyRepo.companyinsert(companyin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int companyupdate(CreateCompanyDomain companyup)
        {
            try
            {
                return _createCompanyRepo.companyupdate(companyup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateCompanyDomain> getallcompany(int getallcomp)
        {
            try
            {
                return _createCompanyRepo.getallcompany(getallcomp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateCompanyDomain> getallcompanyfordd(int getallcompdd)
        {
            try
            {
                return _createCompanyRepo.getallcompanyfordd(getallcompdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
