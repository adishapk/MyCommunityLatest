using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class GeneralService : IGeneralService
    {
        private IGeneralRepository _Generalrepository;

        Log Log = new Log();
        public GeneralService(IGeneralRepository Generalrepository)
        {
            _Generalrepository = Generalrepository;
        }

        public IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename)
        {
            try
            {
                return _Generalrepository.fillallbucket(Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Regid, Tablename);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2)
        {
            try
            {
                return _Generalrepository.fillallbucketinnerjoin(decisionvalue, Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Regid, Tablename1, Tablename2, Connectfield1, Connectfield2);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> fillgenerallistingpage(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2, string Orderby1, string Orderby2)
        {
            try
            {
                return _Generalrepository.fillgenerallistingpage(decisionvalue, Fieldname1, Fieldname2, Fieldname3, Fieldname4, Fieldname5, Fieldname6, Fieldname7, Fieldname8, Fieldname9, Fieldname10, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Regid, Tablename1, Tablename2, Connectfield1, Connectfield2, Orderby1, Orderby2);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> generallistfillpopup(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Orderby1, string Orderby2)
        {
            try
            {
                return _Generalrepository.generallistfillpopup(decisionvalue, Fieldname1, Fieldname2, Fieldname3, Fieldname4, Fieldname5, Fieldname6, Fieldname7, Fieldname8, Fieldname9, Fieldname10, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Tablename1, Orderby1, Orderby2);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public int getalertcount(int dash_requ_by, string alertstat)
        {
            try
            {
                return _Generalrepository.getalertcount(dash_requ_by, alertstat);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> getalertdata(int dash_requ_by, string alertstat)
        {
            try
            {
                return _Generalrepository.getalertdata(dash_requ_by, alertstat);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public string getautonumber(string parameter, int regionid)
        {
            try
            {
                return _Generalrepository.getautonumber(parameter, regionid);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public Generaldomain GetGeneralValuesFromAnyTableTT(string Paramstring1, string Paramstring2, string paramTblname, string Field1, string Field2, string ConditionField1, string ConditionField2, string Condition1, string Condition2, string Decisionval)
        {
            try
            {
                return _Generalrepository.GetGeneralValuesFromAnyTableTT(Paramstring1, Paramstring2, paramTblname, Field1, Field2, ConditionField1, ConditionField2, Condition1, Condition2, Decisionval);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> getdecisionhistory(int jobcardid, string Requtype)
        {
            try
            {

                IList<Generaldomain> _generalDomain = new List<Generaldomain>();
                IList<Generaldomain> _generalDomain1 = new List<Generaldomain>();

                _generalDomain = this._Generalrepository.getdecisionhistory(jobcardid, Requtype);

                if (_generalDomain[0].Generalval1.ToString() != "-1")
                {
                    for (int i = 0; i < _generalDomain.Count; i++)
                    {
                        _generalDomain1.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(_generalDomain[i].Generalval1.ToString()),
                            Generalval2 = _generalDomain[i].Generalval2.ToString(),
                            Gneralaval3 = _generalDomain[i].Gneralaval3.ToString(),
                            Gneralaval4 = _generalDomain[i].Gneralaval4.ToString(),
                            Gneralaval5 = _generalDomain[i].Gneralaval5.ToString(),
                            Gneralaval6 = _generalDomain[i].Gneralaval6.ToString(),
                            Gneralaval7 = _generalDomain[i].Gneralaval7.ToString(),
                            Gneralaval8 = _generalDomain[i].Gneralaval8.ToString(),
                            Gneralaval9 = _generalDomain[i].Gneralaval9.ToString(),
                            Gneralaval10 = _generalDomain[i].Gneralaval10.ToString(),

                        }
                   );
                    }
                }
                else
                {
                    _generalDomain1.Add(new Generaldomain
                    {
                        Generalval1 = -1
                    }
                  );
                }
                return _generalDomain1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                //
            }
        }

        public IList<Generaldomain> getGeneraltwovalueresultfromanytable(int reg_id, string condtionval, string tablename1, string tablename2, string innerjoinfield, string conditionfield)
        {
            try
            {
                IList<Generaldomain> _generalDomain = new List<Generaldomain>();
                IList<Generaldomain> _generalDomain1 = new List<Generaldomain>();

                _generalDomain = this._Generalrepository.getGeneraltwovalueresultfromanytable(reg_id, condtionval, tablename1, tablename2, innerjoinfield, conditionfield);

                if (_generalDomain[0].Generalval1.ToString() != "-1")
                {
                    for (int i = 0; i < _generalDomain.Count; i++)
                    {
                        _generalDomain1.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(_generalDomain[i].Generalval1.ToString()),
                            Generalval2 = _generalDomain[i].Generalval2.ToString(),
                        }
                   );
                    }
                }
                else
                {
                    _generalDomain1.Add(new Generaldomain
                    {
                        Generalval1 = -1
                    }
                  );
                }
                return _generalDomain1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                //
            }
        }
        public IList<Generaldomain> getGetGeneralValuesallthree(int reg_id, string subparentid, string mastertype)
        {
            try
            {
                IList<Generaldomain> _generalDomain = new List<Generaldomain>();
                IList<Generaldomain> _generalDomain1 = new List<Generaldomain>();

                _generalDomain = this._Generalrepository.getGetGeneralValuesallthree(reg_id, subparentid, mastertype);

                if (_generalDomain[0].Generalval1.ToString() != "-1")
                {
                    for (int i = 0; i < _generalDomain.Count; i++)
                    {
                        _generalDomain1.Add(new Generaldomain
                        {
                            Generalval1 = Convert.ToInt32(_generalDomain[i].Generalval1.ToString()),
                            Generalval2 = _generalDomain[i].Generalval2.ToString(),
                            //mastertype = this._Generalrepository.getGetGeneralValuesallfour(Convert.ToInt32(_generalDomain[i].Generalval1.ToString())),
                        }
                   );
                    }
                }
                else
                {
                    _generalDomain1.Add(new Generaldomain
                    {
                        Generalval1 = -1
                    }
                  );
                }
                return _generalDomain1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                //
            }
        }

        public int setalertdata(int dash_requ_by, int alertstat)
        {
            try
            {
                return _Generalrepository.setalertdata(dash_requ_by, alertstat);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2)
        {
            try
            {
                return _Generalrepository.fillallbucketinnerjoin(decisionvalue, Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Tablename1, Tablename2, Connectfield1, Connectfield2);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename)
        {
            try
            {
                return _Generalrepository.fillallbucket(Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, Tablename);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }

        }

        public IList<MastertypeDomain> getGeneraltwovalueresultfromanytablelist(string tablename, string decisionvalue, string Fieldtoretrieve1, string Fieldtoretrieve2, string Fieldtoretrieve3, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionfield4)
        {
            try
            {
                return _Generalrepository.getGeneraltwovalueresultfromanytablelist(tablename, decisionvalue, Fieldtoretrieve1, Fieldtoretrieve2, Fieldtoretrieve3, Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionfield4);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public int GetdeptheadID(int Requestid, string Requesttype, int employid)
        {
            try
            {

                return _Generalrepository.GetdeptheadID(Requestid, Requesttype, employid);
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
