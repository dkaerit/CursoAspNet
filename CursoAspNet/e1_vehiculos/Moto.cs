/**
 * @class Moto
 * atribuos: Codigo, Marca, Modelo, Caballos, Cilindrada y Matricula
 * metodos:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.e1_vehiculos
{
    internal class Moto
    {
        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////

        // privados
        private string codigo; // codigo del cliente
        private string marca; // marca de la moto
        private string modelo; // modelo de la moto
        private double caballos; // caballos de potencia de la moto
        private double cilindrada; // cilindrada de la moto (cm3)
        private string matricula; // matricula de la moto

        // publicos + getters y setters
        public static long Instancias = 0; // Cantidad de motos creadas 
        public string Codigo { get => codigo; } // sólo lectura
        public string Marca { get => marca; } // sólo lectura
        public string Modelo { get => modelo; } // sólo lectura
        public double Caballos // lectura y modificación
        { 
            get => caballos;
            set => caballos = (value < 0)? 0 : value; // si value negativo se fuerza a 0
        }
        public double Cilindrada // lectura y modificación
        { 
            get => cilindrada; 
            set => cilindrada = (value < 0)? 0 : value; // si value negativo se fuerza a 0
        }
        public string Matricula { get => matricula; set => matricula = value; } // lectura y modificacion

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////
        
        public Moto(string marc, string model, double caballos, double cilindrada, string matricula)
        {
            codigo = GenerarCodigo();
            marca = marc;
            modelo = model;

            Caballos = caballos;
            Cilindrada = cilindrada;
            Matricula = matricula;
        }

        public Moto(string marc, string model)
        {
            marca = marc;
            modelo = model;
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   METODOS                   //
        //                                             //
        /////////////////////////////////////////////////

        public void Mostrar()
        {
            Console.WriteLine($"Moto {codigo}");
            Console.WriteLine($"--- Marca: {marca}");
            Console.WriteLine($"--- Modelo: {modelo}");
            Console.WriteLine($"--- Caballos: {caballos}");
            Console.WriteLine($"--- Cilindrada: {cilindrada}");
            Console.WriteLine($"--- Matricula: {matricula}");
            Console.WriteLine("");
        }

        public void Modificar(double cab, double cil, string mat)
        {
            Caballos = (cab != null) ? cab : Caballos;
            Cilindrada = (cil != null) ? cil : Cilindrada;
            Matricula = (mat != null)? mat : Matricula;
        }

        private string GenerarCodigo()
        {
            return "MO-" + Instancias.ToString("D4"); // ej: MO-0001, MO-0012 ...
        }
    }
}
