using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class AllocateEmployeesService : IAllocateEmployeesService
    {
        private IAllocateEmployeesRepo _allocateEmployeesRepo;
        public AllocateEmployeesService(IAllocateEmployeesRepo allocateEmployeesRepo)
        {
            _allocateEmployeesRepo = allocateEmployeesRepo;
        }

       
        public int allocateempinsert(AllocateEmployeesDomain allocateempin, CreateRequest createrequestdetails)
        {
            try
            {
                return _allocateEmployeesRepo.allocateempinsert(allocateempin, createrequestdetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<AllocateEmployeesDomain> SelectAllocateddetailsforempid(int requestval, int empid)
        {
            try
            {
                return _allocateEmployeesRepo.SelectAllocateddetailsforempid(requestval, empid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
