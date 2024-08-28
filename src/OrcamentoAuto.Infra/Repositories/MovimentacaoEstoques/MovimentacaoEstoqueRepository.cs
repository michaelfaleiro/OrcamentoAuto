using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.MovimentacaoEstoque;
using OrcamentoAuto.Infra.Data;

namespace OrcamentoAuto.Infra.Repositories.MovimentacaoEstoques;
public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
{
    private readonly IMongoCollection<MovimentacaoEstoque> _collection;

    public MovimentacaoEstoqueRepository(IOptions<MongoDbSettings> settings)
    {
        var movimentacaoEstoque = new MongoClient(settings.Value.ConnectionUri);
        var database = movimentacaoEstoque.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<MovimentacaoEstoque>(settings.Value.CollectionsNames[nameof(MovimentacaoEstoque)]);
    }

    public async Task<IList<MovimentacaoEstoque>> GetMovimentacoesByProdutoId(string produtoId)
    {
        var filter = Builders<MovimentacaoEstoque>.Filter.Eq(x => x.ProdutoId, produtoId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task RegistrarMovimentacao(MovimentacaoEstoque entity)
    {
        var movimentacaoEstoque = new MovimentacaoEstoque(entity.ProdutoId,
            entity.Quantidade, entity.TipoMovimentacaoEstoque,
            entity.FornecedorId, entity.OrcamentoId);

        await _collection.InsertOneAsync(movimentacaoEstoque);
    }
}
