using FluentAssertions;
using PredifyGaming.Domain.Entities;
using Xunit;

namespace PredifyGaming.Test.Unit.Entities
{
    public class PlaysResultTest
    {

        [Fact]
        public void ValidateTestId()
        {
            long defaultLong = 0;

            var plays = new PlaysResult
            {   
                Id = defaultLong
            };

            plays.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }
    }
}
