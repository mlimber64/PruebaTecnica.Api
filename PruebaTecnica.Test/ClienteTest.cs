using Xunit;
using PruebaTecnica.Domain.Entities;
using FluentAssertions;

namespace PruebaTecnica.Test
{
    public class ClienteTest
    {
        [Fact]
        public void TestClientesAdd_Code200()
        {
            
            var clienteId = 1;
            var personaId = 1;
            var contrasena = "1234";
            var estado = true;

            
            var cliente = new Cliente
            {
                ClienteId = clienteId,
                PersonaId = personaId,
                Contrasena = contrasena,
                Estado = estado
            };

            
            cliente.ClienteId.Should().Be(clienteId);
            cliente.PersonaId.Should().Be(personaId);
            cliente.Contrasena.Should().Be(contrasena);
            cliente.Estado.Should().Be(estado);

        }
    }
}