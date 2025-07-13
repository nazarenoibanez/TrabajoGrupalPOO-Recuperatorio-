using Kiosco.Entidades;
using Kiosco.Servicio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Servicio.ServicioWindows
{
    public interface IServicioProductos
    {
        ValidationResultDto Agregar(Producto producto);
        ValidationResultDto Editar(Producto producto);
        ValidationResultDto Eliminar(string codigo);
        Producto? ObtenerProductoPorCodigo(string codigo);
        List<Producto> ObtenerTodos(string? tipoProducto = null);
    }
}
