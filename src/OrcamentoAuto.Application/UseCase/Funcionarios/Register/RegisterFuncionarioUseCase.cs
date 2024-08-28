using OrcamentoAuto.Communication.Request.Funcionario;
using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Funcionario;
using OrcamentoAuto.Core.Entities;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.Register;
public class RegisterFuncionarioUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    public RegisterFuncionarioUseCase(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<Response<ResponseFuncionarioJson>> Execute(RegisterFuncionarioRequest request)
    {
        Validate(request);

        var funcionario = new Funcionario(request.Nome, request.Email, request.Telefone, (Core.Enums.ETipoFuncionario)request.TipoFuncionario);

        await _funcionarioRepository.CreateAsync(funcionario);

        var response = new Response<ResponseFuncionarioJson>
        {
            Data = new ResponseFuncionarioJson()
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                TipoFuncionario = funcionario.TipoFuncionario.ToString(),
                CreatedAt = funcionario.CreatedAt,
                UpdatedAt = funcionario.UpdatedAt
            }
        };

        return response;
    }

    private void Validate(RegisterFuncionarioRequest request)
    {
        var validator = new RegisterFuncionarioValidator();

        var result = validator.Validate(request);

        if (result.IsValid)
            return;

        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

        throw new ErrorOnValidateException(errors);
    }
}
