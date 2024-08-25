using FluentValidation;
using OrcamentoAuto.Communication.Request.Orcamento;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.RemoverItem;
public class RemoverItemOrcamentoValidator : AbstractValidator<RemoverItemOrcamentoRequest>
{
    public RemoverItemOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId é obrigatório");
    }
}
