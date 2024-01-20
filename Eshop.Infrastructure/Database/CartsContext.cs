using Eshop.Domain.Carts;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Database
{
    internal class CartsContext
    {
        private readonly IMongoDatabase _database;        

        public CartsContext(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Cart> Carts => _database.GetCollection<Cart>(nameof(Carts));
    }
}