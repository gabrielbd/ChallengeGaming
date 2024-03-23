using AutoMapper;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Domain.DTO;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Infra.Logs.Models;

namespace PredifyGaming.Application.Mappings
{
    public class ModelsToEntityMap : Profile
    {
        public ModelsToEntityMap()
        {

            //MAPING GAME
            CreateMap<Games, CreateGameCommand>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreateGameCommand, Games>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<Games, GameDTO>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.IdGame, opt => opt.MapFrom(src => src.Id));
            CreateMap<GameDTO, Games>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.DateTimeCreate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdGame));



            //MAPING PLAYERS
            CreateMap<Players, CreatePlayerCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<CreatePlayerCommand, Players>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Players, PlayerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IdPlayer, opt => opt.MapFrom(src => src.Id));
            CreateMap<PlayerDTO, Players>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DateTimeCreate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdPlayer));



            //MAPPING PLAYS
            CreateMap<PlaysResult, CreatePlayResultCommand>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId));
            CreateMap<CreatePlayResultCommand, PlaysResult>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId));

            CreateMap<PlaysResult, PlaysResultDTO>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.Games.Name))
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Players.Name))
                .ForMember(dest => dest.PointsResult, opt => opt.MapFrom(src => src.PointsResult))
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => DateTime.UtcNow));



            //MAPING LOGS
            CreateMap<PlaysResult, LogPlaysResultModel>()
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.DescriptionGame, opt => opt.MapFrom(src => src.Games.Name))
                .ForMember(dest => dest.DescriptionPlayer, opt => opt.MapFrom(src => src.Players.Name))
                .ForMember(dest => dest.BalancePlayer, opt => opt.MapFrom(src => src.PointsResult));

        }
    }
}