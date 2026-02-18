using GameTournamentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentService _service;

        public TournamentController(TournamentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }
    }
}
