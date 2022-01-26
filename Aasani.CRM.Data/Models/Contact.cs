using System.Collections.Generic;

namespace Aasani.CRM.Data
{
    public class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Mobiles { get; set; }
    }
}