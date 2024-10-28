using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Excepciones;
using PruebaTecnica.Application.Service;
using PruebaTecnica.Domain.Datos;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.ServiceImpl
{
    public class MovimientoServiceImpl : IMovimientoService
    {
        private readonly ConexionDBContext _context;

        public MovimientoServiceImpl(ConexionDBContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarMovimientoAsync(Movimiento movimiento)
        {
            _context.movimiento.Update(movimiento);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Movimiento> CrearMovimientoAsync(Movimiento movimiento)
        {
            
            var cuenta = await _context.cuenta.FindAsync(movimiento.CuentaId);
            if (cuenta == null)
            {
                throw new Exception("La cuenta no existe.");
            }

            
            if (movimiento.TipoMovimiento == "Debito" && cuenta.SaldoInicial < movimiento.Saldo)
            {
                throw new SaldoInsuficienteException();
            }

            
            if (movimiento.TipoMovimiento == "Ahorros")
            {
                cuenta.SaldoInicial -= movimiento.Saldo;
            }
            else if (movimiento.TipoMovimiento == "Corriente")
            {
                cuenta.SaldoInicial += movimiento.Saldo;
            }

            
            _context.movimiento.Add(movimiento);
            await _context.SaveChangesAsync();

            return movimiento;
        }

        public async Task<bool> EliminarMovimiento(int id)
        {
            var movimientos = await _context.movimiento.FindAsync(id);
            if(movimientos != null)
            {
                _context.movimiento.Remove(movimientos);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Movimiento>> GetMovientoAsync()
        {
            return await _context.movimiento.ToListAsync();
        }

        public async Task<Movimiento> GetMovimientoByIdAsync(int id)
        {
            return await _context.movimiento.FindAsync(id);
        }
    }
}
