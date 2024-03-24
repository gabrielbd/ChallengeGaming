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
            var game = await GenerationGameFake();

            var gameAll = await _gamesAppService.GetAllAsync();
            gameAll.FirstOrDefault(g => g.Id == game.Id).Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var game = await GenerationGameFake();

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var game = await GenerationGameFake();

            game.Name = "GAME TEST UPDATE";
            await _gamesAppService.UpdateAsync(game);

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var game = await GenerationGameFake();

            await _gamesAppService.DeleteAsync(game.Id);

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var game = await GenerationGameFake();

            var gameById = await _gamesAppService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesAppService.DeleteAsync(game.Id);

        }

        private async Task<Games> GenerationGameFake()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
            await _gamesAppService.CreateAsync(game);
            return game;
        }


    }

}
