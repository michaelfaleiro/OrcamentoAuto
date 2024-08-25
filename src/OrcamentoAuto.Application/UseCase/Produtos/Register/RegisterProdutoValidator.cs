using FluentValidation;
using OrcamentoAuto.Communication.Request.Produto;

namespace OrcamentoAuto.Application.UseCase.Produtos.Register;
public class RegisterProdutoValidator : AbstractValidator<RegisterProdutoRequest>
{
    public RegisterProdutoValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku é obrigatório");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descricao é obrigatório");

        RuleFor(x => x.Marca)
            .NotEmpty()
            .WithMessage("Marca é obrigatório");

        RuleFor(x => x.ValorCusto)
            .GreaterThan(0)
            .WithMessage("ValorCusto deve ser maior que 0");

        RuleFor(x => x.ValorVenda)
            .GreaterThan(x => x.ValorCusto)
            .WithMessage("ValorVenda deve ser maior que o ValorCusto");
    }
}
