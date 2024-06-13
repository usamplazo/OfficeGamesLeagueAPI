using Microsoft.EntityFrameworkCore;
using Serilog;
using Infrastructure.Migrations;
using Infrastructure.Repositories;
using Domain.Abstractions;
using Persistance.Interceptors;
using Persistance;
using Application.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .Scan(
        selector => selector
        .FromAssemblies(Infrastructure.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
 
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

builder.Services
    .AddControllers()
    .AddApplicationPart(Presentation.AssemblyReference.Assembly);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

string? connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddSingleton<UpdateAuditableEntitesInterceptor>();

builder.Services.AddDbContext<GameLeagueDbContext>((sp, optionsBuilder) =>
{
    var auditableInterceptors = sp.GetService<UpdateAuditableEntitesInterceptor>()!;

    optionsBuilder.UseSqlServer(connectionString,
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
    .AddInterceptors(auditableInterceptors);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IScorebaordRepository, ScoreboardRepository>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }