using Microsoft.Extensions.DependencyInjection;
using OrcamentoAuto.Application.UseCase.Produtos.Delete;
using OrcamentoAuto.Application.UseCase.Produtos.GetAll;
using OrcamentoAuto.Application.UseCase.Produtos.GetById;
using OrcamentoAuto.Application.UseCase.Produtos.Register;
using OrcamentoAuto.Application.UseCase.Produtos.Update;
using OrcamentoAuto.Core.Repositories.Produtos;
using OrcamentoAuto.Infra.Repositories.Produtos;

namespace OrcamentoAuto.Application.Services.ProdutoService;
public static class ProdutoService
{
    public static IServiceCollection ProdutoUseCase(this IServiceCollection services)
    {
        services.AddSingleton<IProdutoRepository, ProdutoRepository>();
        services.AddSingleton<RegisterProdutoUseCase>();
        services.AddSingleton<GetByIdProdutoUseCase>();
        services.AddSingleton<GetAllProdutosUseCase>();
        services.AddSingleton<UpdateProdutoUseCase>();
        services.AddSingleton<DeleteProdutoUseCase>();

        return services;
    }
}
