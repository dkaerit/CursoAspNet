using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Tienda
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////

        private string nombre_;
        private List<Pedido> pedidos_ = new List<Pedido>();

        public List<Producto> inventario_ = new List<Producto>();

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTIRES                //
        //                                             //
        /////////////////////////////////////////////////

        public Tienda(string nombre)
        {
            this.nombre_ = nombre;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////

        // Agrega un producto al inventario de la tienda
        public void AgregarProducto(Producto producto)
        {
            inventario_.Add(producto);
        }

        // Remueve un producto del inventario de la tienda
        public void RemoverProducto(Producto producto)
        {
            inventario_.Remove(producto);
        }

        // Realiza un pedido de productos (devuelve el precio total)
        public decimal RealizarPedido(Pedido pedido)
        {
            pedidos_.Add(pedido);
            pedido.ConfirmarPedido();
            pedido.MostrarPedido();
            return pedido.CalcularTotal();
        }

        // Obtiene la cantidad de productos en inventario
        public int ObtenerCantidadProductosEnInventario()
        {
            return inventario_.Count;
        }

        // Muestra el inventario de la tienda
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de la tienda:");
            foreach (Producto producto in inventario_)
            {
                Console.WriteLine($"- {producto.nombre_}, Precio: {producto.precio_}, Stock: {producto.stock_}");
            }
        }

        private bool VerificarDisponibilidadProductos(Pedido pedido)
        {
            foreach (var productoCantidad in pedido.carrito_.productosCantidad_) // Dictionary<Producto, int>
            {
                // producto del pedido y cantidad del pedido
                Producto productoPedido = productoCantidad.Key;
                int cantidadPedido = productoCantidad.Value;

                // producto de la tienda
                Producto? productoTienda = inventario_.Find(p => p.nombre_ == productoPedido.nombre_);

                // si producto no existe en inventario_
                if (productoTienda == null)
                    return false;
                
                // si el stock del producto en tienda es menor que la cantidad que se está pidiendo
                if (productoTienda.stock_ < cantidadPedido)
                    return false;
            }

            return true;
        }

        // Muestra la información de la tienda y su inventario
        public void MostrarInformacion()
        {
            Console.WriteLine($"Tienda: {nombre_}");
            MostrarInventario();
            Console.WriteLine();
        }

        // Muestra los pedidos realizados por los clientes
        public void MostrarPedidosClientes()
        {
            Console.WriteLine($"Pedidos realizados en la tienda {nombre_}:");
            foreach (Pedido pedido in pedidos_)
            {
                Cliente cliente = pedido.carrito_.cliente_;
                Console.WriteLine($"Cliente: {cliente.nombre_}");
                Console.WriteLine(pedido.carrito_.MostrarCarrito());
                Console.WriteLine($"Total: {pedido.CalcularTotal()}");
                Console.WriteLine();
            }
        }
    }
}
