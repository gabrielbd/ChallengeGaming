using MediatR;
using PredifyGaming.Infra.Logs.Interfaces;

namespace PredifyGaming.Application.Notifications
{
    public class LogPlaysResultNotificationHandler : INotificationHandler<LogPlaysResultNotification>
    {
        private readonly ILogPlaysResultPersistence _logPlaysResultPersistence;

        public LogPlaysResultNotificationHandler(ILogPlaysResultPersistence logPlaysResultPersistence)
        {
            _logPlaysResultPersistence = logPlaysResultPersistence;
        }

        public async Task Handle(LogPlaysResultNotification notification, CancellationToken cancellationToken)
        {
            await _logPlaysResultPersistence.CreateAsync(notification.LogPlaysResult);
        }
    }
}
