using Digital_Accept.Data.Context;
using Digital_Accept.Data.Repository;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///////// aqui inicia o que foi adicionado para o projeto
////adiciona o contexto aos serviços       
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApplicationDbContext"),
        b => b.MigrationsAssembly("Digital_Accept.Data"));
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var appAssemblie = typeof(
                Digital_Accept.Application.Documents.Commands.CreateDocument.CreateDocumentCommand)
                .Assembly;
builder.Services.AddMediatR(appAssemblie);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

///////////////// fim

builder.Services.AddMvc(setup => {
    // Implementação de código MVC...
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(appAssemblie));

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
