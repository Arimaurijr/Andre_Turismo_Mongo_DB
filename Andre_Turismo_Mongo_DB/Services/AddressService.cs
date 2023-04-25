using Andre_Turismo_Mongo_DB.Config;
using Andre_Turismo_Mongo_DB.Models;
using MongoDB.Driver;

namespace Andre_Turismo_Mongo_DB.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<AddressModel> _address;

        public AddressService(IProjMDSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<AddressModel>(settings.AddressCollectionName);
        }
        public List<AddressModel> Get()
        {
            return _address.Find(a => true).ToList();
        }
        public AddressModel Get(string id)
        {
            return _address.Find(a => a.Id == id).FirstOrDefault();
        }
        public AddressModel Create(AddressModel address) 
        {
            _address.InsertOne(address);
            return address;
        }
        public void Update(string id, AddressModel address) 
        {
            _address.ReplaceOne(a => address.Id == a.Id, address);
        }
        public void Delete(AddressModel address)
        {
            _address.DeleteOne(a => a.Id == address.Id);
        }
        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);

    }
}
