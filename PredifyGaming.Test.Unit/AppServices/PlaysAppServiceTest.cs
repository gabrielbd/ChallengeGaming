using Bogus;
using FluentAssertions;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Infra.Logs.Interfaces;
using Xunit;

namespace PredifyGaming.Test.Unit.AppServices
{
    public class PlaysAppServiceTest
    {
        private readonly IGamesAppService _gamesAppService;
        private readonly IPlayersAppService _playersAppService;
        private readonly IPlaysResultAppService _playsResultAppService;


        public PlaysAppServiceTest(IGamesAppService gamesAppService, IPlayersAppService playersAppService, IPlaysResultAppService playsResultAppService, ILogPlaysResultPersistence logPlaysResultPersistence)
        {
            _gamesAppService = gamesAppService;
            _playersAppService = playersAppService;
            _playsResultAppService = playsResultAppService;
        }

        [Fact]
        public async Task GetByPlayerIsGameAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultAppService.GetByPlayerIsGameAsync(play.PlayerId, play.GameId);
            playById.Should().NotBeNull(); ;

            await _playsResultAppService.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestGetAllByGameAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _playsResultAppService.GetAllByGameAsync(play.GameId);
            playById.Should().NotBeNull(); ;

            await _playsResultAppService.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task GetAllByPlayerAsync()
        {
            var play = await GenerationPlayFake();
            var playerById = await _playsResultAppService.GetAllByGameAsync(play.PlayerId);
            playerById.Should().NotBeNull(); ;

            await _playsResultAppService.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var play = await GenerationPlayFake();
            var playAll = await _playsResultAppService.GetAllAsync();
            playAll.FirstOrDefault(g => g.GameId == play.GameId).Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {

            var plays = await GenerationPlayFake();

            var gameById = await _playsResultAppService.GetByIdAsync(plays.Id);
            gameById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(plays.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var play = await GenerationPlayFake();
            play.PointsResult = 123;

            var playResultUpdate = await _playsResultAppService.UpdateAsync(play);

            var playById = await _playsResultAppService.GetByIdAsync(playResultUpdate.Id);
            playById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(playResultUpdate.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var play = await GenerationPlayFake();
            await _playsResultAppService.DeleteAsync(play.Id);

            var gameById = await _playsResultAppService.GetByIdAsync(play.Id);
            gameById.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var play = await GenerationPlayFake();

            var playById = await _playsResultAppService.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _playsResultAppService.DeleteAsync(play.Id);

        }

        private async Task<PlaysResult> GenerationPlayFake()
        {
            var faker = new Faker("pt_BR");
            var game = new Games
            {
                Name = faker.Company.ToString()
            };
            var gameFake = await _gamesAppService.CreateAsync(game);


            var player = new Players
            {
                Name = faker.Person.FullName
            };
            var playerFake = await _playersAppService.CreateAsync(player);

            var play = new PlaysResult
            {
                PlayerId = playerFake.Id,
                GameId = gameFake.Id,
            };
            return await _playsResultAppService.CreateAsync(play);
        }
    }
}
