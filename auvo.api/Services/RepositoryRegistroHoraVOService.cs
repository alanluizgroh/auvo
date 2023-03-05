using AutoMapper;
using auvo.api.Config;
using auvo.api.Data.ValueObjects;
using auvo.domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace auvo.api.Services
{
    public class RepositoryRegistroHoraVOService
    {
        private readonly IMongoCollection<PayrollVO> _collection;
        private IMapper _mapper;

        public RepositoryRegistroHoraVOService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings, IMapper mapper)
        {
            _mapper = mapper;

            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<PayrollVO>("Payroll");
        }


        public async Task CreateAsync(Payroll registro) {
            var registroVO = _mapper.Map<PayrollVO>(registro);
            await _collection.InsertOneAsync(registroVO);
        }
   

        public async Task<List<PayrollVO>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

       
    }
}
