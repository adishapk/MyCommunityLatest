using System;
using System.Collections.Generic;
using System.Text;
using THOUGHTBOX.DOMAIN.Domain;
using System.Data;

namespace THOUGHTBOX.HR.SERVICES.Interfaces
{
    public interface ICreateUserService
    {
        bool DeletePrivilege(int Typeid,string previlege_type);
        int checkDuplication(string col, string tbl, string cond, string para);
       // bool Insert(UserType userType);
        List<UserType> GetUserType(string mpermission, string mastertype);
        List<UserType> GetUsers();
        IList<UserType> SelectPrvileges(string previlege_type);
        IList<UserType> GetSelectedUserTypePrvileges(int userTypeId, string previlege_type);
        IList<UserType> GetRoles();
        bool InsertPrivilege(IList<UserType> userTypes, int count,string previlege_type);
        bool UpdateUserTypePrivilege(IList<UserType> userTypes, int count, string previlege_type);
    }
}
