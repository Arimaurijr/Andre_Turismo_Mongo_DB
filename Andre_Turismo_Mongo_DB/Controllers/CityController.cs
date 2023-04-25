using Andre_Turismo_Mongo_DB.Models;
using Andre_Turismo_Mongo_DB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andre_Turismo_Mongo_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService) 
        {
            _cityService = cityService;
        }
        [HttpGet]
        public ActionResult<List<CityModel>> Get() => _cityService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCity")]
        public ActionResult<CityModel> Get(string id)
        {
            var customer = _cityService.Get(id);
            if (customer == null) return NotFound();

            return _cityService.Get(id);
        }
        [HttpPost]
        public ActionResult<CityModel> Create(CityModel city)
        {
            return _cityService.Create(city);
            
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, CityModel city)
        {
            var c = _cityService.Get(id);
            if (c == null) return NotFound();

            _cityService.Update(id, city);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            var city = _cityService.Get(id);
            if (city == null) return NotFound();

            _cityService.Delete(id);
            return Ok();
        }

    }
}
