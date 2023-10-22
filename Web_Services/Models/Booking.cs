using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Services.Models
{
    public class Booking
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;
        public string? train { get; set; } = null!;
        public string? time { get; set; } = null!;
        public string? start { get; set; } = null!;
        public string? departure { get; set; } = null!;
        public string? refId { get; set; } = null!;
        public string? userId { get; set; } = null!;
        public string? username { get; set; } = null!;
        public string? email { get; set; } = null!;
        public string? phone { get; set; } = null!;
        public string? address { get; set; } = null!;
        public string? nic { get; set; } = null!;
        public string? createdAt { get; set; } = null!;
        public string? updatedAt { get; set; } = null!;
        public string? status { get; set; } = null!;
        public string? assignee { get; set; } = null!;

    }
}
