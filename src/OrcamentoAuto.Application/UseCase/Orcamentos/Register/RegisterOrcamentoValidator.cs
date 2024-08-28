using FluentValidation;
using OrcamentoAuto.Communication.Request.Orcamento;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.Register;
public class RegisterOrcamentoValidator : AbstractValidator<RegisterOrcamentoRequest>
{
    public RegisterOrcamentoValidator()
    {
        RuleFor(x => x.ClienteId).NotEmpty().WithMessage("ClienteId é obrigatório");
        RuleFor(x => x.VeiculoId).NotEmpty().WithMessage("VeiculoId é obrigatório");
        RuleFor(x => x.Status).NotEmpty().WithMessage("Status é obrigatório");
        RuleFor(x => x.VendedorId).NotEmpty().WithMessage("VendedorId é obrigatório");
    }
}
