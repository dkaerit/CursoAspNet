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

        private readonly string nombre_;
        private readonly List<Pedido> pedidos_ = new();
        public List<Producto> inventario_ = new();

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
        public decimal RealizarPedido(Pedido pedido) {
        
            if(VerificarDisponibilidadProductos(pedido)) {
                pedidos_.Add(pedido);
                pedido.ConfirmarPedido();
                pedido.MostrarPedido();
                return pedido.CalcularTotal();
            }

            return 0.00m;
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
                Console.WriteLine($"- {producto.Nombre_}, Precio: {producto.Precio_}, Stock: {producto.Stock_}");
        }

        private bool VerificarDisponibilidadProductos(Pedido pedido)
        {
            foreach (var productoCantidad in pedido.carrito_.productosCantidad_) 
            {
                // producto del pedido y cantidad del pedido
                Producto productoPedido = productoCantidad.Key;
                int cantidadPedido = productoCantidad.Value;

                // producto de la tienda
                Producto? productoTienda = inventario_.Find(p => p.Nombre_ == productoPedido.Nombre_);

                // si producto no existe en inventario_
                if (productoTienda == null)
                    return false;
                
                // si el stock del producto en tienda es menor que la cantidad que se está pidiendo
                if (productoTienda.Stock_ < cantidadPedido)
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
                Console.WriteLine($"Cliente: {cliente.Nombre_}");
                Console.WriteLine(pedido.carrito_.MostrarCarrito());
                Console.WriteLine($"Total: {pedido.CalcularTotal()}");
                Console.WriteLine();
            }
        }
    }
}
