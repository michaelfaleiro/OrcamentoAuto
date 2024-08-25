using OrcamentoAuto.Core.Entities;

namespace OrcamentoAuto.Core.Repositories.Produtos;
public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<Produto> GetBySkuOrDescricaoAsync(string query);
}
