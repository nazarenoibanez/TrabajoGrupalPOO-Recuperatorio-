using Kiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Datos.RepoWindows
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Eliminar(string codigo);
        void Editar(Producto producto);
        Producto? ObtenerPorCodigo(string codigo);
        bool Existe(string codigo);
        List<Producto> ObtenerTodos(string? tipoProducto = null);
    }
}
