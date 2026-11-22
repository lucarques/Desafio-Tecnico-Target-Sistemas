using APIDesafioTecnico_TargetSistemas.Interfaces;
using APIDesafioTecnico_TargetSistemas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<IComissaoService, ComissaoService>();
builder.Services.AddScoped<IFinanceiroService, FinanceiroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();