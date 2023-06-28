/**
 * @class Moto
 * atribuos: Codigo, Marca, Modelo, Cilindrada y Matricula
 * metodos:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.e1_vehiculos
{
    internal class Coche
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
        public static long Instancias = 0; // Cantidad de coches creados 
        public string Codigo { get => codigo; } // sólo lectura
        public string Marca { get => marca; } // sólo lectura
        public string Modelo { get => modelo; } // sólo lectura
        public double Cilindrada // lectura y modificación
        {
            get => cilindrada;
            set => cilindrada = (value < 0) ? 0 : value; // si value negativo se fuerza a 0
        }
        public string Matricula { get => matricula; set => matricula = value; } // lectura y modificacion

        /////////////////////////////////////////////////
        //                                             //
        //                CONSTRUCTORES                //
        //                                             //
        /////////////////////////////////////////////////

        public Coche(string marc, string model, double cilindrada, string matricula)
        {
            codigo = GenerarCodigo();
            marca = marc;
            modelo = model;

            Cilindrada = cilindrada;
            Matricula = matricula;
        }

        public Coche(string marc, string model)
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
            Console.WriteLine($"--- Cilindrada: {cilindrada}");
            Console.WriteLine($"--- Matricula: {matricula}");
            Console.WriteLine("");
        }

        public void Modificar(double cab, double cil, string mat)
        {
            Cilindrada = (cil != null) ? cil : Cilindrada;
            Matricula = (mat != null) ? mat : Matricula;
        }

        private string GenerarCodigo()
        {
            return "CO-" + Instancias.ToString("D4"); // ej: CO-0001, CO-0012 ...
        }
    }
}
