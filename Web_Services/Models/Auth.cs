using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_Services.Models
{
    public class Auth
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;
        public string? nic { get; set; } = null!;
        public string? email { get; set; } = null!;
        public string? username { get; set; } = null!;
        public string? password { get; set; } = null!;
        public string? type { get; set; } = null!;
        public string? createdAt { get; set; } = null!;
        public string? updatedAt { get; set; } = null!;
        public string? status { get; set; } = null!;
        public string? phone { get; set; } = null!;
        public string? address { get; set; } = null!;
    }
}
