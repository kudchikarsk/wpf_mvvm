using System.ComponentModel.DataAnnotations;

namespace Aasani.CRM.App.Customers
{
    public class Customer : ValidateBindableBase
    {
        private string firstName;
        private string lastName;
        private string mobileNo;

        [Required]
        public string FirstName { get => firstName; set => SetProperty(ref firstName, value); }
        [Required]
        public string LastName { get => lastName; set => SetProperty(ref lastName, value); }
        [Required]
        [Phone]
        public string MobileNo { get => mobileNo; set => SetProperty(ref mobileNo, value); }

        public string FullName => $"{FirstName} {LastName}";
    }
}