using Andre_Turismo_Mongo_DB.Config;
using Andre_Turismo_Mongo_DB.Models;
using Andre_Turismo_Mongo_DB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Andre_Turismo_Mongo_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;
        public AddressController(AddressService addressService, CityService cityService) 
        {
            _addressService = addressService; 
            _cityService = cityService;
        }
        [HttpGet]
        public ActionResult<List<AddressModel>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<AddressModel> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();

            return _addressService.Get(id);
        }
        [HttpPost]
        public ActionResult<AddressModel> Create(AddressModel address)
        {

            //address.Cidade =  _cityService.Create(city);
            //return _addressService.Create(address);

            CityModel cidade = _cityService.Create(address.Cidade);
            address.Cidade = cidade;
            return _addressService.Create(address);
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, AddressModel address)
        {
            var c = _cityService.Get(id);
            if (c == null)
            {
                var city = _cityService.Create(address.Cidade);
                address.Cidade = city;
            }

            var a = _addressService.Get(id);
            if (a == null) return NotFound();

            _addressService.Update(id, address);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            var address = _addressService.Get(id);
            if (address == null) return NotFound();

            _addressService.Delete(id);
            return Ok();
        }
    }
}
