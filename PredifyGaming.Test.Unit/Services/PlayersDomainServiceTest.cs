using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Domain.Interfaces.Services;
using Xunit;

namespace PredifyGaming.Test.Unit.Services
{
    public class PlayersDomainServiceTest
    {
        private readonly IUnitOfWork<Players> _unitOfWork;

        public PlayersDomainServiceTest(IUnitOfWork<Players> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var player = await GenerationPlayerFake();
            var playerAll = await _unitOfWork.PlayersRepository.GetAllAsync();

            playerAll.FirstOrDefault(g => g.Id == player.Id).Should().NotBeNull();

            await _unitOfWork.PlayersRepository.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _unitOfWork.PlayersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _unitOfWork.PlayersRepository.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var player = await GenerationPlayerFake();
            player.Name = "NAME PLAYERS TEST";

            await _unitOfWork.PlayersRepository.UpdateAsync(player);
            var playerById = await _unitOfWork.PlayersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _unitOfWork.PlayersRepository.DeleteAsync(player.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var player = await GenerationPlayerFake();
            await _unitOfWork.PlayersRepository.DeleteAsync(player.Id);

            var playerById = await _unitOfWork.PlayersRepository.GetByIdAsync(player.Id);
            playerById.Should().BeNull();
        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _unitOfWork.PlayersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _unitOfWork.PlayersRepository.DeleteAsync(player.Id);

        }

        private async Task<Players> GenerationPlayerFake()
        {
            var player = new Players
            {
                Name = "PLAYER TEST"
            };
            await _unitOfWork.PlayersRepository.CreateAsync(player);
            return player;
        }
    }
}
