using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Veiculos;
using OrcamentoAuto.Core.Response;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Veiculos;
public class VeiculoRepository : IVeiculoRepository
{

    private readonly IMongoCollection<Veiculo> _collection;

    public VeiculoRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionUri);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Veiculo>(settings.Value.CollectionsNames[nameof(Veiculo)]);
    }


    public async Task<Veiculo> CreateAsync(Veiculo entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Veiculo>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<PagedResponse<Veiculo>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _collection.CountDocumentsAsync(_ => true);

        var veiculos = await _collection.Find(p => true)
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();

        return new PagedResponse<Veiculo>
        {
            Data = veiculos,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Veiculo> GetByIdAsync(string id)
    {
        var filter = Builders<Veiculo>.Filter.Eq(x => x.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Veiculo entity)
    {
        var filter = Builders<Veiculo>.Filter.Eq(x => x.Id, entity.Id);

        await _collection.ReplaceOneAsync(filter, entity);
    }
}
