namespace MeasurementsAPI.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        //Database settings is used to get and set the database settings
        public string CollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
