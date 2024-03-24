using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;

namespace PredifyGaming.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly IPlaysResultAppService _playsResultAppService;

        public PlaysController(IPlaysResultAppService playsAppService)
        {
            _playsResultAppService = playsAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePlayResultCommand command)
        {
            try
            {
                var data = await _playsResultAppService.CreatePlayAsync(command);
                var gameplayResult = await _playsResultAppService.GameResultFormat(data);

                return Ok(gameplayResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public  IActionResult Get(long idGame)
        {
            try
            {
                var data = _playsResultAppService.LeaderBoardFormat(idGame);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
