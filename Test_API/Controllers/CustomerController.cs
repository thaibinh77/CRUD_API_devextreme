using Microsoft.AspNetCore.Mvc;
using Test_API.DAL;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly Data_Access_Layer _DAL;

        public CustomerController(Data_Access_Layer DAL)
        {
            _DAL = DAL;
        }

        [HttpGet]
        [Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            List<CustomerModel> listCustomer = new List<CustomerModel>();
            try
            {
                listCustomer = _DAL.GetAllCustomers();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(listCustomer);
        }

        [HttpPut]
        [Route("UpdateCustomers")]
        public IActionResult UpdateCustomers()
        {
            List<CustomerModel> listCustomer = new List<CustomerModel>();
            try
            {
                listCustomer = _DAL.GetAllCustomers();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(listCustomer);
        }
    }
}
