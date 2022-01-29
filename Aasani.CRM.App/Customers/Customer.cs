namespace Aasani.CRM.App.Customers
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}