using AutoMapper;
using MediatR;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Notifications;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using PredifyGaming.Infra.Logs.Models;

namespace PredifyGaming.Application.RequestHandlers
{
    public class PlaysResultRequestHandler 
        : IRequestHandler<CreatePlayResultCommand , PlaysResultDTO>,
          IDisposable
    {
        private readonly IPlaysResultDomainService _playsDomainService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediatoR;

        public PlaysResultRequestHandler(IPlaysResultDomainService playsDomainService, IMapper mapper, IMediator mediator)
        {
            _playsDomainService = playsDomainService;
            _mapper = mapper;
            _mediatoR = mediator;
        }

        public async Task<PlaysResultDTO> Handle(CreatePlayResultCommand request, CancellationToken cancellationToken)
        {
            var userData = _mapper.Map<PlaysResult>(request);
            var result = await _playsDomainService.CreateAsync(userData);

            var playResultResponse = _mapper.Map<PlaysResultDTO>(result);

            var logPlaysResultNotification = new LogPlaysResultNotification
            {
                LogPlaysResult = _mapper.Map<LogPlaysResultModel>(result)
            };
            await _mediatoR.Publish(logPlaysResultNotification);

            return playResultResponse;
        }

        public void Dispose()
        {
            _playsDomainService.Dispose();
        }

    }
}
