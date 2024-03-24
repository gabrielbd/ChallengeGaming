using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PredifyGaming.Application.Commands.Players;
using PredifyGaming.Application.Interfaces;
using PredifyGaming.Domain.Entities;

namespace PredifyGaming.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayersAppService _appService;

        public PlayerController(IPlayersAppService playerAppService, IMapper mapper)
        {
            _appService = playerAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePlayerCommand command)
        {
            try
            {
                var data = await _appService.CreatePlayerAsync(command);
                return Ok($@"Conta criada com sucesso ID:{data.IdPlayer}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
