using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Fornecedores;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Fornecedores;
public class FornecedorRepository : IFornecedorRepository
{
    private readonly IMongoCollection<Fornecedor> _collection;

    public FornecedorRepository(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionUri);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<Fornecedor>(settings.CollectionsNames[nameof(Fornecedor)]);
    }

    public async Task<Fornecedor> CreateAsync(Fornecedor entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Fornecedor>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<Fornecedor>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Fornecedor> GetByIdAsync(string id)
    {
        var filter = Builders<Fornecedor>.Filter.Eq(x => x.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, Fornecedor entity)
    {
        var filter = Builders<Fornecedor>.Filter.Eq(x => x.Id, id);
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
