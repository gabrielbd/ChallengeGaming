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
    public class GamesDomainServiceTest
    {
        private readonly IGamesDomainService _gamesDomainService;

        public GamesDomainServiceTest(IGamesDomainService gamesDomainService)
        {
            _gamesDomainService = gamesDomainService;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
            await _gamesDomainService.CreateAsync(game);

            var gameAll = await _gamesDomainService.GetAllAsync();
            gameAll.FirstOrDefault(g => g.Id == game.Id).Should().NotBeNull();

            await _gamesDomainService.DeleteAsync(game.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _gamesDomainService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesDomainService.DeleteAsync(game.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var game = await GenerationGameFake();
            game.Name = "NAME GAME TEST";

            await _gamesDomainService.UpdateAsync(game);
            var gameById = await _gamesDomainService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesDomainService.DeleteAsync(game.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var game = await GenerationGameFake();
            await _gamesDomainService.DeleteAsync(game.Id);

            var gameById = await _gamesDomainService.GetByIdAsync(game.Id);
            gameById.Should().BeNull();

        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var game = await GenerationGameFake();
            var gameById = await _gamesDomainService.GetByIdAsync(game.Id);
            gameById.Should().NotBeNull();

            await _gamesDomainService.DeleteAsync(game.Id);

        }


        private async Task<Games> GenerationGameFake()
        {
            var game = new Games
            {
                Name = "GAME TEST"
            };
            await _gamesDomainService.CreateAsync(game);
            return game;
        }
    }
}
