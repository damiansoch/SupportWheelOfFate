using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportWheelOfFate.Repositories;

namespace SupportWheelOfFate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerRepository engineerRepository;

        public EngineerController(IEngineerRepository engineerRepository)
        {
            this.engineerRepository = engineerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allEngineers = await engineerRepository.GetAllAsync();
            return Ok(allEngineers);
        }
    }
}
