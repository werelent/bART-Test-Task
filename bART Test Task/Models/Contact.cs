namespace bART_Test_Task.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int? AccountID { get; set; }
        public Account? Account { get; set; }
    }
}
