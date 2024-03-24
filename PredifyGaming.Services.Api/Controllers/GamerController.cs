using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Interfaces;

namespace PredifyGaming.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamerController : ControllerBase
    {
        private readonly IGamesAppService _appService;

        public GamerController(IGamesAppService gamesAppService)
        {
            _appService = gamesAppService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(CreateGameCommand command)
        //{

        //        var data = await _appService.CreateGameAsync(command);
        //        return Ok($@"Game criado com sucesso ID:{data.IdGame}");
        //}
    }
}
