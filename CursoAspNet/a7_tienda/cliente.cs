using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Cliente
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////

        // privados: Telefono y DNI
        private int? telefono_;
        private string dni_;

        // publicos: Nombre, Email y Dirección
        public string nombre_ { get; set; }
        public string email_ { get; set; }
        public string direccion_ { get; set; }

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTIRES                //
        //                                             //
        /////////////////////////////////////////////////
        
        public Cliente(string dni, string nombre, string email, string direccion, int? telefono = null)
        {
            this.dni_ = dni;
            this.nombre_ = nombre;
            this.email_ = email;
            this.direccion_ = direccion;
            this.telefono_ = telefono;
        }


    }
}
