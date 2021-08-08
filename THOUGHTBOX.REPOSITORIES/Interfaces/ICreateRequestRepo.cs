using System.Collections.Generic;
using THOUGHTBOX.DOMAIN.Domain;

namespace THOUGHTBOX.REPOSITORIES.Interfaces
{
    public interface ICreateRequestRepo
    {
        int requestinsert(CreateRequest reqstin);
       // int requestupdate(CreateRequest reqstup);
        int reqaprveupdate(CreateRequest reqstapveup);
        int reqverifyupdate(CreateRequest reqstapveup);
        int requestdelete(int reqstdelet);
        IList<CreateRequest> getallrequest(int getallrqst);
        IList<CreateRequest> getalljoballoc(int getalljob);
        IList<CreateRequest> getalljoballocEmp(int getalljob);
        string getautonumber(string parameter);
    }
}
