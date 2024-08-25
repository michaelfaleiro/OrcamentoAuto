using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Remover;
public class RemoverVeiculoUseCase
{

    private readonly IClienteRepository _clienteRepository;

    public RemoverVeiculoUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public async Task Execute(RemoverVeiculoRequest request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
            ?? throw new NotFoundException("Cliente não encontrado");

        var veiculo = cliente.Veiculos.FirstOrDefault(v => v.Id == request.VeiculoId)
            ?? throw new NotFoundException("Veículo não encontrado");

        cliente.RemoverVeiculo(veiculo);

        await _clienteRepository.UpdateAsync(cliente);
    }

    private void Validate(RemoverVeiculoRequest request)
    {
        var validator = new RemoverVeiculoValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        throw new ErrorOnValidateException(errors);
    }
}
