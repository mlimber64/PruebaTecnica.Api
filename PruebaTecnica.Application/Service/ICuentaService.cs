using PruebaTecnica.Domain.Dtos;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Service
{
    public interface ICuentaService
    {
        Task<IEnumerable<Cuenta>> GetCuentaAsync();

        Task<Cuenta> GetCuentaByIdAsync(int id);

        Task<Cuenta> CrearCuentaAsync(Cuenta cuenta);

        Task<bool> ActualizarCuentaAsync(Cuenta cuenta);

        Task<bool> EliminarCuentaAsync(int id);

        //Reporte estado de cuenta

        Task<ReporteEstadoCuentaDto> GenerarReporteEstadoCuentaAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin, int personaId);
    }
}
