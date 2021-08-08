using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreateDepartmentService : ICreateDepartmentService
    {
        private ICreateDepartmentRepo _createDepartmentRepo;
        public CreateDepartmentService(ICreateDepartmentRepo createDepartmentRepo)
        {
            _createDepartmentRepo = createDepartmentRepo;
        }

        public int departmentdelete(int departdelet)
        {
            try
            {
                return _createDepartmentRepo.departmentdelete(departdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int departmentinsert(CreateDepartmentDomain departin)
        {
            try
            {
                return _createDepartmentRepo.departmentinsert(departin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int departmentupdate(CreateDepartmentDomain departup)
        {
            try
            {
                return _createDepartmentRepo.departmentupdate(departup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateDepartmentDomain> getalldepartment(int getalldepart)
        {
            try
            {
                IList<CreateDepartmentDomain> DEPTVALUES = new List<CreateDepartmentDomain>();
                IList<CreateDepartmentDomain> DEPTVALUES1 = new List<CreateDepartmentDomain>();

                DEPTVALUES = this._createDepartmentRepo.getalldepartment(getalldepart);
                if (DEPTVALUES[0].department_id.ToString() != "-1")
                {
                    for (int i = 0; i < DEPTVALUES.Count; i++)
                    {
                        DEPTVALUES1.Add(new CreateDepartmentDomain
                        {
                            department_id = Convert.ToInt32(DEPTVALUES[i].department_id.ToString()),
                            department_name = DEPTVALUES[i].department_name.ToString(),
                            department_code = DEPTVALUES[i].department_code.ToString(),
                            department_details = DEPTVALUES[i].department_details.ToString(),
                            Company_id = Convert.ToInt32(DEPTVALUES[i].Company_id.ToString()),
                            companyname = this._createDepartmentRepo.GetCompanyName(Convert.ToInt32(DEPTVALUES[i].Company_id.ToString())),

                        }
                   );
                    }
                }
                else
                {
                    DEPTVALUES1.Add(new CreateDepartmentDomain
                    {
                        department_id = -1
                    }
                  );
                }
                return DEPTVALUES1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //
            }

           
        }

        public IList<CreateDepartmentDomain> getalldepartmentdd(int getalldepartdd)
        {
            try
            {
                return _createDepartmentRepo.getalldepartmentdd(getalldepartdd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
