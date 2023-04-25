namespace Andre_Turismo_Mongo_DB.Config
{
    public interface IProjMDSettings
    {
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }

        string CityCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
