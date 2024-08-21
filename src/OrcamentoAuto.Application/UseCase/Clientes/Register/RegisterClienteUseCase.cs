using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Clientes;

namespace OrcamentoAuto.Application.UseCase.Clientes.Register;

public class RegisterClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public RegisterClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Response<ResponseClienteJson>> Execute(RegisterClienteRequest request)
    {
        var entity = new Cliente(request.Nome, request.Telefone, request.CpfCnpj, request.RgIe, request.Email);

        var cliente = await _clienteRepository.CreateAsync(entity);

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
