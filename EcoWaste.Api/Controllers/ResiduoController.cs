using EcoWaste.Business.Interfaces;
using EcoWaste.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoWaste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResiduosController : ControllerBase
    {
        private readonly IResiduoService _residuoService;

        public ResiduosController(IResiduoService residuoService)
        {
            _residuoService = residuoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResiduoDto>>> GetAll(int page = 1, int pageSize = 10)
        {
            var residuos = await _residuoService.ListarTodosAsync(page, pageSize);
            return Ok(residuos);
        }
    }
}