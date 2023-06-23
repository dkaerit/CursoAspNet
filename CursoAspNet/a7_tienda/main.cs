using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class MainClass {
        public static void Main(string[] args)
        {
            Cliente juan = new Cliente("00000000A","Juan", "jglez@gmail.com", "Calle A, Nolandia");
            Cliente maria = new Cliente("11111111B", "María", "mrez@gmail.com", "Calle B, Nolandia", 633001122);
            Cliente pedro = new Cliente("22222222C", "Pedro", "palvez@gmail.com", "Calle C, Nolandia");

            // Creación de las tiendas
            Tienda fruteria = new Tienda("Frutería Rosina");
            Tienda muebles = new Tienda("Muebles Manolo");

            // Productos
            Producto manzanasStock = new Producto("Manzana", 0.5m, 20);// manzanas x20
            Producto perasStock = new Producto("Pera", 0.6m, 15); // Peras x15
            Producto sillasStock = new Producto("Silla", 37.39m, 25); // Sillas x25
            Producto armarioStock = new Producto("Armario", 88.99m, 50); // Armarios x50


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
            CarritoCompras carritoJuan = new CarritoCompras(juan);
            CarritoCompras carritoMaria = new CarritoCompras(maria);
            CarritoCompras carritoPedro = new CarritoCompras(pedro);

            // Configurar carritos
            Console.WriteLine("## ------ Pedidos ------ : \n");
            carritoJuan.AgregarProducto(manzanasStock, 4); // juan: +4 manzanas
            carritoJuan.AgregarProducto(perasStock, 7); // juan: +7 manzanas
            carritoMaria.AgregarProducto(perasStock, 10); // maria: +10 peras
            carritoMaria.AgregarProducto(perasStock, 5); // maria: +5 peras
            carritoPedro.AgregarProducto(armarioStock, 1); // pedro: +1 armario
            carritoPedro.AgregarProducto(sillasStock, 4); // pedro: +4 sillas

            // Hacer Pedidos
            fruteria.RealizarPedido(carritoJuan.formatoPedido());
            fruteria.RealizarPedido(carritoMaria.formatoPedido());
            muebles.RealizarPedido(carritoPedro.formatoPedido());
        }
    }
}