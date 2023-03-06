using AutoMapper;
using auvo.api.Config;
using auvo.api.Data.ValueObjects;
using auvo.domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace auvo.api.Services
{
    public class RepositoryPayrollService
    {
        private readonly IMongoCollection<DepartamentoVO> _collection;
        private IMapper _mapper;

        public RepositoryPayrollService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings, IMapper mapper)
        {
            _mapper = mapper;

            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<DepartamentoVO>("Pagamento");
        }


        public async Task CreateAsync(Departamento record)
        {
            var recordVO = _mapper.Map<DepartamentoVO>(record);
            await _collection.InsertOneAsync(recordVO);
        }


        public async Task<List<Departamento>> GetAsync()
        {

            var departmentVOList = await _collection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<Departamento>>(departmentVOList);


        }


    }
}
