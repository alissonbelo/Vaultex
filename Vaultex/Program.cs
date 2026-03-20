using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Vaultex.Api.Endpoints;
using Vaultex.Application.UseCases.Accounts;
using Vaultex.Domain.Interfaces;
using Vaultex.Infrastructure.Persistence;
using Vaultex.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<VaultexDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<CreateAccountUseCase>();
builder.Services.AddScoped<GetAccountUseCase>();
builder.Services.AddScoped<ListAccountsUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VaultexDbContext>();
    db.Database.Migrate();
}

app.MapAccountEndpoints();

app.Run();