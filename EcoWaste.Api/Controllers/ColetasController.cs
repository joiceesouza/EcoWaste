using EcoWaste.Business.Interfaces;
using EcoWaste.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcoWaste.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColetasController : ControllerBase
    {
        private readonly IColetaService _coletaService;

        public ColetasController(IColetaService coletaService)
        {
            _coletaService = coletaService;
        }

        /// <summary>
        /// Registra uma nova coleta de resíduo
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] CreateColetaDto dto)
        {
            int usuarioId = 1;

            var coleta = await _coletaService.RegistrarAsync(dto, usuarioId);
            return Ok(coleta);
        }

        /// <summary>
        /// Lista coletas com paginação
        /// </summary>
       [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] PaginacaoDTO paginacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coletas = await _coletaService.ListarAsync(paginacao);
            return Ok(coletas);
        }
        /// <summary>
        /// Obtém coletas filtradas por tipo de resíduo
        /// </summary>
        [HttpGet("por-tipo")]
        public async Task<IActionResult> ObterPorTipo([FromQuery] string tipo)
        {
            var coletas = await _coletaService.ObterPorTipoResiduoAsync(tipo);
            return Ok(coletas);
        }

        [HttpGet("erro-teste")]
        public IActionResult ForcarErro()
        {
            throw new Exception("Este é um erro de teste!");
        }
    }
}