namespace bART_Test_Task.Requests
{
    public class CreateIncidentRequest
    {
        public string AccountName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
        public string IncidentDescription { get; set; }
    }

}
