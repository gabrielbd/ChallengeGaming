using AutoMapper;
using FluentAssertions;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using Xunit;

namespace PredifyGaming.Test.Unit.AppServices
{
    public class PlayersAppServiceTest
    {
        private readonly IPlayersAppService _playersAppService;
        private readonly IMapper _mapper;

        public PlayersAppServiceTest(IPlayersAppService playersAppService, IMapper mapper)
        {
            _playersAppService = playersAppService;
            _mapper = mapper;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var dto = new Players
            {
                Name = "PLAYERS TEST"
            };
            var player = await _playersAppService.CreateAsync(dto);

            var playerAll = await _playersAppService.GetAllAsync();
            playerAll.FirstOrDefault(g => g.Id == player.Id).Should().NotBeNull();

            await _playersAppService.DeleteAsync(player.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var dto = new Players
            {
                Name = "PLAYERS TEST"
            };
            var player = await _playersAppService.CreateAsync(dto);

            var playerById = await _playersAppService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersAppService.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var dto = new Players
            {
                Name = "PLAYERS TEST"
            };
            var player = await _playersAppService.CreateAsync(dto);
            dto.Name = "PLAYERS TEST UPDATE";
            await _playersAppService.UpdateAsync(dto);

            var playerById = await _playersAppService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersAppService.DeleteAsync(player.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var dto = new Players
            {
                Name = "PLAYERS TEST"
            };
            var player = await _playersAppService.CreateAsync(dto);
            await _playersAppService.DeleteAsync(player.Id);

            var playerById = await _playersAppService.GetByIdAsync(player.Id);
            playerById.Should().BeNull();
        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var dto = new Players
            {
                Name = "PLAYERS TEST" 
            };
            var player = await _playersAppService.CreateAsync(dto);
            var playerById = await _playersAppService.GetByIdAsync(player.Id);
            playerById.Should().NotBeNull();

            await _playersAppService.DeleteAsync(player.Id);

        }
    }
}
