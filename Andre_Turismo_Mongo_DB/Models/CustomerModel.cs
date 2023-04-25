

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Andre_Turismo_Mongo_DB.Models
{
    public class CustomerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public AddressModel Endereco { get; set; }
        public DateTime Data_Cadastro_Cliente { get; set; }
    }
}
