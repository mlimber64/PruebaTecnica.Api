using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PruebaTecnica.Domain.Datos;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using PruebaTecnica.Api;
using PruebaTecnica.Domain.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace PruebaTecnica.Test
{
    public class ClienteIntegrationTests: IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ClienteIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            SeedDatabase(factory);
        }

        private void SeedDatabase(CustomWebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ConexionDBContext>();
            db.cliente.RemoveRange(db.cliente);
            db.SaveChanges();

            // Agrega datos de prueba
            db.cliente.Add(new Cliente
            {
                ClienteId = 1,
                PersonaId = 1,
                Contrasena = "1234",
                Estado = true
            });
            db.SaveChanges();
        }

        [Fact]
        public async Task ListarClientes_Code200()
        {
            var response = await _client.GetAsync("/api/Cliente");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var clientes = JsonSerializer.Deserialize<IEnumerable<Cliente>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            clientes.Should().NotBeNull();
            clientes.Should().HaveCount(1);
        }
    }
}
