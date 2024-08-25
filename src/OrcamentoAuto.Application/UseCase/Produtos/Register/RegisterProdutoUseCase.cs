using OrcamentoAuto.Communication.Request.Produto;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Produto;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Produtos.Register;
public class RegisterProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;

    public RegisterProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Response<ResponseProdutoJson>> Execute(RegisterProdutoRequest request)
    {
        Validate(request);

        var produto = new Produto(request.Sku, request.Descricao, request.Marca, request.ValorCusto, request.ValorVenda);

        await _produtoRepository.CreateAsync(produto);

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

    private void Validate(RegisterProdutoRequest request)
    {
        var validator = new RegisterProdutoValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }


}
