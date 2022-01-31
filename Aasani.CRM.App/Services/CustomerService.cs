using Aasani.CRM.App.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aasani.CRM.App
{
    public class CustomerService
    {
        private static readonly List<Customer> customers;

        static CustomerService()
        {
            customers = new List<Customer> {
                    new Customer { FirstName = "Shadman", LastName = "Kudchikar", MobileNo = "7977503536" },
                    new Customer { FirstName = "Saif", LastName = "Kudchikar", MobileNo = "6977543536" },
                    new Customer { FirstName = "Suheb", LastName = "Kudchikar", MobileNo = "3977503536" },
                    new Customer { FirstName = "Aaman", LastName = "Kudchikar", MobileNo = "7875573536" },
                };
        }

        public List<Customer> GetAll()
        {
            return customers.ToList();
        }

        public void Add(Customer customer)
        {
            customers.Add(new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MobileNo = customer.MobileNo,
            });
        }
    }
}
