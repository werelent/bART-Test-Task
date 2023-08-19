using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {   
        public int AccountId { get; set; }
        public string Name { get; set; }

        public string IncidentName { get; set; }
        public Incident Incident { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
