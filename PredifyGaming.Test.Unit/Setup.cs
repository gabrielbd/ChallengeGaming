using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Application.Services;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Domain.Services;
using PredifyGaming.Infra.Contexts;
using PredifyGaming.Infra.Repositories;


namespace PredifyGaming.Test.Unit
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) =>
            {
                #region Ativar a Injeção de dependência no XUnit

                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);

                #endregion
            });

            ConfigureServices((context, services) =>
            {

                //config banco de teste unit

                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                var connectionString = root.GetSection("ConnectionStrings").GetSection("predifyConnection").Value;

               

                //Injetando a connection string na classe SqlServerContext
                services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));

                //Injetando do automapper para os testes da appService
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

              
                //Repository
                services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                services.AddTransient<IGamesRepository, GamesRepository>();
                services.AddTransient<IPlayersRepository, PlayersRepository>();
                services.AddTransient<IPlaysResultRepository, PlaysResultRepository>();


                //DomainService
                services.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
                services.AddTransient<IGamesDomainService, GamesDomainService>();
                services.AddTransient<IPlayersDomainService, PlayersDomainService>();
                services.AddTransient<IPlaysResultDomainService, PlaysResultDomainService>();

                //AppService
                services.AddTransient(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
                services.AddTransient<IGamesAppService, GamesAppService>();
                services.AddTransient<IPlayersAppService, PlayersAppService>();
                services.AddTransient<IPlaysResultAppService, PlaysResultAppService>();

            });
        }
    }
}
