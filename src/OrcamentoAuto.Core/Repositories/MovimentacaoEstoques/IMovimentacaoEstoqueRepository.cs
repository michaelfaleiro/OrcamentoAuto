using OrcamentoAuto.Core.Enums;

namespace OrcamentoAuto.Core.Repositories.MovimentacaoEstoque;
public interface IMovimentacaoEstoqueRepository

{
    Task RegistrarMovimentacao(Entities.MovimentacaoEstoque movimentacaoEstoque);
    Task<IList<Entities.MovimentacaoEstoque>> GetMovimentacoesByProdutoId(string produtoId);
}
