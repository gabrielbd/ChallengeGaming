using Bogus;
using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using PredifyGaming.Infra.Repositories;
using Xunit;

namespace PredifyGaming.Test.Unit.Repositories
{
    public class PlayersRepositoryTest 
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersRepositoryTest(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var player = new Players
            {
                Name = "Player TEST"
            };
            await _playersRepository.CreateAsync(player);

            var playerAll = await _playersRepository.GetAllAsync();
            playerAll.FirstOrDefault(g => g.Id == player.Id).Should().NotBeNull();

            await _playersRepository.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _playersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersRepository.DeleteAsync(player.Id);

        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var player = await GenerationPlayerFake();
            player.Name = "NAME PLAYERS TEST";

            await _playersRepository.UpdateAsync(player);
            var playerById = await _playersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersRepository.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var player = await GenerationPlayerFake();
            await _playersRepository.DeleteAsync(player.Id);

            var playerById = await _playersRepository.GetByIdAsync(player.Id);
            playerById.Should().BeNull();

        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var player = await GenerationPlayerFake();
            var playerById = await _playersRepository.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersRepository.DeleteAsync(player.Id);

        }

        private async Task<Players> GenerationPlayerFake()
        {
            var player = new Players
            {
                Name = "PLAYER TEST"
            };
            await _playersRepository.CreateAsync(player);
            return player;
        }

    }
}
