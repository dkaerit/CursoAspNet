﻿using System;
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
        private string codigo_;

        // public: Nombre, Precio y Stock
        public string nombre_ { get; set; }
        public decimal precio_ { get; set; }
        public int stock_ { get; set; }

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////
        
        public Producto(string nombre, decimal precio, int stock)
        {
            this.codigo_ = GenerarCodigo();
            this.nombre_ = nombre;
            this.precio_ = precio;
            this.stock_ = stock;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////

        private string GenerarCodigo()
        {
            instancias_++;
            return "PROD" + instancias_.ToString("D4");
        }
    }
}
