using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Domain.Datos;

namespace PruebaTecnica.Test
{
    public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(ConexionDBContext));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                
                services.AddDbContext<ConexionDBContext>(options =>
                {
                    options.UseInMemoryDatabase("MemoryDbTest");
                });
            });
        }
    }
}
