using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Update;
public class UpdateVeiculoUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateVeiculoUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Execute(UpdateVeiculoClienteRequest request)
    {
        Validate(request);

        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
            ?? throw new NotFoundException("Cliente não encontrado");

        var veiculo = cliente.Veiculos.FirstOrDefault(v => v.Id == request.VeiculoId)
            ?? throw new NotFoundException("Veículo não encontrado");

        veiculo.Atualizar(request.Modelo, request.Marca, request.AnoModelo, request.AnoFabricao, request.Placa,
            request.Chassi, request.Cor, request.Combustivel, request.Renavam, request.Motor, request.Cambio);

        await _clienteRepository.UpdateAsync(cliente);
    }

    private void Validate(UpdateVeiculoClienteRequest request)
    {
        var validator = new UpdateVeiculoValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}
