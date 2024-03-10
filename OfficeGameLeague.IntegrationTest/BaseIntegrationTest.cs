using Microsoft.Extensions.DependencyInjection;
using OfficeGamesLeague.UnitOfWork;

namespace OfficeGameLeague.IntegrationTest
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        //protected readonly PremierLeagueDbContext _dbContext;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            //_dbContext = _scope.ServiceProvider.GetService<PremierLeagueDbContext>();
            _unitOfWork = _scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
