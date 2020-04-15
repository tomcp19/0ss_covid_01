namespace BillingManagement.Models
{
    public class ContactInfo //test modif covid03 ,,,
    {
        public string ContactType { get; set; }
        public string Contact { get; set; }

        public string Info => $"{ContactType} : {Contact}";
    }
}