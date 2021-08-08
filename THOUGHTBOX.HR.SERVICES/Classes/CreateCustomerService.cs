using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private ICreateCustomerRepo _createCustomerRepo;
        public CreateCustomerService(ICreateCustomerRepo createCustomerRepo)
        {
            _createCustomerRepo = createCustomerRepo;
        }

        public int custinsert(CreateCustomerDomain customerinsrt)
        {
            try
            {
                return _createCustomerRepo.custinsert(customerinsrt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int customerdelete(int customerdelet)
        {
            try
            {
                return _createCustomerRepo.customerdelete(customerdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int custupdate(CreateCustomerDomain customerupdt)
        {
            try
            {
                return _createCustomerRepo.custupdate(customerupdt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateCustomerDomain> getallassociate(string getallassoc)
        {
            try
            {
                return _createCustomerRepo.getallassociate(getallassoc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateCustomerDomain> getallcustomer(int getallcust)
        {
            try
            {
                return _createCustomerRepo.getallcustomer(getallcust);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
