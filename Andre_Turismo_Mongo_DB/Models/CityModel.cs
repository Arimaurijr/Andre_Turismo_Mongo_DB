using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Andre_Turismo_Mongo_DB.Models
{
    public class CityModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Cadastro_cidade { get; set; }
    }
}
