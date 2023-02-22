using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportWheelOfFate.Repositories;

namespace SupportWheelOfFate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaRepository rotaRepository;

        public RotaController(IRotaRepository rotaRepository)
        {
            this.rotaRepository = rotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRota()
        {
            var rota = await rotaRepository.CreateRotaFullRandom();

            return Ok(rota);
        }
    }
}
