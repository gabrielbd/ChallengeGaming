using MediatR;
using PredifyGaming.Infra.Logs.Models;


namespace PredifyGaming.Application.Notifications
{
    public class LogPlaysResultNotification : INotification
    {
        public LogPlaysResultModel? LogPlaysResult { get; set; }
    }
}
