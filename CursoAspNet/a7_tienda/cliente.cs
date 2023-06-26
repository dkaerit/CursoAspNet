using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private string? Telefono_;
        private string? Dni_;

        // publicos: Nombre, Email y Dirección
        public string? Nombre_ { get; set; }
        public string? Email_ { get; set; }
        public string? Direccion_ { get; set; }

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTIRES                //
        //                                             //
        /////////////////////////////////////////////////
        public Cliente() { }
        public Cliente(string dni, string nombre, string email, string direccion, string? telefono = null)
        {
            this.Dni_ = dni;
            this.Telefono_ = telefono;
            this.Nombre_ = nombre;
            this.Email_ = email;
            this.Direccion_ = direccion;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////

        public void SetValues(string dni, string? telefono = null)
        {
            this.Dni_ = dni;
            this.Telefono_ = telefono;
        }

        public override string ToString()
        {
            string telefono = Telefono_ ?? "N/A";
            return $"DNI: {Dni_}\nNombre: {Nombre_}\nEmail: {Email_}\nDirección: {Direccion_}\nTeléfono: {telefono}";
        }


    }
}
