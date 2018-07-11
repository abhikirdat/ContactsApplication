using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuresContacts
{
    public class clsContact
    {
       public int ContactId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string EmailID { get; set; }
       public string MobileNumber { get; set; }
       public bool Status { get; set; }
    }
}
