using Bogus;
using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PredifyGaming.Test.Unit.Repositories
{
    public class PlaysRepositoryTest
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly IPlaysResultRepository _playsResultRepository;

        public PlaysRepositoryTest(IGamesRepository gamesRepository, IPlayersRepository playersRepository, IPlaysResultRepository playsResultRepository)
        {
            _gamesRepository = gamesRepository;
            _playersRepository = playersRepository;
            _playsResultRepository = playsResultRepository;
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultRepository.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var play = await GenerationPlayFake();
            play.PointsResult = 999;

            await _playsResultRepository.UpdateAsync(play);
            var playById = await _playsResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultRepository.DeleteAsync(play.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var play = await GenerationPlayFake();
            await _playsResultRepository.DeleteAsync(play.Id);

            var playById = await _playsResultRepository.GetByIdAsync(play.Id);
            playById.Should().BeNull();

        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultRepository.DeleteAsync(play.Id);

        }


        private async Task<PlaysResult> GenerationPlayFake()
        {
            var faker = new Faker("pt_BR");
            var game = new Games
            {
                Name = faker.Company.ToString()
            };
            var gameFake = await _gamesRepository.CreateAsync(game);


            var player = new Players
            {
                Name = faker.Person.FullName
            };
            var playerFake = await _playersRepository.CreateAsync(player);

            var play = new PlaysResult
            {
                PlayerId = playerFake.Id,
                GameId = gameFake.Id,
                TimeStamp = DateTime.UtcNow,
                PointsResult = faker.Random.Long(-15, 20)

            };
            return await _playsResultRepository.CreateAsync(play);
        }
    }
}
