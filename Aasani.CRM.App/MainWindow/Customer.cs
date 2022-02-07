namespace Aasani.CRM.App
{
    public class Customer : Observable
    {
        private string firstName;
        private string lastName;
        private string phone;
        private bool isDeveloper;

        public string FirstName { get => firstName; set => OnPropertyChange(ref firstName, value); }
        public string LastName { get => lastName; set => OnPropertyChange(ref lastName, value); }
        public string Phone { get => phone; set => OnPropertyChange(ref phone, value); }
        public bool IsDeveloper { get => isDeveloper; set => OnPropertyChange(ref isDeveloper, value); }
        
    }
}