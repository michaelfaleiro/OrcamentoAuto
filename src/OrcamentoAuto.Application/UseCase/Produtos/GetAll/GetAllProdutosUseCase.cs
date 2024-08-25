using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Produto;
using OrcamentoAuto.Core.Repositories.Produtos;

namespace OrcamentoAuto.Application.UseCase.Produtos.GetAll;
public class GetAllProdutosUseCase
{
    private readonly IProdutoRepository _produtoRepository;

    public GetAllProdutosUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<PagedResponse<ResponseProdutoJson>> Execute(int pageNumber, int PageSize)
    {
        var produtos = await _produtoRepository.GetAllAsync(pageNumber, PageSize);

        var result = produtos.Data.Select(produto => new ResponseProdutoJson
        {
            Id = produto.Id,
            Sku = produto.Sku,
            Descricao = produto.Descricao,
            Marca = produto.Marca,
            ValorCusto = produto.ValorCusto,
            ValorVenda = produto.ValorVenda,
            QuantidadeEstoque = produto.QuantidadeEstoque,
            Ativo = produto.Ativo,
            CreatedAt = produto.CreatedAt,
            UpdatedAt = produto.UpdatedAt
        });

        return new PagedResponse<ResponseProdutoJson>
        {
            Data = result,
            PageNumber = produtos.PageNumber,
            PageSize = produtos.PageSize,
            TotalCount = produtos.TotalPages
        };

    }
}
