using AutoMapper;
using auvo.api.Config;
using auvo.api.Data.ValueObjects;
using auvo.model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace auvo.api.Services
{
    public class RepositoryRegistroHoraVOService
    {
        private readonly IMongoCollection<RegistroHoraVO> _collection;
        private IMapper _mapper;

        public RepositoryRegistroHoraVOService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings, IMapper mapper)
        {
            _mapper = mapper;

            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<RegistroHoraVO>("RegistroHora");
        }


        public async Task CreateAsync(Payroll registro) {
            var registroVO = _mapper.Map<RegistroHoraVO>(registro);
            await _collection.InsertOneAsync(registroVO);
        }
   

        public async Task<List<RegistroHoraVO>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        //public async Task<RegistroHoraVO> GetAsync(long repositoryId) =>
        //    await _collection.Find(x => x.RepositoryId == repositoryId).FirstAsync();
    }
}
