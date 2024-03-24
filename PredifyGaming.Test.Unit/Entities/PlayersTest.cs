using FluentAssertions;
using PredifyGaming.Domain.Entities;
using Xunit;

namespace PredifyGaming.Test.Unit.Entities
{
    public class PlayersTest
    {
        [Fact]
        public void ValidateTestName()
        {
            var players = new Players
            {
                Name = string.Empty
            };

            players.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Nome do jogador é inválido"))
                .Should()
                .NotBeNull();
        }
    }
}
