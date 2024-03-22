using Bogus;
using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using Xunit;

namespace PredifyGaming.Test.Unit.Repositories
{
    public class GamesRepositoryTest
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesRepositoryTest(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
            await _gamesRepository.CreateAsync(game);

            var gameAll = await _gamesRepository.GetAllAsync();
            gameAll.FirstOrDefault(g => g.Id == game.Id).Should().NotBeNull();

            await _gamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _gamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var game = await GenerationGameFake();
            game.Name = "NAME GAME TEST";

            await _gamesRepository.UpdateAsync(game);
            var gameById = await _gamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var game = await GenerationGameFake();
            await _gamesRepository.DeleteAsync(game.Id);

            var gameById = await _gamesRepository.GetByIdAsync(game.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _gamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesRepository.DeleteAsync(game.Id);
        }

        private async Task<Games> GenerationGameFake()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
              await _gamesRepository.CreateAsync(game);
             return game;
        }
    }
}
