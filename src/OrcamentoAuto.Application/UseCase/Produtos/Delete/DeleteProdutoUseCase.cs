using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Produtos.Delete;
public class DeleteProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;

    public DeleteProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Execute(string id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Produto não encontrado");
        
        await _produtoRepository.DeleteAsync(produto.Id);
    }
}
