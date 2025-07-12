using Kiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Datos.RepoConsola
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(string codigo);
        bool Existe(string codigo);
        Producto? ObtenerPorCodigo(string codigo);
        List<Producto> ObtenerTodos();
    }
}
