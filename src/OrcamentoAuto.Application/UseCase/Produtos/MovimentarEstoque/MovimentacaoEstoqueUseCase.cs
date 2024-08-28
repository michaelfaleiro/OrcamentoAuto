using OrcamentoAuto.Communication.Enums;
using OrcamentoAuto.Communication.Request.Produto;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.MovimentacaoEstoque;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Produtos.MovimentarEstoque;
public class MovimentacaoEstoqueUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;

    public MovimentacaoEstoqueUseCase(IProdutoRepository produtoRepository, IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository)
    {
        _produtoRepository = produtoRepository;
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
    }

    public async Task Execute(MovimentarEstoqueRequest request)
    {
        var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

        if (produto == null)
            throw new NotFoundException("Produto não encontrado");

        if (request.TipoMovimentacaoEstoque == ETipoMovimentacaoEstoque.Entrada)
            produto.AdicionarEstoque(request.Quantidade);
        else if (request.TipoMovimentacaoEstoque == ETipoMovimentacaoEstoque.Saida)
            produto.RemoverEstoque(request.Quantidade);
        else
            throw new BusinnesException("Tipo de movimentação de estoque inválido");

        await _produtoRepository.UpdateAsync(produto);

        var movimentacaoEstoque = new MovimentacaoEstoque(request.ProdutoId,
            request.Quantidade, (Core.Enums.ETipoMovimentacaoEstoque)request.TipoMovimentacaoEstoque,
            request.FornecedorId, request.OrcamentoId);

        await _movimentacaoEstoqueRepository.RegistrarMovimentacao(movimentacaoEstoque);

    }
}
