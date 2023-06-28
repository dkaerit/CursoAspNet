using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Pedido
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////
        
        private bool isConfirmed_ = false;

        public Cliente Cliente_;
        public CarritoCompras Carrito_;

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTIRES                //
        //                                             //
        /////////////////////////////////////////////////

        public Pedido(Producto p, Cliente c) {
            this.Carrito_ = new CarritoCompras(p,1,c);
            this.Cliente_ = c;
        }

        public Pedido(CarritoCompras cc)
        {
            this.Carrito_ = cc;
            this.Cliente_ = cc.cliente_;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////
        

        public decimal CalcularTotal() {
            return Carrito_.CalcularTotal();
        }


        public void ConfirmarPedido() {
            isConfirmed_ = true;
        }

        public void MostrarPedido()
        {
            Console.WriteLine($"Pedido del cliente {Cliente_.Nombre_}:");
            Console.WriteLine(Carrito_.MostrarCarrito());
            Console.WriteLine($"Total: {CalcularTotal()}");
            Console.WriteLine();
        }

        public void Factura()
        {
            if (isConfirmed_)
            {
                Console.WriteLine("Factura del pedido:");
                Console.WriteLine("\n");
                Console.WriteLine($"Cliente: {Cliente_.Nombre_}");
                Console.WriteLine($"DNI: {Cliente_.Dni_}");
                Console.WriteLine($"Dirección de entrega: {Cliente_.Direccion_}");
                Console.WriteLine(Carrito_.MostrarCarrito());
                Console.WriteLine("Total: ".PadRight(41)+CalcularTotal().ToString("0.00").PadLeft(12));
            }
            else
                Console.WriteLine("El pedido no ha sido confirmado. No se puede generar la factura.");
        }
    }
}
