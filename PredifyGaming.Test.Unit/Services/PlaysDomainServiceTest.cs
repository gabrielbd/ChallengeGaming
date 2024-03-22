using Bogus;
using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PredifyGaming.Test.Unit.Services
{
    public class PlaysDomainServiceTest
    {
        private readonly IGamesDomainService _gamesDomainService;
        private readonly IPlayersDomainService _playersDomainService;
        private readonly IPlaysResultDomainService _playsResultDomainService;

        public PlaysDomainServiceTest(IGamesDomainService gamesDomainService, IPlayersDomainService playersDomainService, IPlaysResultDomainService playsResultDomainService)
        {
            _gamesDomainService = gamesDomainService;
            _playersDomainService = playersDomainService;
            _playsResultDomainService = playsResultDomainService;
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultDomainService.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultDomainService.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var play = await GenerationPlayFake();
            play.PointsResult = 999;

            await _playsResultDomainService.UpdateAsync(play);
            var playById = await _playsResultDomainService.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultDomainService.DeleteAsync(play.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var play = await GenerationPlayFake();
            await _playsResultDomainService.DeleteAsync(play.Id);

            var playById = await _playsResultDomainService.GetByIdAsync(play.Id);
            playById.Should().BeNull();

        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultDomainService.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultDomainService.DeleteAsync(play.Id);

        }


        private async Task<PlaysResult> GenerationPlayFake()
        {
            var faker = new Faker("pt_BR");
            var game = new Games
            {
                Name = faker.Company.ToString()
            };
            var gameFake = await _gamesDomainService.CreateAsync(game);


            var player = new Players
            {
                Name = faker.Person.FullName
            };
            var playerFake = await _playersDomainService.CreateAsync(player);

            var play = new PlaysResult
            {
                PlayerId = playerFake.Id,
                GameId = gameFake.Id,
                TimeStamp = DateTime.UtcNow,
                PointsResult = faker.Random.Long(-15, 20)

            };
            return await _playsResultDomainService.CreateAsync(play);
        }


    }
}
