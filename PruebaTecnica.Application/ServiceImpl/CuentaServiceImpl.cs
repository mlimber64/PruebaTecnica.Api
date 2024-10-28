using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Service;
using PruebaTecnica.Domain.Datos;
using PruebaTecnica.Domain.Dtos;
using PruebaTecnica.Domain.Entities;
using static PruebaTecnica.Domain.Dtos.ReporteEstadoCuentaDto;

namespace PruebaTecnica.Application.ServiceImpl
{
    public class CuentaServiceImpl : ICuentaService
    {
        private readonly ConexionDBContext _context;

        public CuentaServiceImpl(ConexionDBContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarCuentaAsync(Cuenta cuenta)
        {
            _context.cuenta.Update(cuenta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cuenta> CrearCuentaAsync(Cuenta cuenta)
        {
            _context.cuenta.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<bool> EliminarCuentaAsync(int id)
        {
            var cuentas = await _context.cuenta.FindAsync(id);
            if(cuentas != null)
            {
                _context.cuenta.Remove(cuentas);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Cuenta>> GetCuentaAsync()
        {
            return await _context.cuenta.ToListAsync();
        }

        public async Task<Cuenta> GetCuentaByIdAsync(int id)
        {
            return await _context.cuenta.FindAsync(id);
        }

        public async Task<ReporteEstadoCuentaDto> GenerarReporteEstadoCuentaAsync(int clienteId, DateTime fechaInicio, DateTime fechaFin, int personaId)
        {
            var cliente = await _context.cliente.FindAsync(clienteId);
            var persona = await _context.persona.FindAsync(personaId);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado.");
            }

            var cuentas = await _context.cuenta
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();

            var estadoCuenta = new ReporteEstadoCuentaDto
            {
                ClienteId = cliente.ClienteId,
                NombreCliente = persona.Nombre
            };

            foreach (var cuenta in cuentas)
            {
                var movimientos = await _context.movimiento
                    .Where(m => m.CuentaId == cuenta.CuentaId && m.Fecha >= fechaInicio && m.Fecha <= fechaFin)
                    .Select(m => new MovimientoDto
                    {
                        Fecha = m.Fecha,
                        TipoMovimiento = m.TipoMovimiento,
                        Valor = m.Valor, 
                        Saldo = m.Saldo
                    })
                    .ToListAsync();

                var cuentaReporte = new CuentaReporteDto
                {
                    NroCuenta = cuenta.NroCuenta,
                    TipoCuenta = cuenta.TipoCuenta,
                    SaldoInicial = cuenta.SaldoInicial,
                    Movimientos = movimientos
                };

                estadoCuenta.Cuentas.Add(cuentaReporte);
            }

            return estadoCuenta;
        }
    }
}
