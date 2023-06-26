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

        // privados: nombre_ y pedidos_
        private readonly string nombre_;
        private readonly List<Pedido> pedidos_ = new();

        // publicos: Inventario_
        public Dictionary<string, int> Inventario_ = new();

        // getters y setters
        private string Nombre_ { get => nombre_; }
        private List<Pedido> Pedidos_ { get => pedidos_; }

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
            if (Inventario_.ContainsKey(producto.Nombre_))
                Inventario_[producto.Nombre_] += producto.Stock_;
            else
                Inventario_.Add(producto.Nombre_, producto.Stock_);
        }

        // Remueve un producto del inventario de la tienda
        public void RemoverProducto(Producto producto)
        {
            if (Inventario_.ContainsKey(producto.Nombre_))
            {
                // Resta el stock del producto al inventario
                Inventario_[producto.Nombre_] -= producto.Stock_;

                // Si el stock llega a cero o menos, elimina el producto del inventario
                if (Inventario_[producto.Nombre_] <= 0)
                    Inventario_.Remove(producto.Nombre_);
            }
        }

        // Realiza un pedido de productos (devuelve el precio total)
        public decimal RealizarPedido(Pedido pedido) {
            if (VerificarDisponibilidadProductos(pedido)) {
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
            return Inventario_.Count;
        }

        // Muestra el inventario de la tienda
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de la tienda:");
            foreach (var productoStock in Inventario_)
            {
                string nombreProducto = productoStock.Key;
                int stockProducto = productoStock.Value;
                Console.WriteLine($"- {nombreProducto}, Stock: {stockProducto}");
            }
        }

        private bool VerificarDisponibilidadProductos(Pedido pedido)
        {
            // para cada producto en el pedido
            foreach (var productoCantidad in pedido.Carrito_.ProductosCantidad_)
            {
                // cada producto del pedido y su cantidad pedida
                Producto producto = productoCantidad.Key;
                int cantidad = productoCantidad.Value;

                // Si el producto no está disponible en tienda
                if (!Inventario_.ContainsKey(producto.Nombre_))
                    return false;

                // y si el stock del producto en tienda es menor que la cantidad pedida
                if (Inventario_[producto.Nombre_] < cantidad)
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
                Cliente cliente = pedido.Carrito_.cliente_;
                Console.WriteLine($"Cliente: {cliente.Nombre_}");
                Console.WriteLine(pedido.Carrito_.MostrarCarrito());
                Console.WriteLine($"Total: {pedido.CalcularTotal()}");
                Console.WriteLine();
            }
        }
    }
}
