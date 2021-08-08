using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class EmppersonalService : IEmppersonalService
    {
        private IEmppersonalRepo _emppersonalRepo;
        private IMastertypeRepo _mastertypeRepo;
        public EmppersonalService(IEmppersonalRepo emppersonalRepo, IMastertypeRepo mastertypeRepo)
        {
            _emppersonalRepo = emppersonalRepo;
            _mastertypeRepo = mastertypeRepo;
        }

        public IList<EmppersonalDomain> GetEmployeeforempview(int generalid)
        {
            try
            {
                IList<EmppersonalDomain> _employeeDetails = new List<EmppersonalDomain>();
                IList<EmppersonalDomain> _employeeDetails1 = new List<EmppersonalDomain>();


                _employeeDetails = this._emppersonalRepo.GetEmployeeforempview(generalid);
                if (_employeeDetails[0].employee_id.ToString() != "-1")
                {
                    for (int i = 0; i < _employeeDetails.Count; i++)
                    {
                        _employeeDetails1.Add(new EmppersonalDomain
                        {
                            employee_id = Convert.ToInt32(_employeeDetails[i].employee_id.ToString()),
                            emp_firstname = _employeeDetails[i].emp_firstname.ToString(),
                            emp_lastname = _employeeDetails[i].emp_lastname.ToString(),
                            emp_code = _employeeDetails[i].emp_code.ToString(),
                            emp_cardno = _employeeDetails[i].emp_cardno.ToString(),
                            emp_mobileno = _employeeDetails[i].emp_mobileno.ToString(),
                            emp_status = _employeeDetails[i].emp_status.ToString(),
                            emp_dob = _employeeDetails[i].emp_dob.ToString(),
                            emp_dojoin = _employeeDetails[i].emp_dojoin.ToString(),
                            emp_qid = _employeeDetails[i].emp_qid.ToString(),
                            emp_qidexpiry = _employeeDetails[i].emp_qidexpiry.ToString(),
                            emp_healthcardid = _employeeDetails[i].emp_healthcardid.ToString(),
                            emp_hcardexpiry = _employeeDetails[i].emp_hcardexpiry.ToString(),
                            emp_ppno = _employeeDetails[i].emp_ppno.ToString(),
                            emp_ppexpiry = _employeeDetails[i].emp_ppexpiry.ToString(),
                            totalsalary = _employeeDetails[i].totalsalary.ToString(),
                            emp_grosssalary = _employeeDetails[i].emp_grosssalary.ToString(),
                            emp_totaldeductions = _employeeDetails[i].emp_totaldeductions.ToString(),
                            emp_photo = _employeeDetails[i].emp_photo.ToString(),
                            emp_reportedto = Convert.ToInt32(_employeeDetails[i].emp_reportedto.ToString()),


                            emp_nationalitystring = this._mastertypeRepo.SelectmastervaluebyID(Convert.ToInt32(_employeeDetails[i].emp_nationality.ToString())),
                            emp_designationstring = this._mastertypeRepo.SelectmastervaluebyID(Convert.ToInt32(_employeeDetails[i].emp_designation.ToString())),
                            emp_reportedtostring = this._emppersonalRepo.GetReportedtoEmployee(Convert.ToInt32(_employeeDetails[i].emp_reportedto.ToString())),
                           
                        }
                   );
                    }
                }
                else
                {
                    _employeeDetails1.Add(new EmppersonalDomain
                    {
                        employee_id = -1
                    }
                  );
                }
                return _employeeDetails1;
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

        public IList<EmppersonalDomain> getEmployeereportedto(int sgetperson)
        {
            try
            {
                return _emppersonalRepo.getEmployeereportedto(sgetperson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmpsalaryDomain> Getsalarystructure(int employid, string Transtype)
        {
            try
            {
                return _emppersonalRepo.Getsalarystructure(employid, Transtype);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int semppersonaldelete(int semppersdelet)
        {
            try
            {
                return _emppersonalRepo.remppersonaldelete(semppersdelet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int semppersonalinsert(EmppersonalDomain semppersinsrt, EmpsalaryDomain salstruct)
        {
            try

            {
                return _emppersonalRepo.remppersonalinsert(semppersinsrt, salstruct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int semppersonalupdate(EmppersonalDomain semppersupdate, EmpsalaryDomain salstruct)
        {
            try
            {
                return _emppersonalRepo.remppersonalupdate(semppersupdate, salstruct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmppersonalDomain> sgetallemppersonl(int sgetallperson)
        {
            try
            {
                return _emppersonalRepo.rgetallemppersonl(sgetallperson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<EmppersonalDomain> sgetemployee(int sgetperson)
        {
            try
            {
                return _emppersonalRepo.rgetemployee(sgetperson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
