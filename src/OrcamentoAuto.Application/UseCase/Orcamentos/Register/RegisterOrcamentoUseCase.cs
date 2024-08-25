using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Communication.Response.Orcamento;
using OrcamentoAuto.Communication.Response.Veiculo;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.Register;
public class RegisterOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IClienteRepository _clienteRepository;


    public RegisterOrcamentoUseCase(IOrcamentoRepository orcamentoRepository,
        IClienteRepository clienteRepository)
    {
        _orcamentoRepository = orcamentoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Response<ResponseOrcamentoJson>> Execute(RegisterOrcamentoRequest request)
    {
        var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId)
            ?? throw new NotFoundException("Cliente não encontrado");

        var veiculo = cliente.Veiculos.FirstOrDefault(v => v.Id == request.VeiculoId)
            ?? throw new NotFoundException("Veículo não encontrado");

        var orcamento = new Orcamento(cliente, veiculo, request.Status);
        
        await _orcamentoRepository.CreateAsync(orcamento);

        return new Response<ResponseOrcamentoJson>
        {
            Data = new ResponseOrcamentoJson
            {
                Id = orcamento.Id,
                Cliente = new ResponseClienteJson()
                {
                    Id = orcamento.Cliente.Id,
                    Nome = orcamento.Cliente.Nome,
                    Email = orcamento.Cliente.Email,
                    Telefone = orcamento.Cliente.Telefone
                },
                Veiculo = new ResponseVeiculoJson()
                {
                    Id = orcamento.Veiculo.Id,
                    Marca = orcamento.Veiculo.Marca,
                    Modelo = orcamento.Veiculo.Modelo,
                    AnoFabricacao = orcamento.Veiculo.AnoFabricacao,
                    AnoModelo = orcamento.Veiculo.AnoModelo,
                    Placa = orcamento.Veiculo.Placa
                },
                Status = orcamento.Status,
                CreatedAt = orcamento.CreatedAt,
                UpdatedAt = orcamento.UpdatedAt
            }
        };
    }
}
