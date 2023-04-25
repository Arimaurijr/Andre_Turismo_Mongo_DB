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
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public CustomerController(CustomerService customerService, AddressService addressService, CityService cityService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _cityService = cityService;
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
            //return _customerService.Create(customer);
            CityModel city = _cityService.Create(customer.Endereco.Cidade);
            AddressModel endereco = _addressService.Create(customer.Endereco);
            endereco.Cidade = city;
            customer.Endereco = endereco;
            
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
