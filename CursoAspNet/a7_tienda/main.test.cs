using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Test
    {
        public static void Exec() {
            Cliente juan = new("00000000A", "Juan", "jglez@gmail.com", "Calle A, Nolandia");
            Cliente maria = new("11111111B", "María", "mrez@gmail.com", "Calle B, Nolandia", "633001122");
            Cliente pedro = new("22222222C", "Pedro", "palvez@gmail.com", "Calle C, Nolandia");
            Cliente ernesto = new();
            ernesto.SetValues("33333333D", "611001122");
            ernesto.Nombre_ = "Ernesto";
            ernesto.Email_ = "ergrez@gmail.com";
            ernesto.Direccion_ = "Calle D, Nolandia";

            // info clientes
            Console.WriteLine("## ------ Clientes ------ : \n");
            Console.WriteLine(juan.ToString() + "\n");
            Console.WriteLine(maria.ToString() + "\n");
            Console.WriteLine(pedro.ToString() + "\n");
            Console.WriteLine(ernesto.ToString() + "\n");

            // Creación de las tiendas
            Tienda fruteria = new("Frutería Rosina");
            Tienda muebles = new("Muebles Manolo");

            // Productos
            Producto manzanasStock = new("Manzana", 0.5m, 20);// manzanas x20
            Producto perasStock = new("Pera", 0.6m, 15); // Peras x15
            Producto sillasStock = new("Silla", 37.39m, 25); // Sillas x25
            Producto armarioStock = new("Armario", 88.99m, 50); // Armarios x50


            // Agregar productos al inventario de las tiendas
            fruteria.AgregarProducto(manzanasStock);
            fruteria.AgregarProducto(perasStock);
            muebles.AgregarProducto(sillasStock);
            muebles.AgregarProducto(armarioStock);

            // Info tiendas
            Console.WriteLine("## ------ Tiendas (inventarios) ------ : \n");
            fruteria.MostrarInformacion();
            muebles.MostrarInformacion();

            // Carritos
            CarritoCompras carritoJuan = new(juan);
            CarritoCompras carritoMaria = new(maria);
            CarritoCompras carritoPedro = new(pedro);

            // Configurar carritos
            Console.WriteLine("## ------ Pedidos ------ : \n");
            carritoJuan.AgregarProducto(manzanasStock, 4); // juan: +4 manzanas
            carritoJuan.AgregarProducto(perasStock, 7); // juan: +7 manzanas
            carritoMaria.AgregarProducto(perasStock, 10); // maria: +10 peras
            carritoMaria.AgregarProducto(perasStock, 5); // maria: +5 peras
            carritoPedro.AgregarProducto(armarioStock, 1); // pedro: +1 armario
            carritoPedro.AgregarProducto(sillasStock, 4); // pedro: +4 sillas

            // Hacer Pedidos
            fruteria.RealizarPedido(carritoJuan.FormatoPedido());
            fruteria.RealizarPedido(carritoMaria.FormatoPedido());
            muebles.RealizarPedido(carritoPedro.FormatoPedido());
        }
    }
}
