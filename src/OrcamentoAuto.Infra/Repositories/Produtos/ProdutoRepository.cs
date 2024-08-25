using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Core.Response;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Produtos;
public class ProdutoRepository : IProdutoRepository
{
    private readonly IMongoCollection<Produto> _collection;

    public ProdutoRepository(IOptions<MongoDbSettings> settings)
    {
        var produto = new MongoClient(settings.Value.ConnectionUri);
        var database = produto.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Produto>(settings.Value.CollectionsNames[nameof(Produto)]);
    }

    public async Task<Produto> CreateAsync(Produto entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Produto>.Filter.Eq(x => x.Id, id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<PagedResponse<Produto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _collection.CountDocumentsAsync(_ => true);
        
        return new PagedResponse<Produto>()
        {
            Data = await _collection.Find(p => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(),
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Produto> GetByIdAsync(string id)
    {
        var filter = Builders<Produto>.Filter.Eq(x => x.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Produto> GetBySkuOrDescricaoAsync(string query)
    {
        var filter = Builders<Produto>.Filter.Or(
            Builders<Produto>.Filter.Eq(x => x.Sku, query),
            Builders<Produto>.Filter.Eq(x => x.Descricao, query)
        );
                   
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Produto entity)
    {
        var filter = Builders<Produto>.Filter.Eq(x => x.Id, entity.Id);

        await _collection.ReplaceOneAsync(filter, entity);
    }
}
