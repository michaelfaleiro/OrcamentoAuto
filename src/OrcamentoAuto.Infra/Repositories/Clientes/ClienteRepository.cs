using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Core.Response;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Clientes;
public class ClienteRepository : IClienteRepository
{
    private readonly IMongoCollection<Cliente> _collection;

    public ClienteRepository(IOptions<MongoDbSettings> settings)
    {
        var cliente = new MongoClient(settings.Value.ConnectionUri);
        var database = cliente.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Cliente>(settings.Value.CollectionsNames[nameof(Cliente)]);
    }



    public async Task<Cliente> CreateAsync(Cliente entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<PagedResponse<Cliente>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _collection.CountDocumentsAsync(_ => true);

        var clientes = await _collection.Find(p => true)
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();

        return new PagedResponse<Cliente>
        {
            Data = clientes,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Cliente> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Cliente entity)
    {
        var filter = Builders<Cliente>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Cliente>.Filter.Eq(x => x.Id, id);
        var delete = await _collection.DeleteOneAsync(filter);
    }
        
}
