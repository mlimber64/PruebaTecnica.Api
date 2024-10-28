using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Service
{
    public interface IMovimientoService
    {
        Task<IEnumerable<Movimiento>> GetMovimientoAsync();

        Task<Movimiento> GetMovimientoByIdAsync(int id);

        Task<Movimiento> CrearMovimientoAsync(Movimiento movimiento);

        Task<bool> ActualizarMovimientoAsync(Movimiento movimiento);

        Task<bool> EliminarMovimiento(int id);
    }
}
