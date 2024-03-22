using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Services;
using Xunit;

namespace PredifyGaming.Test.Unit.Services
{
    public class PlayersDomainServiceTest
    {
        private readonly IPlayersDomainService _playersDomainService;

        public PlayersDomainServiceTest(IPlayersDomainService playersDomainService)
        {
            this._playersDomainService = playersDomainService;
        }


        [Fact]
        public async Task TestGetAllAsync()
        {
            var player = new Players
            {
                Name = "Player TEST"
            };
            await _playersDomainService.CreateAsync(player);

            var playerAll = await _playersDomainService.GetAllAsync();
            playerAll.FirstOrDefault(g => g.Id == player.Id).Should().NotBeNull();

            await _playersDomainService.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _playersDomainService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersDomainService.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var player = await GenerationPlayerFake();
            player.Name = "NAME PLAYERS TEST";

            await _playersDomainService.UpdateAsync(player);
            var playerById = await _playersDomainService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersDomainService.DeleteAsync(player.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var player = await GenerationPlayerFake();
            await _playersDomainService.DeleteAsync(player.Id);

            var playerById = await _playersDomainService.GetByIdAsync(player.Id);
            playerById.Should().BeNull();
        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _playersDomainService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersDomainService.DeleteAsync(player.Id);

        }

        private async Task<Players> GenerationPlayerFake()
        {
            var player = new Players
            {
                Name = "PLAYER TEST"
            };
            await _playersDomainService.CreateAsync(player);
            return player;
        }
    }
}
