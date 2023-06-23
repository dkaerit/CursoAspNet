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
        
        private bool is_confirmed_ = false;
        public Cliente Cliente_ { get; set; }
        public CarritoCompras carrito_ { get; set; }

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTIRES                //
        //                                             //
        /////////////////////////////////////////////////

        public Pedido(Producto p, Cliente c) {
            this.carrito_ = new CarritoCompras(p,1,c);
            this.Cliente_ = c;
        }

        public Pedido(CarritoCompras cc)
        {
            this.carrito_ = cc;
            this.Cliente_ = cc.cliente_;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////
        

        public decimal CalcularTotal() {
            return carrito_.CalcularTotal();
        }


        public void ConfirmarPedido() {
            is_confirmed_ = true;
        }

        public void MostrarPedido()
        {
            Console.WriteLine($"Pedido del cliente {Cliente_.Nombre_}:");
            Console.WriteLine(carrito_.MostrarCarrito());
            Console.WriteLine($"Total: {CalcularTotal()}");
            Console.WriteLine();
        }
    }
}
