namespace Andre_Turismo_Mongo_DB.Config
{
    public class ProjMDSettings : IProjMDSettings
    {
        public string CustomerCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
