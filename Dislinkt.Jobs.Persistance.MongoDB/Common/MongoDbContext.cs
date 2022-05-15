using Dislinkt.Jobs.Persistance.MongoDB.Attributes;
using Dislinkt.Jobs.Persistance.MongoDB.Entities;
using Dislinkt.Jobs.Persistance.MongoDB.Factories;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Persistance.MongoDB.Common
{
    public class MongoDbContext
    {
        private readonly IDatabaseFactory _databaseFactory;
        public MongoDbContext(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
        public IMongoCollection<T> GetCollection<T>() where T : BaseEntity
        {
            var collectionDefinition = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionNameAttribute))
                as CollectionNameAttribute;

            return GetCollection<T>(collectionDefinition.Name);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
         => _databaseFactory.Create().GetCollection<T>(collectionName);
        public async Task CreateCollection<T>() where T : BaseEntity
        {
            var collectionDefinition = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionNameAttribute))
                as CollectionNameAttribute;

            var db = _databaseFactory.Create();
            var collections = (await db.ListCollectionNamesAsync()).ToList();

            if (collections.Any(c => c == collectionDefinition.Name))
            {
                return;
            }

            await _databaseFactory.Create().CreateCollectionAsync(collectionDefinition.Name);
        }
    }
}
