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
        public async Task<IActionResult> Post(PlaysResultDTO dto)
        {
            try
            {
                var data = await _playsResultAppService.CreateAsync(dto);
                var gameplayResult = await _playsResultAppService.GameResultFormat(data);

                return Ok(gameplayResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
