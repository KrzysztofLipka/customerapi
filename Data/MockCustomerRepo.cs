using System.Collections.Generic;
using customerapi.Models;

namespace customerapi.Data
{
    public class MockCustomerRepo : ICustomerRepo
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new Customer[] {
                new Customer("Jan", "Kowalski"),
                new Customer("Adam", "Nowak")
            };
        }
    }
}