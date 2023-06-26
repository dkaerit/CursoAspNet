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
        public Dictionary<Producto, int> ProductosCantidad_ = new(); // <producto, cantidad>
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
            ProductosCantidad_[p] = cantidad;
            cliente_ = c;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////
        
        public void AgregarProducto(Producto producto, int cantidad = 1) { // por defecto añade 1
            if(ProductosCantidad_.ContainsKey(producto)) // si ya existe en el carrito
                ProductosCantidad_[producto] += cantidad; // incrementa en 'cantidad'
            else // si no existe
                ProductosCantidad_.Add(producto, cantidad); // se agrega el producto y su cantidad
        }

        public void RemoverProducto(Producto producto, int cantidad = 1) // por defecto remueve 1
        {
            if (!ProductosCantidad_.ContainsKey(producto)) // si no existe el rpoducto
                throw new ArgumentException("El producto no está en el carrito.");

            if (cantidad >= ProductosCantidad_[producto]) // si la cantidad a borrar excede
                ProductosCantidad_.Remove(producto);

            else // en cualquier otro caso
                ProductosCantidad_[producto] -= cantidad;
        }

        public void VaciarCarrito()
        {
            if (ProductosCantidad_.Count > 0)
                ProductosCantidad_.Clear();
        }

        public Pedido FormatoPedido() {
            return new Pedido(this);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            // Calcular el total sumando los precios de todos los productos * cantidad
            foreach (var productoCantidad in ProductosCantidad_)
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
            foreach (var productoCantidad in ProductosCantidad_)
            {
                Producto producto = productoCantidad.Key;
                int cantidad = productoCantidad.Value;
                resultado += $"- {producto.Nombre_}, Cantidad: {cantidad}, Precio: {producto.Precio_}\n";
            }

            return resultado;
        }
    }
}
