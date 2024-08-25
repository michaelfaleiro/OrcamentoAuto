using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Fornecedores;
using OrcamentoAuto.Core.Response;
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

    public async Task<PagedResponse<Fornecedor>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _collection.CountDocumentsAsync(_ => true);

        var fornecedores = await _collection.Find(p => true)
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();

        return new PagedResponse<Fornecedor>
        {
            Data = fornecedores,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Fornecedor> GetByIdAsync(string id)
    {
        var filter = Builders<Fornecedor>.Filter.Eq(x => x.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Fornecedor entity)
    {
        var filter = Builders<Fornecedor>.Filter.Eq(x => x.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
