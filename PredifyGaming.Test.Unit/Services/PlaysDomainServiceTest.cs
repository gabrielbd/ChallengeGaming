using Bogus;
using FluentAssertions;
using PredifyGaming.Domain.Entities;
using PredifyGaming.Domain.Interfaces.Repositories;
using Xunit;

namespace PredifyGaming.Test.Unit.Services
{
    public class PlaysDomainServiceTest
    {
        private readonly IUnitOfWork<PlaysResult> _unitOfWork;

        public PlaysDomainServiceTest(IUnitOfWork<PlaysResult> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Fact]
        public async Task TestGetAllByGameAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _unitOfWork.PlaysResultRepository.GetAllByGameAsync(play.GameId);
            playById.Should().NotBeNull(); ;

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task GetAllByPlayerAsync()
        {
            var play = await GenerationPlayFake();
            var playerById = await _unitOfWork.PlaysResultRepository.GetAllByGameAsync(play.PlayerId);
            playerById.Should().NotBeNull(); ;

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var play = await GenerationPlayFake();
            var playAll = await _unitOfWork.PlaysResultRepository.GetAllAsync();
            playAll.FirstOrDefault(g => g.GameId == play.GameId).Should().NotBeNull();

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _unitOfWork.PlaysResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var play = await GenerationPlayFake();
            play.PointsResult = 999;

            await _unitOfWork.PlaysResultRepository.UpdateAsync(play);
            var playById = await _unitOfWork.PlaysResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var play = await GenerationPlayFake();
            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);

            var playById = await _unitOfWork.PlaysResultRepository.GetByIdAsync(play.Id);
            playById.Should().BeNull();

        }

        [Fact]
        public async Task TestByIdAsync()
        {
            var play = await GenerationPlayFake();
            var playById = await _unitOfWork.PlaysResultRepository.GetByIdAsync(play.Id);
            playById.Should().NotBeNull();

            await _unitOfWork.PlaysResultRepository.DeleteAsync(play.Id);

        }


        private async Task<PlaysResult> GenerationPlayFake()
        {
            var faker = new Faker("pt_BR");
            var game = new Games
            {
                Name = faker.Company.ToString()
            };
            var gameFake = await _unitOfWork.GamesRepository.CreateAsync(game);


            var player = new Players
            {
                Name = faker.Person.FullName
            };
            var playerFake = await _unitOfWork.PlayersRepository.CreateAsync(player);

            var play = new PlaysResult
            {
                PlayerId = playerFake.Id,
                GameId = gameFake.Id,
                TimeStamp = DateTime.UtcNow,
                PointsResult = faker.Random.Long(-15, 20)

            };
            return await _unitOfWork.PlaysResultRepository.CreateAsync(play);
        }


    }
}
