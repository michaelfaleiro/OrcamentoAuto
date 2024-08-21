using Microsoft.Extensions.DependencyInjection;
using OrcamentoAuto.Application.UseCase.Clientes.GetById;
using OrcamentoAuto.Application.UseCase.Clientes.Register;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Infra.Repositories.Clientes;

namespace OrcamentoAuto.Application.Services.ClienteService;
public static class ClienteService
{
    public static IServiceCollection ClienteUseCase(this IServiceCollection services)
    {

        services.AddSingleton<RegisterClienteUseCase>();
        services.AddSingleton<GetByIdClienteUseCase>();

        return services;
    }
}
