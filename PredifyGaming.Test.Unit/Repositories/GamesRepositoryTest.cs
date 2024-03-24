using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using Xunit;

namespace PredifyGaming.Test.Unit.Repositories
{
    public class GamesRepositoryTest
    {
        private readonly IUnitOfWork<Games> _unitOfWork;

        public GamesRepositoryTest(IUnitOfWork<Games> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var game = await GenerationGameFake();

            var gameAll = await _unitOfWork.GamesRepository.GetAllAsync();
            gameAll.FirstOrDefault(g => g.Id == game.Id).Should().NotBeNull();

            await _unitOfWork.GamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _unitOfWork.GamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _unitOfWork.GamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var game = await GenerationGameFake();
            game.Name = "NAME GAME TEST";

            await _unitOfWork.GamesRepository.UpdateAsync(game);
            var gameById = await _unitOfWork.GamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _unitOfWork.GamesRepository.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var game = await GenerationGameFake();
            await _unitOfWork.GamesRepository.DeleteAsync(game.Id);

            var gameById = await _unitOfWork.GamesRepository.GetByIdAsync(game.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _unitOfWork.GamesRepository.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _unitOfWork.GamesRepository.DeleteAsync(game.Id);
        }

        private async Task<Games> GenerationGameFake()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
              await _unitOfWork.GamesRepository.CreateAsync(game);
             return game;
        }
    }
}
