using MediatR;
using PredifyGaming.Domain.DTO;

namespace PredifyGaming.Application.Commands.PlaysResult
{
    public class CreatePlayResultCommand : IRequest<PlaysResultDTO>
    {
        public long PlayerId { get; set; }
        public long GameId { get; set; }
    }
}
