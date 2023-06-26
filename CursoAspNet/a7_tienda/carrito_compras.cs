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
            string resultado = "Carrito de compras:\n";
            resultado += "------------------------------------------------------\n";
            resultado += "Cant.".PadRight(9);
            resultado += "Desc.".PadRight(24);
            resultado += "P.u.".PadRight(9);
            resultado += "Importe ($)".PadRight(9);
            resultado += "\n------------------------------------------------------\n";

            foreach (var productoCantidad in ProductosCantidad_)
            {
                Producto producto = productoCantidad.Key;
                int cantidad = productoCantidad.Value;
                decimal importe = producto.Precio_ * cantidad;

                string cantidadStr = cantidad.ToString();
                string descripcion = producto.Nombre_;
                string precioUnitario = producto.Precio_.ToString();
                string importeStr = importe.ToString();

                resultado += $"{cantidadStr.PadRight(9)}{descripcion.PadRight(24)}{precioUnitario.PadRight(16)}{importeStr}\n";
            }

            resultado += "----------------------------------------------------\n";

            return resultado;
        }

    }
}
