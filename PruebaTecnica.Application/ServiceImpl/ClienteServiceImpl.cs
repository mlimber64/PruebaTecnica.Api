using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Service;
using PruebaTecnica.Domain.Datos;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.ServiceImpl
{
    public class ClienteServiceImpl : IClienteService
    {

        private readonly ConexionDBContext _context;
        public ClienteServiceImpl(ConexionDBContext context)
        {
            _context = context;

        }

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            _context.cliente.Update(cliente);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            _context.cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> EliminarClienteAsync(int id)
        {
            var clientes = await _context.cliente.FindAsync(id);
            if(clientes != null)
            {
                _context.cliente.Remove(clientes);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.cliente.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.cliente.ToListAsync();
        }
    }
}
