using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 

namespace MeasurementsAPI.Models
{
    public class Measurements
    {
        //Measurements Model is used to create a model for posting the datalogger information to the database
        //BsonId is used in order to auto generate the id in MongoDB
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string Moisture { get; set; }

        public string PlantName { get; set; }




    }
}
