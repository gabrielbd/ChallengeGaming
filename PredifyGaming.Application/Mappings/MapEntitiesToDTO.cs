using AutoMapper;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Application.Mappings
{
    public class MapEntitiesToDTO : Profile
    {
        public MapEntitiesToDTO() {
            CreateMap<GamesDTO, Games>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.DateTimeCreate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<PlayersDTO, Players>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateTimeCreate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<PlaysResultDTO, PlaysResult>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
