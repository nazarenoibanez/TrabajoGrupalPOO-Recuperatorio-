using Kiosco.Entidades;

namespace Kiosco.Datos.RepoConsola
{
    public class RepositorioProductosLinq : IRepositorioProductos
    {
        private List<Producto> productos = new();
        public RepositorioProductosLinq()
        {
            productos = new List<Producto>
            {
            new Revista { codigo = "A1001", Nombre = "La Nación", PrecioBase = 450, Stock = 50 },
            new Bebida { codigo = "A1002", Nombre = "Leche entera", PrecioBase = 600, Stock = 30, EsAlcoholica = false },
            new Bebida { codigo = "B2001", Nombre = "Agua mineral", PrecioBase = 350, Stock = 100, EsAlcoholica = false },
            new Bebida { codigo = "B2002", Nombre = "Vino tinto", PrecioBase = 1200, Stock = 20, EsAlcoholica = true },
            new Revista { codigo = "L3001", Nombre = "Clarín", PrecioBase = 300, Stock = 40 },
            new Cigarrillo { codigo = "L3002", Nombre = "Laramie", PrecioBase = 500, Stock = 25 },
            new Golosina { codigo = "A1003", Nombre = "Caramelo", PrecioBase = 15, Stock = 15 }          
            };
           }
        public Producto? this[string codigo]
        {
            get
            {
                return productos.FirstOrDefault(p => p.codigo == codigo);
            }
        }
        public void Agregar(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            if (string.IsNullOrWhiteSpace(producto.codigo))
                throw new ArgumentException("El código del producto no puede estar vacío.");

            if (ObtenerPorCodigo(producto.codigo) == null)
            {
                productos.Add(producto);
            }
            else
            {
                throw new InvalidOperationException("El producto ya existe con ese código.");
            }
        }

        public void Editar(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            if (string.IsNullOrWhiteSpace(producto.codigo))
                throw new ArgumentException("El código del producto no puede estar vacío.");

            var existente = ObtenerPorCodigo(producto.codigo);
            if (existente != null)
            {
                int index = productos.FindIndex(p => p.codigo == producto.codigo);
                if (index >= 0)
                    productos[index] = producto;
                else
                    throw new InvalidOperationException("No se pudo ubicar el producto en la lista.");
            }
            else
            {
                throw new InvalidOperationException("No se encontró el producto para editar.");
            }
        }

        public void Eliminar(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código no puede estar vacío.", nameof(codigo));

            var productoAEliminar = ObtenerPorCodigo(codigo);
            if (productoAEliminar != null)
            {
                productos.RemoveAll(p => p.codigo == codigo);
            }
            else
            {
                throw new InvalidOperationException("Producto no encontrado para eliminar.");
            }
        }

        public bool Existe(string codigo) => this[codigo] != null;

        public Producto? ObtenerPorCodigo(string codigo) => this[codigo];

        public List<Producto> ObtenerTodos() => productos;
    }
}
