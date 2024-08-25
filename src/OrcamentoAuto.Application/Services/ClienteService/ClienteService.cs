using Microsoft.Extensions.DependencyInjection;
using OrcamentoAuto.Application.UseCase.Clientes.Delete;
using OrcamentoAuto.Application.UseCase.Clientes.GetAll;
using OrcamentoAuto.Application.UseCase.Clientes.GetById;
using OrcamentoAuto.Application.UseCase.Clientes.Register;
using OrcamentoAuto.Application.UseCase.Clientes.Update;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Adicionar;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Remover;
using OrcamentoAuto.Application.UseCase.Clientes.Veiculos.Update;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Infra.Repositories.Clientes;

namespace OrcamentoAuto.Application.Services.ClienteService;
public static class ClienteService
{
    public static IServiceCollection ClienteUseCase(this IServiceCollection services)
    {

        services.AddSingleton<IClienteRepository, ClienteRepository>();
        services.AddSingleton<RegisterClienteUseCase>();
        services.AddSingleton<GetByIdClienteUseCase>();
        services.AddSingleton<UpdateClienteUseCase>();
        services.AddSingleton<GetAllClientesUseCase>();
        services.AddSingleton<DeleteClienteUseCase>();
        services.AddSingleton < AdicionarVeiculoClienteUseCase>();
        services.AddSingleton<UpdateVeiculoUseCase>();
        services.AddSingleton<RemoverVeiculoUseCase>();

        return services;
    }
}
