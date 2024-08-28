using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Funcionario;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Exceptions.ExceptionsBase;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.GetById;
public class GetByIdFuncionarioUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    public GetByIdFuncionarioUseCase(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<Response<ResponseFuncionarioJson>> Execute(string id)
    {
        var funcionario = await _funcionarioRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Funcionário não encontrado");


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

}
