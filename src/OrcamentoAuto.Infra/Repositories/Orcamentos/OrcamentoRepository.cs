using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Orcamentos;
public class OrcamentoRepository : IOrcamentoRepository
{
    private readonly IMongoCollection<Orcamento> _collection;

    public OrcamentoRepository(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionUri);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<Orcamento>(settings.CollectionsNames[nameof(Orcamento)]);
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

    public async Task<IEnumerable<Orcamento>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Orcamento> GetByIdAsync(string id)
    {
        var filter = Builders<Orcamento>.Filter.Eq(x => x.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, Orcamento entity)
    {
        var filter = Builders<Orcamento>.Filter.Eq(x => x.Id, id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

}
