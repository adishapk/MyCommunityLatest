using System;
using System.Collections.Generic;
using System.Text;

namespace THOUGHTBOX.DOMAIN.Domain
{
    public class UserType
    {
        public int userTypeId { get; set; }
        public int userId { get; set; }
        public int regId { get; set; }
        public int masterId { get; set; }
        public int masterParentId { get; set; }
        public int masterSubParentId { get; set; }
        public int masterPriority { get; set; }
        public int masterSubPriority { get; set; }      
        public int masterSubSubPriority { get; set; }      
        public string userTypeName { get; set; }       
        public string userName { get; set; }       
        public string Password { get; set; }       
        public string privilegeType { get; set; }       
        public string masterName { get; set; }       
        public string fileName { get; set; }      
        public string masterType { get; set; }      
        public string priority { get; set; }      
        
    }
}
