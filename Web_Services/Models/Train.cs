using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Services.Models
{
    public enum TypeEnum
    {
        Cancel,
        Active,
        ActiveAndPublished
    }
    public class Train
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("TrainName")]
        public string TrainName { get; set; } = String.Empty;

        [BsonElement("Time")]
        public string Time { get; set; } = String.Empty;

        [BsonElement("StartLocation")]
        public string StartLocation { get; set; } = String.Empty;

        [BsonElement("DepartureLocation")]
        public string DepartureLocation { get; set; } = String.Empty;

        [BsonElement("CreatedTime")]
        public string CreatedTime { get; set; } = String.Empty;

        [BsonElement("LastUpdatedTime")]
        public string LastUpdatedTime { get; set; } = String.Empty;

        [BsonElement("Status")]
        public TypeEnum Status { get; set; } = TypeEnum.Cancel;
    }
}
