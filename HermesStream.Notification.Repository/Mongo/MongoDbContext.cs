using MongoDB.Driver;

namespace HermesStream.Notification.Repository.Mongo
{
    public class MongoDbContext : IDisposable
    {
        private readonly IMongoDatabase _database;

        public void Dispose() { }


        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }


        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
