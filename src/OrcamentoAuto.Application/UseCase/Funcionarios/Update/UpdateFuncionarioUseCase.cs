using OrcamentoAuto.Communication.Request.Funcionario;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.Update;
public class UpdateFuncionarioUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    public UpdateFuncionarioUseCase(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task Execute(string id, UpdateFuncionarioRequest request)
    {
        Validate(request);

        var funcionario = await _funcionarioRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Funcionário não encontrado");

        funcionario.Atualizar(request.Nome, request.Email, request.Telefone, (Core.Enums.ETipoFuncionario)request.TipoFuncionario);

        await _funcionarioRepository.UpdateAsync(funcionario);
    }

    private void Validate(UpdateFuncionarioRequest request)
    {
        var validator = new UpdateFuncionarioValidator();

        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
