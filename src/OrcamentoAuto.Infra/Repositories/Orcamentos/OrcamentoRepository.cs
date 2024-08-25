using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Core.Response;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Orcamentos;
public class OrcamentoRepository : IOrcamentoRepository
{
    private readonly IMongoCollection<Orcamento> _collection;

    public OrcamentoRepository(IOptions<MongoDbSettings> settings)
    {
        var orcamento = new MongoClient(settings.Value.ConnectionUri);
        var database = orcamento.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Orcamento>(settings.Value.CollectionsNames[nameof(Orcamento)]);
    }

    public async Task<Orcamento> CreateAsync(Orcamento entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Orcamento>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<PagedResponse<Orcamento>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _collection.CountDocumentsAsync(_ => true);

        var orcamentos = await _collection.Find(p => true)
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();

        return new PagedResponse<Orcamento>
        {
            Data = orcamentos,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Orcamento> GetByIdAsync(string id)
    {
        var filter = Builders<Orcamento>.Filter.Eq(x => x.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
       

    public async Task UpdateAsync(Orcamento entity)
    {
        var filter = Builders<Orcamento>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

}
