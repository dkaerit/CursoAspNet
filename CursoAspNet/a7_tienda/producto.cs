using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Producto
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////
        
        // private: Codigo 
        private static int Instancias_ = 0; // cantidad de objetos instanciados
        private readonly string Codigo_;

        // public: Nombre, Precio y Stock
        public string Nombre_ { get; set; }
        public decimal Precio_ { get; set; }
        public int Stock_ { get; set; }

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////
        
        public Producto(string nombre, decimal precio, int stock)
        {
            this.Codigo_ = GenerarCodigo();
            this.Nombre_ = nombre;
            this.Precio_ = precio;
            this.Stock_ = stock;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////

        private static string GenerarCodigo()
        {
            Instancias_++;
            return "PROD" + Instancias_.ToString("D4"); // D4: 4 dígitos decimales
        }
    }
}
