using Code_Challenge.Application.Interface;
using Code_Challenge.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Code_Challenge.Api.Controllers
{
    [ApiController]
    public class MineralController : ControllerBase
    {
        private readonly ISMK186Service _service;
        public MineralController(ISMK186Service service)
        {
            _service = service;
        }

        /// <summary>
        /// Obter lista de minerais.
        /// </summary>
        /// <param name="payload">Criterios de pequisa</param>
        /// <returns>
        /// Lista de quantidade de minerias por semana.
        /// </returns>
        [HttpGet("minerais")]
        public async Task<IActionResult> GetMineraisAsync([FromQuery] DtoMinerais payload)
        {
            var result = await _service.GetMineraisAsync(payload, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
