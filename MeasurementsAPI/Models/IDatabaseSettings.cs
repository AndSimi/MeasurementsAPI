namespace MeasurementsAPI.Models
{
    public interface IDatabaseSettings
    {
        // The interface is used for dependency injection, in order to avoid tight coupling
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }



    }
}
