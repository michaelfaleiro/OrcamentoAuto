using FluentValidation;
using OrcamentoAuto.Communication.Request.Cliente;

namespace OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Remover;
public class RemoverVeiculoValidator : AbstractValidator<RemoverVeiculoRequest>
{
    public RemoverVeiculoValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEmpty()
            .WithMessage("ClienteId é obrigatório");

        RuleFor(x => x.VeiculoId)
            .NotEmpty()
            .WithMessage("VeiculoId é obrigatório");
    }
}
