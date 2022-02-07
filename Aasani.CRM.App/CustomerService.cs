using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aasani.CRM.App
{
    public class CustomerService
    {
        private static List<Customer> customers;

        static CustomerService()
        {
            customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Chris",
                    LastName = "Brown",
                    Phone = "55486583454",
                    IsDeveloper = true
                },
                new Customer
                {
                    FirstName = "Paul",
                    LastName = "Green",
                    Phone = "567345456757",
                    IsDeveloper = false
                },
                new Customer
                {
                    FirstName = "Jean",
                    LastName = "White",
                    Phone = "567345456757",
                    IsDeveloper = true
                },
            };
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers.ToList();
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }
    }
}
