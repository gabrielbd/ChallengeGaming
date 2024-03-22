using FluentAssertions;
using PredifyGaming.Domain.Entities;
using Xunit;

namespace PredifyGaming.Test.Unit.Entities
{
    public class GamesTest
    {


        [Fact]
        public void ValidateTestId()
        {
            long defaultLong = 0;

            var players = new Games
            {
                Id = defaultLong
            };

            players.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidateTestName()
        {
            var games = new Games
            {
                Name = string.Empty
            };

            games.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Nome do game inválido"))
                .Should()
                .NotBeNull();
        }
    }
}
