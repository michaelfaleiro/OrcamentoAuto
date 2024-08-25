using OrcamentoAuto.Api.Filters;
using OrcamentoAuto.Application.Services.ClienteService;
using OrcamentoAuto.Application.Services.OrcamentoService;
using OrcamentoAuto.Application.Services.ProdutoService;
using OrcamentoAuto.Infra.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.ClienteUseCase();
builder.Services.OrcamentoUseCase();
builder.Services.ProdutoUseCase();

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