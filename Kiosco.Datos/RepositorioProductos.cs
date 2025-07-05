using Kiosco.Entidades;

namespace Kiosco.Datos
{
    public class RepositorioProductos
    {
        private List<Producto> productos;
        public static RepositorioProductos? instancia = null;

        public static RepositorioProductos GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioProductos();
            }
            return instancia;
        }
        public Producto this[int index]
        {
            get
            {
                if (index >= 0 && index < productos.Count)
                {
                    return productos[index];
                }
                throw new Exception("Índice fuera de rango.");
            }

            set { productos[index] = value; }
        }
        private RepositorioProductos()
        {
            productos = new List<Producto>();
        }

        public bool Agregar(Producto figura)
        {
            productos.Add(figura);
            return true;
        }
        public bool Eliminar(Producto figura)
        {
            productos.Remove(figura);
            return true;
        }
        public bool BuscarporNombre(string nombre, out Producto producto)
        {
            producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return producto != null;
        }
        public bool BuscarPorTipo(Type tipo, out List<Producto> listaProductos)
        {
            listaProductos = productos.Where(p => p.GetType() == tipo).ToList();
            return listaProductos.Count > 0;
        }
        public bool OrdenarPorPrecioFinal()
        {
            if (productos.Count > 0)
            {
                productos = productos.OrderBy(p => p.calcularPrecioFinal()).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool listarPorStockBajo(int stockMinimo)
        {
            var productosFiltrados = productos.Where(p => p.Stock < stockMinimo).ToList();
            if (productosFiltrados.Count > 0)
            {
                productos = productosFiltrados;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Producto> GetLista()
        {
            return productos;
        }
    }
}
