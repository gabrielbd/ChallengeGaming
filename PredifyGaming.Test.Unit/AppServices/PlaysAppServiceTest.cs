using AutoMapper;
using Bogus;
using FluentAssertions;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PredifyGaming.Test.Unit.AppServices
{
    public class PlaysAppServiceTest
    {
        private readonly IGamesAppService _gamesAppService;
        private readonly IPlayersAppService _playersAppService;
        private readonly IPlaysResultAppService _playsResultAppService;
        private readonly IMapper _mapper;

        public PlaysAppServiceTest(IGamesAppService gamesAppService, IPlayersAppService playersAppService, IPlaysResultAppService playsResultAppService, IMapper mapper)
        {
            _gamesAppService = gamesAppService;
            _playersAppService = playersAppService;
            _playsResultAppService = playsResultAppService;
            _mapper = mapper;
        }

        [Fact]
        public async Task TestCreateAsync()
        {

            var plays = await GenerationPlayFake();

            var gameById = await _playsResultAppService.GetByIdAsync(plays.Id);
            gameById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(plays.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var play = await GenerationPlayFake();
            play.PointsResult = 123;

            var dto = _mapper.Map<PlaysResultDTO>(play);
            var playResultUpdate = await _playsResultAppService.UpdateAsync(dto);

            var playById = await _playsResultAppService.GetByIdAsync(playResultUpdate.Id);
            playById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(playResultUpdate.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var play = await GenerationPlayFake();
            await _playsResultAppService.DeleteAsync(play.Id);

            var gameById = await _playsResultAppService.GetByIdAsync(play.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var play = await GenerationPlayFake();

            var playById = await _playsResultAppService.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(play.Id);

        }

        private async Task<PlaysResult> GenerationPlayFake()
        {
            var faker = new Faker("pt_BR");
            var game = new GamesDTO
            {
                Name = faker.Company.ToString()
            };
            var gameFake = await _gamesAppService.CreateAsync(game);


            var player = new PlayersDTO
            {
                Name = faker.Person.FullName
            };
            var playerFake = await _playersAppService.CreateAsync(player);

            var play = new PlaysResultDTO
            {
                PlayerId = playerFake.Id,
                GameId = gameFake.Id,
            };
            return await _playsResultAppService.CreateAsync(play);
        }
    }
}
