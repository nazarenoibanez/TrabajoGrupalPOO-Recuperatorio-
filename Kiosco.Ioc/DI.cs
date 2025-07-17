using Kiosco.Datos;
using Kiosco.Datos.RepoConsola;
using Kiosco.Servicio;
using Kiosco.Servicio.ServicioConsola;
using Microsoft.Extensions.DependencyInjection;

namespace Kiosco.Ioc
{
    public static class DI
    {
        public static IServiceProvider Configurar()
        {
            var servicios = new ServiceCollection();

            servicios.AddScoped<IRepositorioProductos, RepositorioProductosLinq>();
            servicios.AddScoped<IServicioProductos, ServicioProductos>();

            return servicios.BuildServiceProvider();
        }
    }
}