using MongoDB.Bson.Serialization.Attributes;

namespace DevProjectAPI.Infrastructure.Entities
{
    public class User
    {
        #region Constructor
        public User() { }
        #endregion
        #region Objects
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
        public string? IdUser { get; set; }

        [BsonElement("user")]
        public string? UserName { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }
        #endregion
    }
}
