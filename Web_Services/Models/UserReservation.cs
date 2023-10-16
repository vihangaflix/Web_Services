using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Services.Models
{

    public enum UserTypeEnum
    {
        Resolve,
        MarkAsFiled
    }


    public class UserReservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("UserId")]
        public string UserId { get; set; } = String.Empty;

        [BsonElement("UserName")]
        public string UserName { get; set; } = String.Empty;

        [BsonElement("UserEmail")]
        public string UserEmail { get; set; } = String.Empty;

        [BsonElement("UserPhone")]
        public string UserPhone { get; set; } = String.Empty;

        [BsonElement("TrainId")]
        public string TrainId { get; set; } = String.Empty;

        [BsonElement("TrainName")]
        public string TrainName { get; set; } = String.Empty;

        [BsonElement("TrainTime")]
        public string TrainTime { get; set; } = String.Empty;

        [BsonElement("TrainStartLocation")]
        public string TrainStartLocation { get; set; } = String.Empty;

        [BsonElement("TrainDepartureLocation")]
        public string TrainDepartureLocation { get; set; } = String.Empty;

        [BsonElement("TravelAgentId")]
        public string TravelAgentId { get; set; } = String.Empty;

        [BsonElement("TravelAgentName")]
        public string TravelAgentName { get; set; } = String.Empty;

        [BsonElement("type")]
        public UserTypeEnum Type { get; set; } = UserTypeEnum.Resolve;

    }
}
