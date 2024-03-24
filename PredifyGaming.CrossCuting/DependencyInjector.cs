using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Application.Notifications;
using PredifyGaming.Application.RequestHandlers;
using PredifyGaming.Application.Services;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Domain.Services;
using PredifyGaming.Infra.Repositories;


namespace PredifyGaming.CrossCuting
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //MediatoR
            svcCollection.AddTransient<IRequestHandler<CreatePlayResultCommand, PlaysResultDTO>, PlaysResultRequestHandler>();
            svcCollection.AddTransient<INotificationHandler<LogPlaysResultNotification>, LogPlaysResultNotificationHandler>();


            // Application
            svcCollection.AddTransient(typeof(IBaseAppService<>), typeof(BaseAppService<>));
            svcCollection.AddTransient<IGamesAppService, GamesAppService>();
            svcCollection.AddTransient<IPlayersAppService, PlayersAppService>();
            svcCollection.AddTransient<IPlaysResultAppService, PlaysResultAppService>();

            // Domain
            svcCollection.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
            svcCollection.AddTransient<IGamesDomainService, GamesDomainService>();
            svcCollection.AddTransient<IPlayersDomainService, PlayersDomainService>();
            svcCollection.AddTransient<IPlaysResultDomainService, PlaysResultDomainService>();

            // Repository
            svcCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            svcCollection.AddTransient<IGamesRepository, GamesRepository>();
            svcCollection.AddTransient<IPlayersRepository, PlayersRepository>();
            svcCollection.AddTransient<IPlaysResultRepository, PlaysResultRepository>();

            // Unit of Work
            svcCollection.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
