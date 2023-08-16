using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpreadLayers.Application.DTOs;
using SpreadLayers.Application.Interfaces;

namespace SpreadLayers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet(Name = "GetEmpresasCadastradas")]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetEmmpresasCadastradas()
        {
            var empresas = await _empresaService.GetEmpresasCadastradasAsync();
            return Ok(empresas);
        }

        [HttpPost(Name = "CreateEmpresa")]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            await _empresaService.CadastraEmpresaAsync(empresaDTO);

            return new CreatedAtRouteResult("GetEmpresasCadastradas", new { id = empresaDTO.Id },
                empresaDTO);
        }
    }
}