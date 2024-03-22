using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.Games;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Application.Services;

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
        //public async Task<IActionResult> Post(GamesDTO dto)
        //{
        //    try
        //    {
        //        var data = await _appService.CreateAsync(dto);
        //        return Ok($@"Game criado com sucesso ID:{data.Id}");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
