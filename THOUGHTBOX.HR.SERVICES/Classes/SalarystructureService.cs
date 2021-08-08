using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class SalarystructureService : ISalarystructureService
    {
        private ISalarystructureRepo _salarystructureRepo;
        public SalarystructureService(ISalarystructureRepo salarystructureRepo)
        {
            _salarystructureRepo = salarystructureRepo;
        }

        public IList<salarystructuredomain> Getsalarystructure(string Sub_node)
        {
            try
            {
                return _salarystructureRepo.Getsalarystructure(Sub_node);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<salarystructuredomain> sgetsalarystructure(int sgetslrystruct)
        {
            try
            {
                return _salarystructureRepo.rgetsalarystructure(sgetslrystruct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ssalrystructdelete(int sslrystrctdelt)
        {
            try
            {
                return _salarystructureRepo.rsalrystructdelete(sslrystrctdelt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ssalrystructinsert(salarystructuredomain sslrystrct)
        {
            try
            {
                return _salarystructureRepo.rsalrystructinsert(sslrystrct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ssalrystructupdate(salarystructuredomain ssalrystructup)
        {
            try
            {
                return _salarystructureRepo.rsalrystructupdate(ssalrystructup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
