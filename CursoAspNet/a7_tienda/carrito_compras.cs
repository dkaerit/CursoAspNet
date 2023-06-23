using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class CarritoCompras
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////
        
        // atributos
        public Dictionary<Producto, int> productosCantidad_ = new(); // <producto, cantidad>
        public Cliente cliente_;

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////
      
        // Constructores
        public CarritoCompras(Cliente c) {
            cliente_ = c;
        }

        public CarritoCompras(Producto p, int cantidad, Cliente c)
        {
            productosCantidad_[p] = cantidad;
            cliente_ = c;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////
        
        public void AgregarProducto(Producto producto, int cantidad = 1) { // por defecto añade 1
            if(productosCantidad_.ContainsKey(producto)) // si ya existe en el carrito
                productosCantidad_[producto] += cantidad; // incrementa en 'cantidad'
            else // si no existe
                productosCantidad_.Add(producto, cantidad); // se agrega el producto y su cantidad
        }

        public void RemoverProducto(Producto producto, int cantidad = 1) // por defecto remueve 1
        {
            if (!productosCantidad_.ContainsKey(producto)) // si no existe el rpoducto
                throw new ArgumentException("El producto no está en el carrito.");

            if (cantidad >= productosCantidad_[producto]) // si la cantidad a borrar excede
                productosCantidad_.Remove(producto);

            else // en cualquier otro caso
                productosCantidad_[producto] -= cantidad;
        }

        public void VaciarCarrito()
        {
            if (productosCantidad_.Count > 0)
                productosCantidad_.Clear();
        }

        public Pedido FormatoPedido() {
            return new Pedido(this);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            // Calcular el total sumando los precios de todos los productos * cantidad
            foreach (var productoCantidad in productosCantidad_)
            {
                Producto producto = productoCantidad.Key;
                int cantidad = productoCantidad.Value;
                total += producto.Precio_ * cantidad;
            }

            return total;
        }

        public string MostrarCarrito()
        {
            string resultado = "Productos en el carrito:\n";

            // Mostrar los productos y sus cantidades en el carrito
            foreach (var productoCantidad in productosCantidad_)
            {
                Producto producto = productoCantidad.Key;
                int cantidad = productoCantidad.Value;
                resultado += $"- {producto.Nombre_}, Cantidad: {cantidad}, Precio: {producto.Precio_}\n";
            }

            return resultado;
        }
    }
}
