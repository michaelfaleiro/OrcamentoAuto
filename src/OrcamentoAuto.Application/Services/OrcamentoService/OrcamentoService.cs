using Microsoft.Extensions.DependencyInjection;
using OrcamentoAuto.Application.UseCase.Orcamentos.GetAll;
using OrcamentoAuto.Application.UseCase.Orcamentos.GetById;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.AdicionarItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.RemoverItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.ItemOrcamento.UpdateItem;
using OrcamentoAuto.Application.UseCase.Orcamentos.Register;
using OrcamentoAuto.Application.UseCase.Orcamentos.Servicos;
using OrcamentoAuto.Core.Repositories.Orcamentos;
using OrcamentoAuto.Infra.Repositories.Orcamentos;

namespace OrcamentoAuto.Application.Services.OrcamentoService;
public static class OrcamentoService
{
    public static IServiceCollection OrcamentoUseCase(this IServiceCollection services)
    {

        services.AddSingleton<IOrcamentoRepository, OrcamentoRepository>();
        services.AddSingleton<RegisterOrcamentoUseCase>();
        services.AddSingleton<GetByIdOrcamentoUseCase>();
        services.AddSingleton<GetAllOrcamentosUseCase>();
        services.AddSingleton<AdicionarItemOrcamentoUseCase>();
        services.AddSingleton<RemoverItemOrcamentoUseCase>();
        services.AddSingleton<UpdateItemOrcamentoUseCase>();
        services.AddSingleton<AdicionarServicoOrcamentoUseCase>();

        return services;
    }
}
