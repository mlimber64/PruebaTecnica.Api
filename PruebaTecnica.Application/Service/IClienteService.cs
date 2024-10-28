using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Service
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();

        Task<Cliente> GetClienteByIdAsync(int id);

        Task<Cliente> CrearClienteAsync(Cliente cliente);

        Task<bool> ActualizarClienteAsync(Cliente cliente);

        Task<bool> EliminarClienteAsync(int id);
    }
}
