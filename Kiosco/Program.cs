using Kiosco.Datos.RepoConsola;
using Kiosco.Entidades;
using Kiosco.Ioc;
using Kiosco.Servicio.ServicioConsola;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kiosco.Consola
{
    internal class Program
    {
        private static IServiceProvider? serviceProvider;
        private static IServicioProductos? servicioProductos;

        static void Main(string[] args)
        {
            serviceProvider = DI.Configurar();
            servicioProductos = serviceProvider.GetRequiredService<IServicioProductos>();

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("== KIOSCO ==");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Editar producto");
                Console.WriteLine("5. Listar por tipo");
                Console.WriteLine("6. Listar todos");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: Agregar(); break;
                    case 2: BuscarPorCodigo(); break;
                    case 3: Eliminar(); break;
                    case 4: Editar(); break;
                    case 5: ListarPorTipo(); break;
                    case 6: Listar(); break;
                    case 0: Console.WriteLine("Saliendo..."); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 0);
        }

        

        private static void Agregar()
        {
            Console.Write("Código: ");
            string? codigo = Console.ReadLine();
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Precio Base: ");
            decimal precio = decimal.Parse(Console.ReadLine()!);
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Fecha de ingreso: ");
            DateTime fi = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Fecha de vencimiento: ");
            DateTime fv = DateTime.Parse(Console.ReadLine()!);
            if (fi > fv)
            {
                Console.WriteLine("La fecha de ingreso no puede ser posterior a la fecha de vencimiento.");
                return;
            }
            Console.Write("Tipo: 1-Bebida 2-Golosina 3-Cigarillo 4-Revista: ");
            int tipo = int.Parse(Console.ReadLine()!);
            Producto nuevoProducto;
            switch (tipo)
            {
                case 1:
                    Console.Write("¿Es alcohólica? (s/n): ");
                    bool alcohol = Console.ReadLine().ToLower() == "s";
                    nuevoProducto = new Bebida { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, EsAlcoholica = alcohol };
                    break;
                case 2:
                    nuevoProducto = new Golosina { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, fechaDeVencimiento = fv };
                    break;
                case 3:
                    Console.Write("¿Es importado? (s/n): ");
                    bool imp = Console.ReadLine().ToLower() == "s";
                    nuevoProducto = new Cigarrillo { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, esImportado = imp };
                    break;
                case 4:
                    Console.WriteLine("¿Tiene poster? (s/n): ");
                    bool post = Console.ReadLine().ToLower() == "s";
                    nuevoProducto = new Revista { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, TienePoster = post };
                    break;
                default: return;
            }
            var resultado = servicioProductos.Agregar(nuevoProducto);
            if (resultado.EsValido)
            {
                Console.WriteLine("Producto agregado.");

            }
            else
            {
                foreach (var error in resultado.Errores)
                {
                    Console.WriteLine(error);
                }
            }
        }

        static void Listar()
        {
            Console.Clear();
            Console.WriteLine("Listado de Productos (Datos Básicos)");
            foreach (var item in servicioProductos!.ObtenerTodos())
            {
                Console.WriteLine(item.InformarDatos());
            }
        }

        static void BuscarPorCodigo()
        {
            Console.Write("Buscar por código: ");
            string? codigo = Console.ReadLine();
            var producto = servicioProductos!.ObtenerProductoPorCodigo(codigo);
            if (producto is null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            else
            {
                MostrarDatos(producto);
            }
        }
        static void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar un Producto");
            Listar();
            Console.Write("Ingrese código de producto a eliminar:");
            string codigo = Console.ReadLine()!;
            var resultado = servicioProductos.Eliminar(codigo);
            if (resultado.EsValido)
            {
                Console.WriteLine("Producto eliminado.");
            }
            else
            {
                foreach (var error in resultado.Errores)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private static void ListarPorTipo()
        {
            throw new NotImplementedException();
        }
        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Editar un Producto");
            Listar();
            Console.Write("Ingrese código de producto a editar:");
            string codigo = Console.ReadLine();
            var producto = servicioProductos.ObtenerProductoPorCodigo(codigo);
            if (producto is null)
            {
                Console.WriteLine("Código no encontrado");
                return;
            }
            MostrarDatos(producto);
            Console.Write("\nNombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Precio Base: ");
            decimal precio = decimal.Parse(Console.ReadLine()!);
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Fecha de ingreso: ");
            DateTime fi = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Fecha de vencimiento: ");
            DateTime fv = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Tipo: 1-Bebida 2-Golosina 3-Cigarillo 4-Revista");
            int tipo = int.Parse(Console.ReadLine()!);

            switch (tipo)
            {
                case 1:
                    Console.Write("¿Es alcohólica? (s/n): ");
                    bool alcohol = Console.ReadLine().ToLower() == "s";
                    producto = new Bebida { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, EsAlcoholica = alcohol };
                    break;
                case 2:
                    producto = new Golosina { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, fechaDeVencimiento = fv };
                    break;
                case 3:
                    Console.Write("¿Es importado? (s/n): ");
                    bool imp = Console.ReadLine().ToLower() == "s";
                    producto = new Cigarrillo { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, esImportado = imp };
                    break;
                case 4:
                    Console.WriteLine("¿Tiene poster? (s/n): ");
                    bool post = Console.ReadLine().ToLower() == "s";
                    producto = new Revista { codigo = codigo, Nombre = nombre, PrecioBase = precio, Stock = stock, TienePoster = post };
                    break;
                default: return;
            }
            var resultado = servicioProductos.Editar(producto);
            if (resultado.EsValido)
            {
                Console.WriteLine("Producto editado.");

            }
            else
            {
                foreach (var error in resultado.Errores)
                {
                    Console.WriteLine(error);
                }
            }
        }

        private static void MostrarDatos(Producto producto)
        {
            Console.WriteLine("Datos del Producto");
            Console.WriteLine($"Código: {producto.codigo}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.PrecioBase}");
            Console.WriteLine($"Stock: {producto.Stock}");
            Console.WriteLine($"Fecha de ingreso: {producto.fechaDeingreso}");
            Console.WriteLine($"Fecha de vencimiento: {producto.fechaDeVencimiento}");
            if (producto is Bebida)
            {
                Console.WriteLine($"Es Alcohólica?:{(((Bebida)producto).EsAlcoholica ? "Si" : "No")}");
            }
            else if (producto is Cigarrillo)
            {
                Console.WriteLine($"Es importado?:{(((Cigarrillo)producto).esImportado ? "Si" : "No")}");

            }
            else if (producto is Revista)
            {
                Console.WriteLine($"Tiene poster?:{(((Revista)producto).TienePoster ? "Si" : "No")}");
            }
        }
        
    }
}
