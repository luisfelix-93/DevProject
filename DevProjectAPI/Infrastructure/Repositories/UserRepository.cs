using DevProjectAPI.Infrastructure.Entities;
using DevProjectAPI.Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DevProjectAPI.Infrastructure.Repositories
{

    public class UserRepository
    {
        #region Constructor
        DbSettings _db;

        public UserRepository(IOptions<DbSettings> db) {
            _db = db.Value;
        }
        #endregion

        #region Methods
        public IMongoCollection<User> GetMongoCollection()
        {
            var mongoClient = new MongoClient(_db.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(_db.Database);
            var mongoCollection = mongoDataBase.GetCollection<User>(_db.UserCollection);

            return mongoCollection;
        }

        public async Task<List<User>> GetUserListAsync() => 
            await this.GetMongoCollection().Find(_ => true).ToListAsync();

        public async Task<User?> GetUserByIdAsync(string pIdUser) =>
            await this.GetMongoCollection().Find(x => x.IdUser == pIdUser).FirstOrDefaultAsync();

        public async Task CreateUser(User pUser) =>
            await this.GetMongoCollection().InsertOneAsync(pUser);

        #endregion
    }
}
