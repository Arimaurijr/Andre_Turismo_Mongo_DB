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
            //var city = _cityService.Get(customer.Endereco.Cidade.Id);
            var address = _addressService.Get(customer.Endereco.Id);
            var customer_1 = _customerService.Get(customer.Id);

            if(address == null || customer_1 == null)
            {
                return NotFound();
            }
            else
            {
                _customerService.Update(customer.Id, customer);
                return Ok();

            }
            /*
            var city_1 = _cityService.Get(customer.Endereco.Cidade.Id);
            if(city_1 == null)
            {
                var city_2 = _cityService.Create(customer.Endereco.Cidade);
                customer.Endereco.Cidade = city_2;
            }
            else
            {
                _cityService.Update(customer.Endereco.Cidade.Id, customer.Endereco.Cidade);
            }



            var address_1 = _addressService.Get(customer.Endereco.Id);
            if(address_1 == null) 
            {
                var address_2 = _addressService.Create(customer.Endereco);
                customer.Endereco = address_2;
            }
            else
            {
                _addressService.Update(customer.Endereco.Id, customer.Endereco);
            }



            var customer1 = _customerService.Get(id);
            if(customer1 == null)
            {
                var customer2 = _customerService.Create(customer);
                
            }
            else
            {
                _customerService.Update(id, customer);
            }

            return Ok();
            ///////////////////////////////
            /*
            var c = _customerService.Get(id);
            if (c == null) return NotFound();

            _customerService.Update(id, customer);
            return Ok();
            */

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
