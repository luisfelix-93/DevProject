using MongoDB.Bson.Serialization.Attributes;

namespace DevProjectAPI.Infrastructure.Entities
{
    public class Product
    {
        #region Constructor

        public Product() { }

        #endregion

        #region Objects
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? IdProduct { get; set; }

        [BsonElement("product")] public string? ProductName { get; set; }

        [BsonElement("description")] public string? ProductDescription { get; set; }

        [BsonElement("price")] public string? ProductPrice { get; set; }

        [BsonElement("priceType")] public string? PriceType {  get; set; }

        [BsonElement("idUser")] public string? idUser { get; set; }

        #endregion
    }
}
