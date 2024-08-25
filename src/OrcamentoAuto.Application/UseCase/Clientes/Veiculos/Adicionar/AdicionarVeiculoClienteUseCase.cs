using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Adicionar;
public class AdicionarVeiculoClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public AdicionarVeiculoClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Execute(AdicionarVeiculoClienteRequest request)
    {
        Validate(request);


        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);

        if (cliente == null)
            throw new NotFoundException("Cliente não encontrado");

        var veiculo = new Veiculo(
            request.Modelo, request.Marca, request.AnoModelo, request.AnoFabricao, request.Placa,
            request.Chassi, request.Cor, request.Combustivel, request.Renavam, request.Motor, request.Cambio);

        cliente.AdicionarVeiculo(veiculo);

        await _clienteRepository.UpdateAsync(cliente);

    }


    private void Validate(AdicionarVeiculoClienteRequest request)
    {
        var validator = new AdicionarVeiculoClienteValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);

    }
}
