﻿using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PredifyGaming.Application.Commands.PlaysResult;
using System.Net;
using System.Text;
using Xunit;

namespace PredifyGaming.Test.Integration
{
    public class PlaysControllerTest
    {

        [Fact]
        public async Task TestCreatedPlays()
        {
            var dto = new PlaysResultDTO
            {
                PlayerId = 1,
                GameId = 2,
            };

            var content = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8, "application/json");

            var result = await new WebApplicationFactory<Program>()
                     .CreateClient().PostAsync("/api/Plays", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
    }
}
