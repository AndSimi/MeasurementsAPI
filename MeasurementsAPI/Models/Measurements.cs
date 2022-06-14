using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 

namespace MeasurementsAPI.Models
{
    public class Measurements
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string Moisture { get; set; }

        public string PlantName { get; set; }




    }
}
