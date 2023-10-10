using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DevProjectAPI.Infrastructure.Repositories
{
    public class ProductRepository
    {
        #region Constructor
        DbSettings _db;

        public ProductRepository(IOptions<DbSettings> db)
        {
            _db = db.Value;
        }
        #endregion

        #region Methods
        public IMongoCollection<Product> GetMongoCollection()
        {
            var mongoClient = new MongoClient(_db.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(_db.Database);
            var mongoCollection = mongoDataBase.GetCollection<Product>(_db.UserCollection);

            return mongoCollection;
        }

        public async Task<List<Product>> GetProductListByIdUser(string pIdUser) =>
            await this.GetMongoCollection().Find(x => x.idUser == pIdUser).ToListAsync();

        public async Task InsertProduct(Product pProduct) =>
            await this.GetMongoCollection().InsertOneAsync(pProduct);

        #endregion
    }
}
