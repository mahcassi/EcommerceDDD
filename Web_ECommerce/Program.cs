using Application.Interfaces;
using Application.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceProduto;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Infra.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
               .AddDbContext<ContextBase>(
                  options =>
                  {
                      options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
                      options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                  }
               );
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IProduto, RepositoryProduto>();

builder.Services.AddSingleton<IProdutoApp, AppProduto>();
builder.Services.AddSingleton<IServiceProduto, ServiceProduto>();

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
