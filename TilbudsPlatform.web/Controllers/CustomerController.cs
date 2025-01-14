using Microsoft.AspNetCore.Mvc;
using TilbudsPlatform.core.Interfaces;

namespace TilbudsPlatform.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerService;

        public CustomerController(ICustomerInterface customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }
    }
}
