using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Excepciones;
using PruebaTecnica.Application.Service;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarMovimiento()
        {
            var movimientos = await _movimientoService.GetMovimientoAsync();
            return Ok(movimientos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMovimientos([FromBody] Movimiento movimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newMovimiento = await _movimientoService.CrearMovimientoAsync(movimiento);
                return CreatedAtAction(nameof(ListarMovimiento), new { id = newMovimiento.MovimientoId }, newMovimiento);
            }
            catch (SaldoInsuficienteException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMovimiento(int id, [FromBody] Movimiento movimiento)
        {
            if(id != movimiento.MovimientoId)
            {
                return BadRequest();
            }

            var actualizado = await _movimientoService.ActualizarMovimientoAsync(movimiento);
            if (!actualizado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMovimiento(int id)
        {
            var eliminado = await _movimientoService.EliminarMovimiento(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
