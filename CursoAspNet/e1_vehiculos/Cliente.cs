/**
 * @Class Cliente
 * atributos: Codigo, Nombre, Apellidos, Nacimiento y Telefono
 * metodos: 
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.e1_vehiculos
{
    // DateTime expiry = new DateTime(Convert.ToInt32(ddExpYear),Convert.ToInt32(ddExpMonth), 1);
    // string formatted = expiry.ToString("yyyy/MM");
    internal class Cliente
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////

        // privados
        private string codigo; // codigo del cliente
        private string nombre; // Nombre del cliente
        private Tuple<string,string> apellidos; // par (apellido1, apellido2)
        private DateTime nacimiento; // fecha de nacimiento del cliente
        private string? telefono; // telefono del cliente (puede ser null)

        // publicos + getters y setters
        public static long Instancias = 0; // Cantidad de clientes creados 
        public string Codigo { get => codigo; } // sólo lectura
        public string Nombre { get => nombre; set => nombre = value; } // lectura y modificable
        public Tuple<string,string> Apellidos { get => apellidos; set => apellidos = value; } // lectura y modificable
        public string Nacimiento 
        { 
            get => nacimiento.ToString("d/M/yyyy");
            set => nacimiento = DateTime.Parse(value);
        } 
        public string? Telefono { get => telefono; set => telefono = value; } // lectura y modificable (posible null)

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////

        public Cliente(string nombre, Tuple<string,string> apellidos, string nac, string tlfn ) 
        {
            codigo = GenerarCodigo();
            Nombre = nombre;
            Apellidos = apellidos;
            Nacimiento = nac;
            Telefono = tlfn;
        }

        public Cliente(string nombre, Tuple<string,string> apellidos, string nac) 
        {
            codigo = GenerarCodigo();
            Nombre = nombre;
            Apellidos = apellidos;
            Nacimiento = nac;
            Telefono = null;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                    METODOS                  //
        //                                             //
        /////////////////////////////////////////////////
        
        public void Mostrar()
        {
            Console.WriteLine($"Cliente {codigo}");
            Console.WriteLine($"--- Nombre: {nombre}");
            Console.WriteLine($"--- Apellido 1: {apellidos.Item1}");
            Console.WriteLine($"--- Apellido 2: {apellidos.Item2}");
            Console.WriteLine($"--- F. Nacimiento: {Nacimiento}");
            if(telefono == null) Console.Write($"--- Telefono: Sin definir");
            else Console.WriteLine($"--- Telefono: {telefono}");
            Console.WriteLine("");
        }

        public void Modificar(string nom, Tuple<string, string> apell)
        {
            Nombre = (nom != null)? nom : Nombre;
            Apellidos = (apell != null)? apell : Apellidos;;
        }

        private string GenerarCodigo()
        {
            return "CLI-" + Instancias.ToString("D4"); // ej: CLI-001, CLI-0012 ...
        }

    }
}
