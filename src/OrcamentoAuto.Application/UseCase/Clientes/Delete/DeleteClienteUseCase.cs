using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.Delete;
public class DeleteClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Execute(string id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);

        if (cliente == null)
            throw new NotFoundException("Cliente não encontrado");

        await _clienteRepository.DeleteAsync(cliente.Id);
    }
}
