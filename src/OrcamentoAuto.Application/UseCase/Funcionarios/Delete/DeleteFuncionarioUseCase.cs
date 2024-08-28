using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.Delete;
public class DeleteFuncionarioUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    public DeleteFuncionarioUseCase(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task Execute(string id)
    {
        var funcionario = await _funcionarioRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Funcionário não encontrado");

        await _funcionarioRepository.DeleteAsync(funcionario.Id);
    }
}
