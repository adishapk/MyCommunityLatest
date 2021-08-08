using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class MastertypeServicce : IMastertypeServicce
    {
        private IMastertypeRepo _mastertypeRepo;
        public MastertypeServicce(IMastertypeRepo mastertypeRepo)
        {
            _mastertypeRepo = mastertypeRepo;
        }       

        public IList<MastertypeDomain> Getspecificmastervalues(string checkfield)
        {
            try
            {
                return _mastertypeRepo.Getspecificmastervalues(checkfield);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public IList<MastertypeDomain> sgetcreatemastertype(int sgetmastertypecreate)
        {
            try
            {
                return _mastertypeRepo.rgetcreatemastertype(sgetmastertypecreate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<MastertypeDomain> sgetfullmastertype(int sgetmastertype)
        {
            try
            {
                return _mastertypeRepo.rgetfullmastertype(sgetmastertype);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<MastertypeDomain> sgetfullmastervalues(int sgetmastervalues)
        {
            try
            {
                IList<MastertypeDomain> MASTERVALUES = new List<MastertypeDomain>();
                IList<MastertypeDomain> MASTERVALUES1 = new List<MastertypeDomain>();

                MASTERVALUES = this._mastertypeRepo.rgetfullmastervalues(sgetmastervalues);
                if (MASTERVALUES[0].master_id.ToString() != "-1")
                {
                    for (int i = 0; i < MASTERVALUES.Count; i++)
                    {
                        MASTERVALUES1.Add(new MastertypeDomain
                        {
                            master_valuename = MASTERVALUES[i].master_valuename.ToString(),
                            master_typename = MASTERVALUES[i].master_typename.ToString(),
                            master_valueremarks = MASTERVALUES[i].master_valueremarks.ToString(),
                            master_valueflag = MASTERVALUES[i].master_valueflag.ToString(),
                            master_id = Convert.ToInt32(MASTERVALUES[i].master_id.ToString()),
                            master_typename_string = this._mastertypeRepo.GetmastertypeName(Convert.ToInt32(MASTERVALUES[i].master_typename.ToString())),

                        }
                   );
                    }
                }
                else
                {
                    MASTERVALUES1.Add(new MastertypeDomain
                    {
                        master_id = -1
                    }
                  );
                }
                return MASTERVALUES1;
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

        public int smastertypedeleting(int smastertypdelt)
        {
            try
            {
                return _mastertypeRepo.rmastertypedeleting(smastertypdelt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int smastertypeinsert(MastertypeDomain smaster)
        {
            try
            {
                return _mastertypeRepo.rmastertypeinsert(smaster);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int smastertypeupdate(MastertypeDomain smasterup)
        {
            try
            {
                return _mastertypeRepo.rmastertypeupdate(smasterup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int smastervaluedeleting(int smastervaludelt)
        {
            try
            {
                return _mastertypeRepo.rmastervaluedeleting(smastervaludelt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int smastervaluesinsert(MastertypeDomain smastervaluein)
        {
            try
            {
                return _mastertypeRepo.rmastervaluesinsert(smastervaluein);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int smastervalueupdate(MastertypeDomain smastervalueup)
        {
            try
            {
                return _mastertypeRepo.rmastervalueupdate(smastervalueup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //----------------------------------Create Menu----------------------------------
        public int insertMenu(MastertypeDomain Mastername)
        {
            try
            {
                return _mastertypeRepo.insertMenu(Mastername);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IList<MastertypeDomain> selectAllMenu(string condition)
        {
            try
            {
                return _mastertypeRepo.selectAllMenu(condition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int updateMenu(MastertypeDomain Masterupname)
        {
            try
            {
                return _mastertypeRepo.updateMenu(Masterupname);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int deleteMenu(int Id)
        {
            try
            {
                return _mastertypeRepo.deleteMenu(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
