using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.AdicionarItem;
public class AdicionarItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IProdutoRepository _produtoRepository;


    public AdicionarItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository,
        IProdutoRepository produtoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task Execute(AdicionarItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
            ?? throw new NotFoundException("Orçamento não encontrado");

        var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId)
            ?? throw new NotFoundException("Produto não encontrado");

        if (orcamento.Itens.Any(x => x.ProdutoId == request.ProdutoId))
            throw new BusinnesException("Item já adicionado ao orçamento");

        var itemOrcamento = new Core.Entities.ItemOrcamento(produto.Id, produto.Sku, request.Quantidade, produto.Descricao, request.ValorVenda);

        orcamento.AdicionarItem(itemOrcamento);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }

    private void Validate(AdicionarItemOrcamentoRequest request)
    {
        var validator = new AdicionarItemOrcamentoValidator();

        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}
