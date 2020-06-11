using System.Collections.Generic;
using customerapi.Data;
using customerapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace customerapi.Controllers
{
    //api/Customers
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MockCustomerRepo _repository = new MockCustomerRepo();

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var result = _repository.GetCustomers();
            return Ok(result);
        }

    }
}