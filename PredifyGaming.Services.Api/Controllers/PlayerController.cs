using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;

namespace PredifyGaming.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayersAppService _appService;

        public PlayerController(IPlayersAppService playerAppService)
        {
            _appService = playerAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayersDTO dto)
        {
            try
            {
                var data = await _appService.CreateAsync(dto);
                return Ok($@"Conta criada com sucesso ID:{data.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
