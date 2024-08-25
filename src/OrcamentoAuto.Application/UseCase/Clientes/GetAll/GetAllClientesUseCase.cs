using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Core.Repositories.Clientes;

namespace OrcamentoAuto.Application.UseCase.Clientes.GetAll;
public class GetAllClientesUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<PagedResponse<ResponseClienteJson>> Execute(int pageNumber, int pageSize)
    {
        var clientes = await _clienteRepository.GetAllAsync(pageNumber, pageSize);

        var response = clientes.Data.Select(cliente => new ResponseClienteJson()
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone,
            CpfCnpj = cliente.CpfCnpj,
            RgIe = cliente.RgIe,
            Email = cliente.Email,
            CreatedAt = cliente.CreatedAt,
            UpdatedAt = cliente.UpdatedAt
        });

        return new PagedResponse<ResponseClienteJson>()
        {
            Data = response,
            PageNumber = clientes.PageNumber,
            PageSize = clientes.PageSize,
            TotalCount = clientes.TotalCount,
        };
    }
}
