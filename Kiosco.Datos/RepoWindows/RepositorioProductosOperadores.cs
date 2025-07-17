using Kiosco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosco.Datos.RepoWindows
{
    public class RepositorioProductosOperadores : IRepositorioProductos
    {
        private List<Producto> productos;

        public RepositorioProductosOperadores()
        {
            productos = new List<Producto>();
        }


        public void Agregar(Producto nuevoProducto)
        {
            RepositorioProductosOperadores resultado = this + nuevoProducto;
            productos = resultado.productos; 
        }

        public void Eliminar(string codigoProducto)
        {
            RepositorioProductosOperadores resultado = this - codigoProducto;
            productos = resultado.productos; 
        }

        public void Editar(Producto productoActualizado)
        {
            if (productoActualizado == null)
            {
                throw new ArgumentNullException(nameof(productoActualizado), "El producto a editar no puede ser nulo.");
            }

            var productoExistente = this[productoActualizado.codigo];
            if (productoExistente != null)
            {
                int index = productos.IndexOf(productoExistente);
                if (index != -1)
                {
                    productos[index] = productoActualizado; 
                }
            }
        }


        public Producto? ObtenerPorCodigo(string codigo)
        {
            return this[codigo];
        }

        public bool Existe(string codigo)
        {
            return this == codigo; 
        }


        public static RepositorioProductosOperadores operator +(RepositorioProductosOperadores repositorio, Producto nuevoProducto)
        {
            if (repositorio is null)
            {
                throw new ArgumentNullException(nameof(repositorio), "El repositorio no puede ser nulo.");
            }
            if (nuevoProducto == null)
            {
                throw new ArgumentNullException(nameof(nuevoProducto), "El producto a agregar no puede ser nulo.");
            }

            if (!(repositorio == nuevoProducto.codigo))
            {
                repositorio.productos.Add(nuevoProducto);
            }
            return repositorio;
        }

        public static RepositorioProductosOperadores operator -(RepositorioProductosOperadores repositorio, string codigoProducto)
        {
            if (repositorio is null)
            {
                throw new ArgumentNullException(nameof(repositorio), "El repositorio no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(codigoProducto))
            {
                throw new ArgumentException("El código del producto no puede ser nulo o vacío.", nameof(codigoProducto));
            }

            var productoAEliminar = repositorio[codigoProducto]; 
            if (productoAEliminar != null)
            {
                repositorio.productos.Remove(productoAEliminar);
            }
            return repositorio;
        }

        public static bool operator ==(RepositorioProductosOperadores repositorio, string codigoProducto)
        {
            if (repositorio is null)
            {
                return string.IsNullOrWhiteSpace(codigoProducto);
            }
            if (string.IsNullOrWhiteSpace(codigoProducto))
            {
                return false;
            }
            return repositorio.productos.Any(p => p.codigo == codigoProducto);
        }

        public static bool operator !=(RepositorioProductosOperadores repositorio, string codigoProducto)
        {
            return !(repositorio == codigoProducto);
        }
        public Producto? this[string codigo]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException(nameof(codigo));
                Producto? producto = productos.FirstOrDefault(p => p.codigo == codigo);
                return producto;
            }
        }

        public Producto this[int index]
        {
            get
            {
                if (index < 0 || index >= productos.Count)
                {
                    throw new IndexOutOfRangeException("Índice fuera de los límites del arreglo.");
                }
                return productos[index];
            }
            set
            {
                if (index < 0 || index >= productos.Count)
                {
                    throw new IndexOutOfRangeException("Índice fuera de los límites del arreglo.");
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "El producto no puede ser nulo.");
                }
                productos[index] = value;
            }
        }

        public List<Producto> ObtenerTodos(string? tipoProducto = null)
        {
            IQueryable<Producto> query = productos.AsQueryable();
            switch (tipoProducto)
            {
                case "Cigarrillo":
                    return query.Where(p => p.GetType() == typeof(Cigarrillo)).ToList();
                case "Golosina":
                    return query.Where(p => p.GetType() == typeof(Golosina)).ToList();
                case "Bebida":
                    return query.Where(p => p.GetType() == typeof(Bebida)).ToList();
                case "Revista":
                    return query.Where(p => p.GetType() == typeof(Revista)).ToList();

                default:
                    return query.ToList();
            }

        }

        public int Count
        {
            get { return productos.Count; }
        }

        public override bool Equals(object? obj) 
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            RepositorioProductosOperadores other = (RepositorioProductosOperadores)obj;

            if (this.productos.Count != other.productos.Count)
            {
                return false;
            }

            for (int i = 0; i < this.productos.Count; i++)
            {
                if (!this.productos[i].Equals(other.productos[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var producto in productos)
                {
                    hash = hash * 23 + (producto != null ? producto.GetHashCode() : 0);
                }
                return hash;
            }
        }
    }
}
