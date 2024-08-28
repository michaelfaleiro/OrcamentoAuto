using Microsoft.Extensions.DependencyInjection;
using OrcamentoAuto.Application.UseCase.Funcionarios.Delete;
using OrcamentoAuto.Application.UseCase.Funcionarios.GetAll;
using OrcamentoAuto.Application.UseCase.Funcionarios.GetById;
using OrcamentoAuto.Application.UseCase.Funcionarios.Register;
using OrcamentoAuto.Application.UseCase.Funcionarios.Update;
using OrcamentoAuto.Core.Repositories.Funcionarios;
using OrcamentoAuto.Infra.Repositories.Funcionarios;

namespace OrcamentoAuto.Application.Services.FuncionarioService;
public static class FuncionarioService
{
    public static IServiceCollection FuncionarioUseCase(this IServiceCollection services)
    {

        services.AddSingleton<IFuncionarioRepository, FuncionarioRepository>();
        services.AddSingleton<RegisterFuncionarioUseCase>();
        services.AddSingleton<UpdateFuncionarioUseCase>();
        services.AddSingleton<DeleteFuncionarioUseCase>();
        services.AddSingleton<GetByIdFuncionarioUseCase>();
        services.AddSingleton<GetAllFuncionariosUseCase>();


        return services;
    }
}
