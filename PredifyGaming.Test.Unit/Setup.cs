using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Application.Notifications;
using PredifyGaming.Application.RequestHandlers;
using PredifyGaming.Application.Services;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Domain.Services;
using PredifyGaming.Infra.Contexts;
using PredifyGaming.Infra.Logs.Contexts;
using PredifyGaming.Infra.Logs.Interfaces;
using PredifyGaming.Infra.Logs.Persistence;
using PredifyGaming.Infra.Logs.Settings;
using PredifyGaming.Infra.Repositories;
using System.Reflection;


namespace PredifyGaming.Test.Unit
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) =>
            {

                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);

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


                services.Configure<MongoDBSettings>(options =>
                {
                    options.Host = root.GetSection("MongoDBPredify").GetSection("Host").Value; ;
                    options.Name = root.GetSection("MongoDBPredify").GetSection("Name").Value; ;
                    options.IsSSL = root.GetSection("MongoDBPredify").GetValue<bool>("IsSSL");
                });

                services.AddSingleton<MongoDBContext>();
                services.AddTransient<ILogPlaysResultPersistence, LogPlaysResultPersistence>();


                //Injetando o automapper para os testes da appService
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                //Injetando o mediator para os testes 
                services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));




                //MediatoR
                services.AddTransient<IRequestHandler<CreatePlayResultCommand, PlaysResultDTO>, PlaysResultRequestHandler>();
                services.AddTransient<INotificationHandler<LogPlaysResultNotification>, LogPlaysResultNotificationHandler>();

                // Application
                services.AddTransient(typeof(IBaseAppService<>), typeof(BaseAppService<>));
                services.AddTransient<IGamesAppService, GamesAppService>();
                services.AddTransient<IPlayersAppService, PlayersAppService>();
                services.AddTransient<IPlaysResultAppService, PlaysResultAppService>();

                // Domain
                services.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
                services.AddTransient<IGamesDomainService, GamesDomainService>();
                services.AddTransient<IPlayersDomainService, PlayersDomainService>();
                services.AddTransient<IPlaysResultDomainService, PlaysResultDomainService>();

                // Repository
                services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                services.AddTransient<IGamesRepository, GamesRepository>();
                services.AddTransient<IPlayersRepository, PlayersRepository>();
                services.AddTransient<IPlaysResultRepository, PlaysResultRepository>();

                // Unit of Work
                services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            });
        }
    }
}
