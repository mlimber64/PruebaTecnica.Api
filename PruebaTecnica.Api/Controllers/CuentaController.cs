using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Service;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCuentas()
        {
            var cuentas = await _cuentaService.GetCuentaAsync();
            return Ok(cuentas);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCuenta([FromBody] Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCuenta = await _cuentaService.CrearCuentaAsync(cuenta);
            return CreatedAtAction(nameof(ListarCuentas), new { id = newCuenta.CuentaId }, newCuenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCuenta(int id, [FromBody] Cuenta cuenta)
        {
            if(id != cuenta.CuentaId)
            {
                return BadRequest();
            }

            var actualizado = await _cuentaService.ActualizarCuentaAsync(cuenta);
            if (!actualizado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCuenta(int id)
        {
            var eliminado = await _cuentaService.EliminarCuentaAsync(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }

        //Reportes

        [HttpGet("reportes")]
        public async Task<IActionResult> ReporteEstadoCuentaAsync([FromQuery] int clienteId, [FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin, int idPersona)
        {
            try
            {
                var reporte = await _cuentaService.GenerarReporteEstadoCuentaAsync(clienteId, fechaInicio, fechaFin,idPersona);
                return Ok(reporte);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error al generar el reporte.", detalle = ex.Message });
            }
        }
    }
}
