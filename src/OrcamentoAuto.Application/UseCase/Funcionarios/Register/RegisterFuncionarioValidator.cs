using FluentValidation;
using OrcamentoAuto.Communication.Request.Funcionario;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.Register;
public class RegisterFuncionarioValidator : AbstractValidator<RegisterFuncionarioRequest>
{
    public RegisterFuncionarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email é obrigatório")
            .EmailAddress()
            .WithMessage("Email inválido");

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório");

        RuleFor(x => x.TipoFuncionario)
            .NotEmpty()
            .WithMessage("Tipo de funcionário é obrigatório");
    }
}
