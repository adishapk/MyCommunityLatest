using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.REPOSITORIES.Classes;
using THOUGHTBOX.DOMAIN.Domain;
using System.Data;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateUserRepository
    {
        int checkDuplication(string col, string tbl, string cond, string para);
        bool DeletePrivilege(int Typeid, string previlege_type);
        string GetUserByID(int userTypeId);
        bool InsertPrivilege(IList<UserType> userTypes, int count,string previlege_type);
        List<UserType> GetUserType( string mpermission, string mastertype);
        List<UserType> GetUsers();
        IList<UserType> GetRoles();
        IList<UserType> SelectPrvileges(string previlege_type);
        IList<UserType> GetSelectedUserTypePrvileges(int userTypeId,string previlege_type);
        string GetMasterNameByID(int userTypeId,string masterType);
        bool UpdateUserTypePrivilege(IList<UserType> userTypes, int count, string previlege_type);


    }
}
