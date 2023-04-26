using Andre_Turismo_Mongo_DB.Config;
using Andre_Turismo_Mongo_DB.Models;
using MongoDB.Driver;

namespace Andre_Turismo_Mongo_DB.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<CustomerModel> _customer;

        public CustomerService(IProjMDSettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<CustomerModel>(settings.CustomerCollectionName);
        }
        public List<CustomerModel> Get()
        {
            return _customer.Find(c => true).ToList();
        }
        public CustomerModel Get(string id)
        {
            return _customer.Find(c => c.Id == id).FirstOrDefault();
        }
        public CustomerModel Create(CustomerModel customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }
        public void Update(string id,CustomerModel customer)
        {
            _customer.ReplaceOne(c => customer.Id == c.Id, customer);
        }
        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);
    }
}
