using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Clientes;
public class ClienteRepository : IClienteRepository
{
    private readonly IMongoCollection<Cliente> _collection;

    public ClienteRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionUri);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Cliente>(settings.Value.CollectionsNames[nameof(Cliente)]);
    }

    public async Task<Cliente> CreateAsync(Cliente entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Cliente>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        var clientes = await _collection.Find(_ => true).ToListAsync();
        return clientes;
    }

    public async Task<Cliente> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, Cliente entity)
    {
        var filter = Builders<Cliente>.Filter.Eq(x => x.Id, id);
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
