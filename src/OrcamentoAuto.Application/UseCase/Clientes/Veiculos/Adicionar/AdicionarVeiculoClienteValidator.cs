﻿using FluentValidation;
using OrcamentoAuto.Communication.Request.Cliente;

namespace OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Adicionar;
public class AdicionarVeiculoClienteValidator : AbstractValidator<AdicionarVeiculoClienteRequest>
{
    public AdicionarVeiculoClienteValidator()
    {
        RuleFor(x => x.Modelo).NotEmpty().WithMessage("Modelo é obrigatório");
        RuleFor(x => x.Marca).NotEmpty().WithMessage("Marca é obrigatório");
        RuleFor(x => x.Placa)
            .MinimumLength(7)
            .MaximumLength(7)
            .When(x => !string.IsNullOrEmpty(x.Placa))
            .WithMessage("Placa deve ter no mínimo 7 caracteres");

        RuleFor(x => x.Chassi)
            .MinimumLength(17)
            .MaximumLength(17)
            .When(x => !string.IsNullOrEmpty(x.Chassi))
            .WithMessage("Chassi é obrigatório");

    }
}
