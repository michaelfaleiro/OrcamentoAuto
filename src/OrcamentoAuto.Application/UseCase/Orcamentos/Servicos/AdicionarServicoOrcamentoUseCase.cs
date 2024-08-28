using OrcamentoAuto.Communication.Request.Orcamento;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Orcamentos.Servicos;
public class AdicionarServicoOrcamentoUseCase
{
    private readonly IOrcamentoRepository _orcamentoRepository;
    private readonly IFuncionarioRepository _funcionarioRepository;

    public AdicionarServicoOrcamentoUseCase(IOrcamentoRepository orcamentoRepository, IFuncionarioRepository funcionarioRepository)
    {
        _orcamentoRepository = orcamentoRepository;
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task ExecuteAsync(AdicionarServicoOrcamentoRequest request)
    {
        var orcamento = await _orcamentoRepository.GetByIdAsync(request.OrcamentoId)
            ?? throw new NotFoundException("Orçamento não encontrado");

        var mecanico = await _funcionarioRepository.GetByIdAsync(request.MecanicoId)
            ?? throw new NotFoundException("Mecânico não encontrado");
        
        var servico = new Servico(mecanico.Id, request.Descricao, request.Valor, request.Quantidade, orcamento.Id);

        orcamento.AdicionarServico(servico);

        await _orcamentoRepository.UpdateAsync(orcamento);
    }
}
