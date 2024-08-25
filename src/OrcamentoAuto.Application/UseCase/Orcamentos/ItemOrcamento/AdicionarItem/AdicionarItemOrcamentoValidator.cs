using FluentValidation;
using OrcamentoAuto.Communication.Request.Orcamento;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.AdicionarItem;
public class AdicionarItemOrcamentoValidator : AbstractValidator<AdicionarItemOrcamentoRequest>
{
    public AdicionarItemOrcamentoValidator()
    {
        RuleFor(x => x.OrcamentoId)
            .NotEmpty()
            .WithMessage("OrcamentoId é obrigatório");

        RuleFor(x => x.ProdutoId)
            .NotEmpty()
            .WithMessage("ProdutoId é obrigatório");
                
    }
}
