using EcoWaste.Business.Interfaces;
using EcoWaste.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoWaste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoColetaController : ControllerBase
    {
        private readonly IPontoColetaService _pontoColetaService;

        public PontoColetaController(IPontoColetaService pontoColetaService)
        {
            _pontoColetaService = pontoColetaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PontoColetaDto>>> GetByCidade([FromQuery] string cidade)
        {
            var pontos = await _pontoColetaService.ListarPorCidadeAsync(cidade);
            return Ok(pontos);
        }
    }
}