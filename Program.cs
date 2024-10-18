
using Biblioteca_WebApi_ruan.ORM;
using Biblioteca_WebApi_ruan.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adicione o contexto do banco de dados
builder.Services.AddDbContext<BibliotecaWebApiRuanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione o repositório 
builder.Services.AddScoped<CategoriaR>();
builder.Services.AddScoped<EmprestimoR>();
builder.Services.AddScoped<FuncionarioR>();
builder.Services.AddScoped<LivroR>();
builder.Services.AddScoped<ReservaR>();
builder.Services.AddScoped<UsuarioR>();
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
