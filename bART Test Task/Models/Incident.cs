using System.ComponentModel.DataAnnotations;

namespace bART_Test_Task.Models
{
    public class Incident
    {
        [Key]
        public string IncidentName { get; set; }
        public string? Description { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
