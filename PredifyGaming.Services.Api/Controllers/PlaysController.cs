using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Commands.PlaysResult;
using PredifyGaming.Application.Interfaces;

namespace PredifyGaming.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly IPlaysResultAppService _playsAppService;

        public PlaysController(IPlaysResultAppService playsAppService)
        {
            _playsAppService = playsAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlaysResultDTO dto)
        {
            try
            {
                var data = await _playsAppService.CreateAsync(dto);
                var gameResult = await _playsAppService.GameResultFormat(data);

                return Ok(gameResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
