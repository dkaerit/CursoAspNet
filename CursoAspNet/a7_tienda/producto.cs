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
        private static int instancias_ = 0; // cantidad de objetos instanciados
        private readonly string codigo_; // (readonly) solo puede asignarsele valor una vez

        // public: Nombre, Precio y Stock
        public string Nombre_;
        public decimal Precio_;
        public int Stock_;

        // getters y setters
        public string Codigo_ { get => codigo_; } // getter de lectura para codigo

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////

        public Producto(string nombre, decimal precio, int stock)
        {
            this.codigo_ = GenerarCodigo();

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
            instancias_++;
            return "PROD" + instancias_.ToString("D4"); // D4: 4 dígitos decimales
        }
    }
}
