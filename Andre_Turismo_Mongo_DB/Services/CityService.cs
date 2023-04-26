using Andre_Turismo_Mongo_DB.Config;
using Andre_Turismo_Mongo_DB.Models;
using MongoDB.Driver;

namespace Andre_Turismo_Mongo_DB.Services
{
    public class CityService
    {
        private readonly IMongoCollection<CityModel> _city;

        public CityService(IProjMDSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<CityModel>(settings.CityCollectionName);
        }
        public List<CityModel> Get()
        {
            return _city.Find(c=>true).ToList();
        }
        public CityModel Get(string id)
        {
            return _city.Find(c => c.Id == id).FirstOrDefault(); 
        }
        public CityModel Create(CityModel city)
        {
            _city.InsertOne(city);
            return city;
        }
        public void Update(string id, CityModel city)
        {
            _city.ReplaceOne(c => c.Id == id, city);
        }
        public void Delete(CityModel city)
        {
            _city.DeleteOne(c => c.Id == city.Id);
        }
        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);
    }
}
