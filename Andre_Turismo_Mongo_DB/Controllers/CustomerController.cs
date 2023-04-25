using Andre_Turismo_Mongo_DB.Models;
using Andre_Turismo_Mongo_DB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andre_Turismo_Mongo_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public ActionResult<List<CustomerModel>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<CustomerModel> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();

            return _customerService.Get(id);
        }
        [HttpPost]
        public ActionResult<CustomerModel> Create(CustomerModel customer)
        {
            return _customerService.Create(customer);
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, CustomerModel customer)
        {
            var c = _customerService.Get(id);
            if (c == null) return NotFound();

            _customerService.Update(id, customer);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();

            _customerService.Delete(id);
            return Ok();
        }
    }
}
