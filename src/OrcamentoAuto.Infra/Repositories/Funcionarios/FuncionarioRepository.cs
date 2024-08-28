using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Core.Response;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.Funcionarios;
public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly IMongoCollection<Funcionario> _collection;

    public FuncionarioRepository(IOptions<MongoDbSettings> settings)
    {
        var funcionario = new MongoClient(settings.Value.ConnectionUri);
        var database = funcionario.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<Funcionario>(settings.Value.CollectionsNames[nameof(Funcionario)]);
    }

    public async Task<Funcionario> CreateAsync(Funcionario entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public Task DeleteAsync(string id)
    {
        var filter = Builders<Funcionario>.Filter.Eq(x => x.Id, id);
        return _collection.DeleteOneAsync(filter);
    }

    public async Task<PagedResponse<Funcionario>> GetAllAsync(int pageNumber, int pageSize)
    {
       var count = await _collection.CountDocumentsAsync(_ => true);

        var funcionarios = await _collection.Find(p => true)
        .Skip((pageNumber - 1) * pageSize)
        .Limit(pageSize)
        .ToListAsync();

        return new PagedResponse<Funcionario>
        {
            Data = funcionarios,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = (int)count
        };
    }

    public async Task<Funcionario> GetByIdAsync(string id)
    {
        var filter = Builders<Funcionario>.Filter.Eq(x => x.Id, id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Funcionario entity)
    {
        var filter = Builders<Funcionario>.Filter.Eq(x => x.Id, entity.Id); 
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
