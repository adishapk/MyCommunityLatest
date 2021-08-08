using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class createDivisionService : ICreateDivision
    {
        private ICreateDivisionRepo _createDivisionRepo;
        private ICreateDepartmentRepo _createDepartmentRepo;
        public createDivisionService(ICreateDivisionRepo createDivisionRepo, ICreateDepartmentRepo createDepartmentRepo)
        {
            _createDivisionRepo = createDivisionRepo;
            _createDepartmentRepo = createDepartmentRepo;
        }

        public int divisioninsert(CreateDivisionDomain divisnin)
        {
            try
            {
                return _createDivisionRepo.divisioninsert(divisnin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int divisndelete(int divisndelet)
        {
            try
            {
                return _createDivisionRepo.divisndelete(divisndelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int divisnupdate(CreateDivisionDomain divisnup)
        {
            try
            {
                return _createDivisionRepo.divisnupdate(divisnup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<CreateDivisionDomain> getalldivisn(int getalldivisn)
        {
            try
            {
                IList<CreateDivisionDomain> DIVISVALUES = new List<CreateDivisionDomain>();
                IList<CreateDivisionDomain> DIVISVALUES1 = new List<CreateDivisionDomain>();

                DIVISVALUES = this._createDivisionRepo.getalldivisn(getalldivisn);
                if (DIVISVALUES[0].department_id.ToString() != "-1")
                {
                    for (int i = 0; i < DIVISVALUES.Count; i++)
                    {
                        DIVISVALUES1.Add(new CreateDivisionDomain
                        {
                            division_id = Convert.ToInt32(DIVISVALUES[i].division_id.ToString()),
                            division_name = DIVISVALUES[i].division_name.ToString(),
                            division_code = DIVISVALUES[i].division_code.ToString(),
                            division_details = DIVISVALUES[i].division_details.ToString(),
                            company_id = Convert.ToInt32(DIVISVALUES[i].company_id.ToString()),
                            department_id = Convert.ToInt32(DIVISVALUES[i].department_id.ToString()),
                            companyname = this._createDepartmentRepo.GetCompanyName(Convert.ToInt32(DIVISVALUES[i].company_id.ToString())),
                            departmentname = this._createDivisionRepo.GetDepartment(Convert.ToInt32(DIVISVALUES[i].department_id.ToString())),
                        }
                   );
                    }
                }
                else
                {
                    DIVISVALUES1.Add(new CreateDivisionDomain
                    {
                        division_id = -1
                    }
                  );
                }
                return DIVISVALUES1;
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
    }
}
