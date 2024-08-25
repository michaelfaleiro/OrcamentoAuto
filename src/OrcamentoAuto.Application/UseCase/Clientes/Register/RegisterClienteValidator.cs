using FluentValidation;
using OrcamentoAuto.Communication.Request.Cliente;

namespace OrcamentoAuto.Application.UseCase.Clientes.Register;
public class RegisterClienteValidator : AbstractValidator<RegisterClienteRequest>
{
    public RegisterClienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");
                

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Email inválido");
    }
}
