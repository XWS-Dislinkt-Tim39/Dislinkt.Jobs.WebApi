using MongoDB.Driver;

namespace Dislinkt.Jobs.Persistance.MongoDB.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Create();
    }
}
