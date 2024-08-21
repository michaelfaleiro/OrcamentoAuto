using OrcamentoAuto.Api.Filters;
using OrcamentoAuto.Application.Services.ClienteService;
using OrcamentoAuto.Core.Repositories.Clientes;
using OrcamentoAuto.Infra.Data;
using OrcamentoAuto.Infra.Repositories.Clientes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.ClienteUseCase();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();