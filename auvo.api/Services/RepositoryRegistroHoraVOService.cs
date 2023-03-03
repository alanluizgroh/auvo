using auvo.api.Config;
using auvo.api.Data.ValueObjects;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace auvo.api.Services
{
    public class RepositoryRegistroHoraVOService
    {
        private readonly IMongoCollection<RegistroHoraVO> _collection;

        public RepositoryRegistroHoraVOService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<RegistroHoraVO>("RegistroHora");
        }

        public async Task CreateAsync(RegistroHoraVO newBook) =>
    await _collection.InsertOneAsync(newBook);

        public async Task<List<RegistroHoraVO>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        //public async Task<RegistroHoraVO> GetAsync(long repositoryId) =>
        //    await _collection.Find(x => x.RepositoryId == repositoryId).FirstAsync();
    }
}
