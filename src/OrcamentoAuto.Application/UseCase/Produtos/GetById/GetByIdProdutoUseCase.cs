using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Produto;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Produtos.GetById;
public class GetByIdProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;

    public GetByIdProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Response<ResponseProdutoJson>> Execute(string id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);

        if (produto == null)
            throw new NotFoundException("Produto não encontrado");

        return new Response<ResponseProdutoJson>
        {
            Data = new ResponseProdutoJson
            {
                Id = produto.Id,
                Sku = produto.Sku,
                Descricao = produto.Descricao,
                Marca = produto.Marca,
                ValorCusto = produto.ValorCusto,
                ValorVenda = produto.ValorVenda,
                EstoqueAtual = produto.EstoqueAtual,
                Ativo = produto.Ativo,
                CreatedAt = produto.CreatedAt,
                UpdatedAt = produto.UpdatedAt
            }
        };
    }
}
