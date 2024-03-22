using AutoMapper;
using FluentAssertions;
using PredifyGaming.Application.Commands.Games;
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
    public class GamesAppServiceTest
    {
        private readonly IGamesAppService _gamesAppService;
        private readonly IMapper _mapper;
        public GamesAppServiceTest(IGamesAppService gamesAppService, IMapper mapper)
        {
            _gamesAppService = gamesAppService;
            _mapper = mapper;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var dto = new GamesDTO
            {
                Name = "GAME TEST"
            };
            var game = await _gamesAppService.CreateAsync(dto);

            var gameAll = await _gamesAppService.GetAllAsync();
            gameAll.FirstOrDefault(g => g.Id == game.Id).Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var dto = new GamesDTO
            {
                Name = "GAME TEST"
            };
            var game = await _gamesAppService.CreateAsync(dto);

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var dto = new GamesDTO
            {
                Name = "GAME TEST"
            };
            var game = await _gamesAppService.CreateAsync(dto);
            dto.Name = "GAME TEST UPDATE";
            await _gamesAppService.UpdateAsync(dto);

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var dto = new GamesDTO
            {
                Name = "GAME TEST"
            };
            var game = await _gamesAppService.CreateAsync(dto);
            await _gamesAppService.DeleteAsync(game.Id);

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var dto = new GamesDTO
            {
                Name = "GAME TEST"
            };
            var game = await _gamesAppService.CreateAsync(dto);
            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);

        }


    }

}
