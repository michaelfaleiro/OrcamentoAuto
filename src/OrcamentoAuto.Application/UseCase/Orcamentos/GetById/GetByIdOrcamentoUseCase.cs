using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Cliente;
using OrcamentoAuto.Communication.Response.ItemOrcamento;
using OrcamentoAuto.Communication.Response.Orcamento;
using OrcamentoAuto.Communication.Response.Veiculo;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.GetById;
public class GetByIdOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;

    public GetByIdOrcamentoUseCase(IOrcamentoRepository orcamentoRepository)
    {
        _orcamentoRepository = orcamentoRepository;
    }

    public async Task<Response<ResponseOrcamentoJson>> Execute(string id)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Orçamento não encontrado");

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
                Itens = orcamento.Itens.Select(x => new ResponseItemOrcamentoJson
                {
                    Id = x.Id,
                    ProdutoId = x.ProdutoId,
                    Nome = x.Nome,
                    Quantidade = x.Quantidade,
                    Sku = x.Sku,
                    ValorVenda = x.ValorVenda,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList(),
                Status = orcamento.Status,
                CreatedAt = orcamento.CreatedAt,
                UpdatedAt = orcamento.UpdatedAt
            }
        };
    }
}
