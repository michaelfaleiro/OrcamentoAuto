using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.GetById;
public class GetByIdClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetByIdClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Response<ResponseClienteJson>> Execute(string id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);

        if (cliente == null)
            throw new NotFoundException("Cliente não encontrado");

        var result = new Response<ResponseClienteJson>
        {
            Data = new ResponseClienteJson
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                CpfCnpj = cliente.CpfCnpj,
                RgIe = cliente.RgIe,
                Email = cliente.Email,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt ?? null
            }
        };

        return result;
    }
}
