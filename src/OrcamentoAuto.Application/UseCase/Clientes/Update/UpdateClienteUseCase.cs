using OrcamentoAuto.Communication.Request.Cliente;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Clientes.Update;

public class UpdateClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Response<ResponseClienteJson>> Execute(string id, UpdateClienteRequest request)
    {
        Validate(request);

        var cliente = await _clienteRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente não encontrado");

        cliente.Atualizar(request.Nome, request.Telefone,
        request.CpfCnpj, request.RgIe, request.Email);

        await _clienteRepository.UpdateAsync(cliente);

        return new Response<ResponseClienteJson>()
        {
            Data = new ResponseClienteJson()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                CpfCnpj = cliente.CpfCnpj,
                RgIe = cliente.RgIe,
                Email = cliente.Email,
                CreatedAt = cliente.CreatedAt,
                UpdatedAt = cliente.UpdatedAt
            }
        };
    }

    private void Validate(UpdateClienteRequest request)
    {
        var validator = new UpdateClienteValidator();
        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
