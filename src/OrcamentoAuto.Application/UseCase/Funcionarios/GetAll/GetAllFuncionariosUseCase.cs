using OrcamentoAuto.Communication.Response;
using OrcamentoAuto.Communication.Response.Funcionario;
using OrcamentoAuto.Core.Repositories.Funcionarios;

namespace OrcamentoAuto.Application.UseCase.Funcionarios.GetAll;
public class GetAllFuncionariosUseCase
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    public GetAllFuncionariosUseCase(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<PagedResponse<ResponseFuncionarioJson>> Execute(int pageNumber, int pageSize)
    {
        var funcionarios = await _funcionarioRepository.GetAllAsync(pageNumber, pageSize);

        var response = new PagedResponse<ResponseFuncionarioJson>
        {
            Data = funcionarios.Data.Select(x => new ResponseFuncionarioJson
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email,
                Telefone = x.Telefone,
                TipoFuncionario = x.TipoFuncionario.ToString(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }),
            PageNumber = funcionarios.PageNumber,
            PageSize = funcionarios.PageSize,
            TotalCount = funcionarios.TotalPages
        };

        return response;
    }
}
