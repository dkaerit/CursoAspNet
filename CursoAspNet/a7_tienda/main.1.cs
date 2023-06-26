using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Interactivo
    {
        // Tiendas
        private static Dictionary<int, Tienda> tiendas = new Dictionary<int, Tienda>()
        {
            { 1, new Tienda("Frutería Rosina") },
            { 2, new Tienda("Muebles Manolo") }
        };

        // Productos
        private static Dictionary<int, Producto> productos = new Dictionary<int, Producto>()
        {
            { 1, new Producto("Manzana", 0.5m, 20) },
            { 2, new Producto("Pera", 0.6m, 15) },
            { 3, new Producto("Silla", 37.39m, 25) },
            { 4, new Producto("Armario", 88.99m, 50) }
        };

        public static void exec() {
            Console.WriteLine("Bienvenido al modo interactivo.");

            // SELECCIONAR TIENDA
            Console.WriteLine("Seleccione una tienda:");
            foreach (var tienda in tiendas)
                Console.WriteLine($"{tienda.Key}. {tienda.Value.Nombre_}");

            Console.Write(">> ");
            int.TryParse(Console.ReadLine(), out int ti);
            Console.WriteLine("");
            Tienda tiendaEleccion = tiendas[ti];

            // INRODUCE TUS DATOS DE CLIENTE
            Console.WriteLine("Introduce tus datos de cliente:");
            Console.Write("DNI: ");
            string? dni = Console.ReadLine();
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();
            Console.Write("Email: ");
            string? email = Console.ReadLine();
            Console.Write("Dirección: ");
            string? direccion = Console.ReadLine();

            Cliente cliente = new(dni, nombre, email, direccion);

            // GESTIONA TU CARRITO
            CarritoCompras carrito = new(cliente);

            while (true)
            {
                Console.WriteLine("\nSeleccione un producto para agregar al carrito:");
                foreach (var producto in productos)
                    Console.WriteLine($"{producto.Key}. {producto.Value.Nombre_}");

                Console.Write(">> ");
                int.TryParse(Console.ReadLine(), out int productoSeleccionado);

                Console.Write("Cantidad: ");
                int.TryParse(Console.ReadLine(), out int cantidad);

                Producto productoElegido = productos[productoSeleccionado];
                carrito.AgregarProducto(productoElegido, cantidad);

                Console.Write("¿Desea agregar otro producto? (S/N): ");
                string? respuesta = Console.ReadLine();

                if (respuesta.ToUpper() == "N")
                    break;
            }

            // ¿CONFIRMAS?
            Console.Write("¿Desea confirmar el pedido? (S/N): ");
            string? confirmacion = Console.ReadLine();

            Pedido pedido = carrito.FormatoPedido();
            if (confirmacion.ToUpper() == "S")
            {
                pedido.ConfirmarPedido();
                tiendaEleccion.RealizarPedido(pedido);
                Console.WriteLine("\nPedido realizado con éxito. Aquí está la factura:");
                pedido.Factura();
            }
            else
                Console.WriteLine("\nPedido cancelado.");
        }
    }
}
