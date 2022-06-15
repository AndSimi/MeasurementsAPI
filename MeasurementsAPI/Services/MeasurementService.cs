using MeasurementsAPI.Models;
using MongoDB.Driver;

namespace MeasurementsAPI.Services
{
    public class MeasurementService : IMeasurementServices
    {
        private readonly IMongoCollection<Measurements> _measurements;

        public MeasurementService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _measurements = database.GetCollection<Measurements>(settings.CollectionName);
        }

        public void create(Measurements measurement)
        {
            _measurements.InsertOne(measurement);
        }

        public Measurements get(string id)
        {
            return _measurements.Find(measurements => measurements.Id == id).FirstOrDefault();
        }

        public List<Measurements> GetAll()
        {
            return _measurements.Find(measurements => true).ToList();
        }

        public List<Measurements> GetCertificate(string plantName)
        {
            return  _measurements.Find(measurements => measurements.PlantName == plantName).ToList();
        }
    }
}
