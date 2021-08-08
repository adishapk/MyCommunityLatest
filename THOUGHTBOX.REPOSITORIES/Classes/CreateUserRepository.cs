using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using THOUGHTBOX.REPOSITORIES.Interfaces;
using THOUGHTBOX.DOMAIN.Domain;
using Npgsql;
using System.IO;

namespace THOUGHTBOX.REPOSITORIES.Classes
{
    public class CreateUserRepository: ICreateUserRepository
    {

        ConnectionRepository connectionRepository = new ConnectionRepository();
        DataSet ds = new DataSet();
        Log Log = new Log();
        NpgsqlConnection connection = null;

        public int checkDuplication(string col, string tbl, string cond, string para)
        {
            return connectionRepository.CheckDuplication(col, tbl, cond, para);
        }       
        public IList<UserType> SelectPrvileges(string previlege_type)
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();

                string mQuery = "SELECT user_type_id, previlege_type, master_id,type_id, master_parent_id,case when (master_priority=0 and master_sub_priority=0) then (master_sub_sub_priority || ' (SubSubMenu)') when(master_sub_sub_priority = 0 and master_sub_priority = 0) then (master_priority || ' (Main Menu)') when(master_sub_sub_priority = 0 and master_priority = 0) then (master_sub_priority|| ' (SubMenu)') end as priority,file_name, master_sub_parentid FROM public.tbl_mark_usertype_privi where  previlege_type='" + previlege_type+"' order by master_sub_sub_priority,master_sub_priority,master_priority";
                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<UserType> userTypes = new List<UserType>();
               // connection = connectionRepository.GetPooledConnection();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userTypes.Add(new UserType
                        {
                            userTypeId = Convert.ToInt32(dr["user_type_id"].ToString()),
                            privilegeType = dr["previlege_type"].ToString(),
                            masterId = Convert.ToInt32(dr["master_id"].ToString()),
                            masterParentId = Convert.ToInt32(dr["master_parent_id"].ToString()),
                            masterSubParentId = Convert.ToInt32(dr["master_sub_parentid"].ToString()),
                            priority = dr["priority"].ToString(),
                            fileName = dr["file_name"].ToString(),                           
                            userId = Convert.ToInt32(dr["type_id"].ToString()),
                            masterName =Convert.ToInt32(dr["master_id"].ToString()) == 0 ? "" : connectionRepository.GetTableValue(connection, "public.tbl_mark_menu", "menu_name", "menu_id = '" + dr["master_id"].ToString() + "'"),

                        }
                        );
                    }

                }
                else
                {
                    userTypes = null;
                }
                ds.Dispose();
                connection.Close();
                return userTypes;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }      
        public string GetMasterNameByID(int userTypeId,string masterType)
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();
                UserType userType=new UserType();
                if (userTypeId != 0)
                {
                    string mQuery = "SELECT master_valuename FROM public.tbl_mark_mastertypevalues where master_typename =(select master_id FROM public.tbl_mark_mastertypevalues where upper(master_typename)='" + masterType.ToUpper()+ "' )::varchar(50) and master_id= "+userTypeId;
                    ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            userType.userTypeName = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            userType.userTypeName = null;
                        }
                    }                   
                }
                else
                {                   
                    userType.userTypeName = null;
                }
                ds.Dispose();
                connection.Dispose();
                return userType.userTypeName;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public string GetUserByID(int userTypeId)
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();
                UserType userType=new UserType();
                if (userTypeId != 0)
                {
                    string mQuery = "SELECT user_name FROM public.tbl_mark_userdetails where  user_status = 'Y' and user_id= " + userTypeId;
                    ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            userType.userTypeName = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            userType.userTypeName = null;
                        }
                    }                   
                }
                else
                {                   
                    userType.userTypeName = null;
                }
                ds.Dispose();
                connection.Dispose();

                return userType.userTypeName;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        List<UserType> ICreateUserRepository.GetUsers()
        {
            List<UserType> userTypes = new List<UserType>();           
            try
            {
                connection = connectionRepository.GetPooledConnection();
                string mQuery = "SELECT user_type_id,user_id,user_name FROM public.tbl_mark_userdetails where user_status = 'Y' order by user_type_id";
                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userTypes.Add(new UserType
                        {
                            userId = Convert.ToInt32(dr["user_id"].ToString()),                          
                            userTypeId = Convert.ToInt32(dr["user_type_id"].ToString()),                          
                            userName = dr["user_name"].ToString(),                         
                        }
                        );
                    }
                }
                else
                {
                    userTypes = null;
                }
                ds.Dispose();
                connection.Dispose();
                return userTypes;              
             }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {  
            }
        } 
        List<UserType> ICreateUserRepository.GetUserType(string mpermission,string mastertype)
        {
            List<UserType> userTypes = new List<UserType>();
            try
            {
                connection = connectionRepository.GetPooledConnection();
                string mQuery = "SELECT master_id,master_valuename FROM public.tbl_mark_mastertypevalues where master_typename = (select master_id FROM public.tbl_mark_mastertypevalues where upper(master_typename)='" + mastertype.ToUpper()+ "')::varchar ";
                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userTypes.Add(new UserType
                        {
                            userTypeId = Convert.ToInt32(dr["master_id"].ToString()),
                            userTypeName = dr["master_valuename"].ToString() ,
                        }
                        );
                    }
                }
                else
                {                   
                    userTypes = null;
                }
                ds.Dispose();
                connection.Dispose();
                return userTypes;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        public IList<UserType> GetRoles()
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();
                string mQuery = @"SELECT menu_id,menu_name, parent_id, file_name, icon_name FROM public.tbl_mark_menu order by parent_id";
            
                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                IList<UserType> userTypes = new List<UserType>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userTypes.Add(new UserType
                        {
                            masterParentId = Convert.ToInt32(dr["parent_id"].ToString()),
                            masterId = Convert.ToInt32(dr["menu_id"].ToString()),
                            masterName = dr["menu_name"].ToString(),
                            fileName = dr["file_name"].ToString(),                          
                         }
                        );
                    }
                }
                else
                {
                    userTypes.Add(new UserType
                    {
                        masterId = -1,
                    }
                    );
                }
                ds.Dispose();
                connection.Dispose();
                return userTypes;
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

                string mQuery = "Delete from public.tbl_mark_usertype_privi where user_type_id = "+Typeid+ " and previlege_type='" + previlege_type + "'";
                connectionRepository.PG_ManipulationMaster(mQuery);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateUserTypePrivilege(IList<UserType> userTypes, int count,string previlege_type)
        {
            try
            {
                DeletePrivilege(userTypes[0].userTypeId,previlege_type);
                InsertPrivilege(userTypes, count,previlege_type);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public bool InsertPrivilege(IList<UserType> userTypes, int count, string previlege_type)
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();
                if (previlege_type == "User")
                {
                    CreateLayoutPage(userTypes, count);
                }

                for (var i = 0; i < count; i++)
                {
                    string mQuery = "INSERT INTO public.tbl_mark_usertype_privi(user_type_id, previlege_type, master_id, master_parent_id,master_sub_parentid, master_priority, master_sub_priority,master_sub_sub_priority, file_name,type_id) VALUES(" + userTypes[i].userTypeId + ",'" + previlege_type + "'," + userTypes[i].masterId + "," + userTypes[i].masterParentId + "," + userTypes[i].masterSubParentId + "," + userTypes[i].masterPriority + "," + userTypes[i].masterSubPriority + "," + userTypes[i].masterSubSubPriority + ",'" + userTypes[i].fileName + "'," + userTypes[i].userId + ")";
                    connectionRepository.PG_ManipulationMaster(mQuery);

                }
                connection.Dispose();
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                return false;
            }
        }
        public IList<UserType> GetSelectedUserTypePrvileges(int userTypeId,string previlege_type)
        {
            try
            {
                connection = connectionRepository.GetPooledConnection();
                string mQuery = @"SELECT user_type_id, previlege_type, master_id, master_parent_id,case when (master_priority=0 and master_sub_priority=0) then master_sub_sub_priority  when (master_sub_sub_priority = 0 and master_sub_priority = 0) then master_priority  when(master_sub_sub_priority = 0 and master_priority = 0) then master_sub_priority end as priority,file_name, master_sub_parentid FROM public.tbl_mark_usertype_privi where user_type_id =" + userTypeId + " and previlege_type='" + previlege_type + "' order by master_parent_id,master_sub_parentid,master_sub_sub_priority,master_sub_priority,master_priority";

                ds = connectionRepository.PG_SelectMasterDS(mQuery, connection, null);
                connection = connectionRepository.GetPooledConnection();
                IList<UserType> userTypes = new List<UserType>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        userTypes.Add(new UserType
                        {
                            userTypeId = Convert.ToInt32(dr["user_type_id"].ToString()),
                            privilegeType = dr["previlege_type"].ToString(),
                            masterId = Convert.ToInt32(dr["master_id"].ToString()),
                            masterParentId = Convert.ToInt32(dr["master_parent_id"].ToString()),
                            masterSubParentId = Convert.ToInt32(dr["master_sub_parentid"].ToString()),                           
                            masterPriority = Convert.ToInt32(dr["priority"].ToString()),
                            fileName = dr["file_name"].ToString(),
                            masterName = Convert.ToInt32(dr["master_id"].ToString()) == 0 ? "" : connectionRepository.GetTableValue(connection, "public.tbl_mark_menu", "menu_name", "menu_id = '" + dr["master_id"].ToString() + "'"),

                        }
                        );
                    }
                }
                else
                {
                    userTypes = null;
                }
                ds.Dispose();
                connection.Dispose();

                return userTypes;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool CreateLayoutPage(IList<UserType> userTypes, int count)
        {
            try
            {
                StringBuilder sideBar = new StringBuilder();
                string sideMenuHtml = "", headerHtml = "", footerHtml = "", Layout = "";

                using (StreamReader streamReader = new StreamReader("headerLayout.txt", Encoding.UTF8))
                {
                    headerHtml = streamReader.ReadToEnd();
                }
                using (StreamReader streamReader = new StreamReader("footerLayout.txt", Encoding.UTF8))
                {
                    footerHtml = streamReader.ReadToEnd();
                }

                for (var i = 0; i < count; i++)
                {
                    if (userTypes[i].masterParentId == 0 && userTypes[i].masterSubParentId == 0)
                    {
                        //sideMenuHtml += "<li><a><i class='" + userTypes[i].fileName + "'></i>" + userTypes[i].masterName + "<span class='fa fa-chevron-down'></span></a>";
                        sideMenuHtml += "<li class='nav-item has-treeview'><a href = '#' class='nav-link active'><i class='nav-icon  " + userTypes[i].fileName + "'></i><p>" + userTypes[i].masterName + "<i class='right fas fa-angle-left'></i></p></a>";
                        sideMenuHtml += subList(userTypes, userTypes[i].masterId);
                    }               
                }

                                     
                                    
                Layout = headerHtml + sideMenuHtml + footerHtml;
                string layoutName = "_Layout" + userTypes[0].userTypeId+".cshtml";
               
             //   string filePath = @"C:\Users\ASUS\Desktop\RENTACARCMSNew\RENTACARCMS\THOUGHTBOX.HUMANRESOURCE\Views\Shared\" + layoutName ;
                string filePath = @"Views\Shared\" + layoutName ;

                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        Log.LogError(ex.ToString());
                    }
                }

                try
                {
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine(Layout);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    Log.LogError(ex.ToString());
                }
                
                updateLayoutName(userTypes, layoutName);
                return true;
            }
            catch(Exception ex)
            {
                Log.LogError(ex.ToString());
                return false;
            }
           
        }
        public string subList(IList<UserType> userTypes,int masterId)
        {                              
                                   
            string sideMenuHtml = "";
            sideMenuHtml += "<ul class='nav nav-treeview'>";
            for (var i = 0; i < userTypes.Count; i++)
            {
                if (userTypes[i].masterParentId != 0 && userTypes[i].masterSubParentId == 0)
                {
                    if(masterId == userTypes[i].masterParentId)
                    {
                        sideMenuHtml += "<li class='nav-item'><a href = '/" + userTypes[i].fileName + "' class='nav-link'><i class='far fa-circle nav-icon'></i><p>" + userTypes[i].masterName + "</p></a></li>";
                  
                    }
                 }
            }
            sideMenuHtml += "</ul></li>";
            return sideMenuHtml;
        }        
        public bool updateLayoutName(IList<UserType> userTypes,string layoutName)
        {
            try
            {
                NpgsqlConnection connection = null;
                connection = connectionRepository.GetPooledConnection();

                string mQuery = @"update tbl_mark_userdetails set user_layout='" + layoutName+"' where user_id= "+userTypes[0].userTypeId;
                connectionRepository.PG_ManipulationMaster(mQuery);
                connection.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }



    }
}

