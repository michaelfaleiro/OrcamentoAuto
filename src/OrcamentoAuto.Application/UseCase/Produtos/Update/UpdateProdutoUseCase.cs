using OrcamentoAuto.Communication.Request.Produto;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Produto;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Produtos.Update;
public class UpdateProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;

    public UpdateProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Response<ResponseProdutoJson>> Execute(string id, UpdateProdutoRequest request)
    {
        Validate(request);

        var produto = await _produtoRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Produto não encontrado");

        produto.Atualizar(request.Sku, request.Descricao, request.Marca, request.ValorCusto, request.ValorVenda);

        await _produtoRepository.UpdateAsync(produto);

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
                QuantidadeEstoque = produto.QuantidadeEstoque,
                Ativo = produto.Ativo,
                CreatedAt = produto.CreatedAt,
                UpdatedAt = produto.UpdatedAt
            }
        };

    }

    private void Validate(UpdateProdutoRequest request)
    {
        var validator = new UpdateProdutoValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
