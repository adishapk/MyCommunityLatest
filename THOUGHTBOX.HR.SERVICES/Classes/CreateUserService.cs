using System;
using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Interfaces;


namespace THOUGHTBOX.HR.SERVICES.Classes
{
    public class CreateUserService : ICreateUserService
    {
        private ICreateUserRepository _createUserRepository;
        Log Log = new Log();
        public CreateUserService(ICreateUserRepository createUserRepository)
        {
            this._createUserRepository = createUserRepository;

        }
        public List<UserType> GetUserType(string mpermission, string mastertype)
        {
            try
            {
                return this._createUserRepository.GetUserType(mpermission,mastertype);
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
      
        public List<UserType> GetUsers()
        {
            try
            {
                return this._createUserRepository.GetUsers();
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

        public IList<UserType> GetRoles()
        {
            try
            {
                return this._createUserRepository.GetRoles();
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

        public bool InsertPrivilege(IList<UserType> userTypes, int count,string previlege_type)
        {
            try
            {
                return this._createUserRepository.InsertPrivilege(userTypes,count,previlege_type);
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
        public bool UpdateUserTypePrivilege(IList<UserType> userTypes, int count,string previlege_type)
        {
            try
            {
                return this._createUserRepository.UpdateUserTypePrivilege(userTypes,count,previlege_type);
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
        public IList<UserType> SelectPrvileges(string previlege_type)
        {
            try
            {
                IList<UserType> usertype = new List<UserType>();
                IList<UserType> usertype1 = new List<UserType>();

                usertype = this._createUserRepository.SelectPrvileges(previlege_type);
                if (usertype != null)
                {
                    int len = usertype.Count;
                    var groupname = "";
                   
                    IList<UserType> masterList = new List<UserType>();
                    IList<UserType> subList = new List<UserType>();
                    for (int i = 0; i < len; i++)
                    {                              
                        if (Convert.ToInt32(usertype[0].userId.ToString()) == 0)
                        {
                            groupname = this._createUserRepository.GetMasterNameByID(Convert.ToInt32(usertype[i].userTypeId.ToString()),  "UserType");
                        }
                        else
                        {
                            groupname = this._createUserRepository.GetUserByID(Convert.ToInt32(usertype[i].userTypeId.ToString()));
                        }
                        if (groupname!=null)
                        {
                            if (Convert.ToInt32(usertype[i].masterParentId.ToString()) == 0 && Convert.ToInt32(usertype[i].masterSubParentId.ToString()) == 0)
                            {
                                masterList.Add(new UserType
                                {
                                    userTypeId = Convert.ToInt32(usertype[i].userTypeId.ToString()),
                                    userId = Convert.ToInt32(usertype[i].userId.ToString()),
                                    masterParentId = Convert.ToInt32(usertype[i].masterParentId.ToString()),
                                    masterSubParentId = Convert.ToInt32(usertype[i].masterSubParentId.ToString()),
                                    priority = usertype[i].priority.ToString(),
                                    masterId = Convert.ToInt32(usertype[i].masterId.ToString()),
                                    fileName = usertype[i].fileName.ToString(),
                                    masterName = usertype[i].masterName.ToString(),
                                    userTypeName = groupname
                                }
                             ); ;
                            }
                            else if (Convert.ToInt32(usertype[i].masterParentId.ToString()) != 0 && Convert.ToInt32(usertype[i].masterSubParentId.ToString()) == 0)
                            {
                                subList.Add(new UserType
                                {
                                    userTypeId = Convert.ToInt32(usertype[i].userTypeId.ToString()),
                                    userId = Convert.ToInt32(usertype[i].userId.ToString()),
                                    masterParentId = Convert.ToInt32(usertype[i].masterParentId.ToString()),
                                    masterSubParentId = Convert.ToInt32(usertype[i].masterSubParentId.ToString()),
                                    priority = usertype[i].priority.ToString(),
                                    masterId = Convert.ToInt32(usertype[i].masterId.ToString()),
                                    fileName = usertype[i].fileName.ToString(),
                                    masterName = usertype[i].masterName.ToString(),
                                    userTypeName = groupname
                                }
                            ); ;

                            }
                
                        }

                    }
                    var len1 = masterList.Count;
                    var len2 = subList.Count;
               
                    for(int i = 0; i < len1; i++)
                    {
                        usertype1.Add(new UserType
                        {
                            userTypeId = Convert.ToInt32(masterList[i].userTypeId.ToString()),
                            userId = Convert.ToInt32(masterList[i].userId.ToString()),
                            masterParentId = Convert.ToInt32(masterList[i].masterParentId.ToString()),
                            masterSubParentId = Convert.ToInt32(masterList[i].masterSubParentId.ToString()),
                            priority = masterList[i].priority.ToString(),
                            masterId = Convert.ToInt32(masterList[i].masterId.ToString()),
                            fileName = masterList[i].fileName.ToString(),
                            masterName = masterList[i].masterName.ToString(),
                            userTypeName = masterList[i].userTypeName.ToString(),
                        });

                        for(int j = 0; j < len2; j++)
                        {
                            if(Convert.ToInt32(masterList[i].masterId.ToString())== Convert.ToInt32(subList[j].masterParentId.ToString())&&Convert.ToInt32(masterList[i].userTypeId.ToString())== Convert.ToInt32(subList[j].userTypeId.ToString()))
                            {
                                usertype1.Add(new UserType
                                {
                                    userTypeId = Convert.ToInt32(subList[j].userTypeId.ToString()),
                                    userId = Convert.ToInt32(subList[j].userId.ToString()),
                                    masterParentId = Convert.ToInt32(subList[j].masterParentId.ToString()),
                                    masterSubParentId = Convert.ToInt32(subList[j].masterSubParentId.ToString()),
                                    priority = subList[j].priority.ToString(),
                                    masterId = Convert.ToInt32(subList[j].masterId.ToString()),
                                    fileName = subList[j].fileName.ToString(),
                                    masterName = subList[j].masterName.ToString(),
                                    userTypeName = subList[j].userTypeName.ToString(),
                                });
                            }
                            
                        }
                        

                    }
                }


                return usertype1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
     
        public IList<UserType> GetSelectedUserTypePrvileges(int userTypeId,  string previlege_type)
        {
            try
            {
                IList<UserType> usertype = new List<UserType>();
                IList<UserType> usertype1 = new List<UserType>();

                usertype =  this._createUserRepository.GetSelectedUserTypePrvileges(userTypeId,previlege_type);
                if (usertype != null)
                {
                    int len = usertype.Count;
                           
                    for (int i = 0; i < len; i++)
                    {
                        usertype1.Add(new UserType
                        {
                            userTypeId = Convert.ToInt32(usertype[i].userTypeId.ToString()),
                            privilegeType = usertype[i].privilegeType.ToString(),
                            masterParentId = Convert.ToInt32(usertype[i].masterParentId.ToString()),
                            masterSubParentId = Convert.ToInt32(usertype[i].masterSubParentId.ToString()),
                            masterPriority = Convert.ToInt32(usertype[i].masterPriority.ToString()),
                            masterId = Convert.ToInt32(usertype[i].masterId.ToString()),
                            fileName = usertype[i].fileName.ToString(),
                            masterName = usertype[i].masterName.ToString(),
                            // userTypeName = groupname
                        }
                          ); ;

                    }
                }

                return usertype1;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            
        }

        public bool DeletePrivilege(int Typeid,string previlege_type)
        {
            try
            {
                return this._createUserRepository.DeletePrivilege(Typeid,previlege_type);
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

        public int checkDuplication(string col, string tbl, string cond, string para)
        {
            try
            {
               return this._createUserRepository.checkDuplication(col, tbl, cond, para);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
