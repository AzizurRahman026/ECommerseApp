using Core.Entities;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionUri, string databaseName)
        {
            var client = new MongoClient(connectionUri);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<Product> product => _database.GetCollection<Product>("product");
    }
}
