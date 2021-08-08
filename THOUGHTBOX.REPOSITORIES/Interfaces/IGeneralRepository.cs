using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;


namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface IGeneralRepository
    {
        string getautonumber(string parameter, int regionid);
        IList<Generaldomain> getGetGeneralValuesallthree(int reg_id, string subparentid, string mastertype);
        IList<Generaldomain> getGeneraltwovalueresultfromanytable(int reg_id, string condtionval, string tablename1, string tablename2, string innerjoinfield, string conditionfield);
        //To fill accordion buckets using single table
        IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename);
        //To fill accordion buckets using inner join table
        IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2);
        //To take decision hisitory
        IList<Generaldomain> getdecisionhistory(int jobcardid, string Requtype);
        int getalertcount(int dash_requ_by, string alertstat);
        IList<Generaldomain> getalertdata(int dash_requ_by, string alertstat);
        int setalertdata(int dash_requ_by, int alertstat);
        IList<Generaldomain> fillgenerallistingpage(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, int Regid, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2, string Orderby1, string Orderby2);
        IList<Generaldomain> generallistfillpopup(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string Fieldname5, string Fieldname6, string Fieldname7, string Fieldname8, string Fieldname9, string Fieldname10, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Orderby1, string Orderby2);
        Generaldomain GetGeneralValuesFromAnyTableTT(string Paramstring1, string Paramstring2, string paramTblname, string Field1, string Field2, string ConditionField1, string ConditionField2, string Condition1, string Condition2, string Decisionval);
        IList<Generaldomain> fillallbucketinnerjoin(string decisionvalue, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename1, string Tablename2, string Connectfield1, string Connectfield2);
        IList<Generaldomain> fillallbucket(string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionval1, string conditionval2, string conditionval3, string Tablename);
        IList<MastertypeDomain> getGeneraltwovalueresultfromanytablelist(string tablename, string decisionvalue, string Fieldtoretrieve1, string Fieldtoretrieve2, string Fieldtoretrieve3, string Fieldname1, string Fieldname2, string Fieldname3, string Fieldname4, string conditionfield1, string conditionfield2, string conditionfield3, string conditionfield4);
        int GetdeptheadID(int Requestid, string Requesttype, int employid);

    }
}
