using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PredifyGaming.Application.Commands.Players;
using System.Net;
using System.Text;
using Xunit;

namespace PredifyGaming.Test.Integration
{
    public class PlayerControllerTest
    {

        [Fact]
        public async Task TestCreatedPlayer()
        {
            var faker = new Faker("pt_BR");

            var dto = new PlayersDTO
            {
                Name = faker.Person.FullName,
            };

            var content = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8, "application/json");

            var result = await new WebApplicationFactory<Program>()
                     .CreateClient().PostAsync("/api/Player", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
    }
}
