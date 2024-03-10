using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OfficeGamesLeague.Models;
using Testcontainers.MsSql;

namespace OfficeGameLeague.IntegrationTest
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:latest")
            .WithCleanUp(true)
            .WithPassword("Uzumakiforall1234!")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            string connectionString = "Server=127.0.0.1;Database=OfficeGameLeague;User Id=sa;Password=Uzumakiforall1234!;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=False;";

            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<GameLeagueDbContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<GameLeagueDbContext>(options =>
                {
                    //options.UseSqlServer(connectionString, builder =>
                    //{
                    //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    //});
                    options.UseSqlServer(connectionString);
                });
            });
        }

        public Task InitializeAsync()
        {
            return  _dbContainer.StartAsync();
        }

        public new Task DisposeAsync()
        {
            return  _dbContainer.StopAsync();
        }
    }
}
