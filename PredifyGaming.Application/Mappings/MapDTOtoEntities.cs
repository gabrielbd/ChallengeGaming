using AutoMapper;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.Entities;

namespace PredifyGaming.Application.Mappings
{
    public class MapDTOtoEntities : Profile
    {
        public MapDTOtoEntities()
        {
            CreateMap<Games, GamesDTO>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Players, PlayersDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PlaysResult, PlaysResultDTO>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId));
        }
    }
}
