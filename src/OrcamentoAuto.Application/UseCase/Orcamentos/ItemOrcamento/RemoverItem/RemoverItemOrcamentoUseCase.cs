using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.RemoverItem;
public class RemoverItemOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public RemoverItemOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task Execute(RemoverItemOrcamentoRequest request)
    {
        Validate(request);

        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
            ?? throw new NotFoundException("Orçamento não encontrado");

        var item = orcamento.Itens.FirstOrDefault(x => x.Id == request.ItemId)
            ?? throw new NotFoundException("Item não encontrado");

        orcamento.RemoverItem(item);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }

    private void Validate(RemoverItemOrcamentoRequest request)
    {
        var validator = new RemoverItemOrcamentoValidator();

        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}
