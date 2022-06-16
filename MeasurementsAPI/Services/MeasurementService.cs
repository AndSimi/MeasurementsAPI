using MeasurementsAPI.Models;
using MongoDB.Driver;

namespace MeasurementsAPI.Services
{
    public class MeasurementService : IMeasurementServices
    {
        private readonly IMongoCollection<Measurements> _measurements;
        //Measurement Service is used to create a new connection to the MongoDB connection, by using parameters specified in appsettings.json
        public MeasurementService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _measurements = database.GetCollection<Measurements>(settings.CollectionName);
        }

        //Create method is used to insert a new object into the database 
        public void create(Measurements measurement)
        {
            _measurements.InsertOne(measurement);
        }
        //Delete method is used to find an object with matching id and delete it, otherwise return null
        public void delete(string id)
        {
            _measurements.DeleteOne(measurements => measurements.Id == id);
        }
        //get by id method is used to find an object with matching id and return it, otherwise return null
        public Measurements get(string id)
        {
            return _measurements.Find(measurements => measurements.Id == id).FirstOrDefault();
        }
        //getAll method is used to fetch all of the records from database
        public List<Measurements> GetAll()
        {
            return _measurements.Find(measurements => true).ToList();
        }
        //getCertificate method is used to fetch all of the records from database for a specific plant and return it as a list
        public List<Measurements> GetCertificate(string plantName)
        {
            return  _measurements.Find(measurements => measurements.PlantName == plantName).ToList();
        }
        //Update method is used to find an object with matching id, and replace it with the supplied object
        public void update(Measurements measurement, string id)
        {
            _measurements.ReplaceOne(measurements => measurements.Id == id, measurement);
        }
    }
}
