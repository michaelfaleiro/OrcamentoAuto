using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Communication.Response.Orcamento;
using OrcamentoAuto.Communication.Response.Veiculo;
using OrcamentoAuto.Core.Repositories.Orcamentos;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.GetAll;
public class GetAllOrcamentosUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public GetAllOrcamentosUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task<PagedResponse<ResponseOrcamentoJson>> Execute(int pageNumber, int pageSize)
    {
        var orcamentos = await _orcamentoRepository.GetAllAsync(pageNumber, pageSize);

        var response = orcamentos.Data.Select(orcamento => new ResponseOrcamentoJson()
        {
            Id = orcamento.Id,
            Cliente = new ResponseClienteJson()
            {
                Id = orcamento.Cliente.Id,
                Nome = orcamento.Cliente.Nome,
                Telefone = orcamento.Cliente.Telefone,
                CpfCnpj = orcamento.Cliente.CpfCnpj,
                RgIe = orcamento.Cliente.RgIe,
                Email = orcamento.Cliente.Email,
                CreatedAt = orcamento.Cliente.CreatedAt,
                UpdatedAt = orcamento.Cliente.UpdatedAt
            },
            Veiculo = new ResponseVeiculoJson()
            {
                Id = orcamento.Veiculo.Id,
                Marca = orcamento.Veiculo.Marca,
                Modelo = orcamento.Veiculo.Modelo,
                Placa = orcamento.Veiculo.Placa,
                Renavam = orcamento.Veiculo.Renavam,
                Chassi = orcamento.Veiculo.Chassi,
                AnoFabricacao = orcamento.Veiculo.AnoFabricacao,
                AnoModelo = orcamento.Veiculo.AnoModelo,
                CreatedAt = orcamento.Veiculo.CreatedAt,
                UpdatedAt = orcamento.Veiculo.UpdatedAt
            },
            Status = orcamento.Status,
            CreatedAt = orcamento.CreatedAt,
            UpdatedAt = orcamento.UpdatedAt
        });

        return new PagedResponse<ResponseOrcamentoJson>()
        {
            Data = response,
            PageNumber = orcamentos.PageNumber,
            PageSize = orcamentos.PageSize,
            TotalCount = orcamentos.TotalPages,
        };
    }
}
