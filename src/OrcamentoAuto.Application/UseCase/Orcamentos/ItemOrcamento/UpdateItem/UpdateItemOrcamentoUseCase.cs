using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.UpdateItem;
public class UpdateItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public UpdateItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task Execute(UpdateItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
            ?? throw new NotFoundException("Orçamento não encontrado");

        var item = orcamento.Itens.FirstOrDefault(x => x.Id == request.ItemId)
            ?? throw new NotFoundException("Item não encontrado");

        item.Atualizar(request.Quantidade, request.ValorVenda);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }

    private void Validate(UpdateItemOrcamentoRequest request)
    {
        var validator = new UpdateItemOrcamentoValidator();

        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}
