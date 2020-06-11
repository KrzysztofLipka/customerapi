using System.Collections.Generic;
using customerapi.Models;

namespace customerapi.Data
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomers();
    }
}