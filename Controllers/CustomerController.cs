using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:5000/api/burndown"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();                        
                    }
                }
            var result = _repository.GetCustomers();
            return Ok(result);
        }

        [HttpGet("Test")]
        public ActionResult<IEnumerable<Customer>> GetCustomersWithStress()
        {
            var result = _repository.GetCustomers();
            CpuStress.GenerateStress();
            return Ok(result);
        }
    }

}