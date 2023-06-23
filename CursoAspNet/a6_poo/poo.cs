/**
 * Se deben añadir las siguientes clases: Cuadrado, Rectángulo y Triángulo.
 * Crear al menos una instancia de cada clase (objeto) usando las propiedades y métodos adecuados.
 * */


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a6_poo
{
    /////////////////////////////////////////////////
    //                                             //
    //                   MAIN                      //
    //                                             //
    /////////////////////////////////////////////////
    
    internal class Poo
    {
        public static void Main2(string[] args)
        {
            // Instanciación del cuadrado
            Console.WriteLine("\nCuadrado: ");
            Console.Write(" --> lado: ");
            _ = double.TryParse(Console.ReadLine(), out double lado);
            _ = new Cuadrado();
            Console.WriteLine($"* area: {Cuadrado.Area(lado)}");
            Console.WriteLine($"* perímetro: {Cuadrado.Perimetro(lado)}");

            // Instanciación del rectángulo
            Console.WriteLine("\nRectángulo: ");
            Console.Write(" --> base: ");
            _ = double.TryParse(Console.ReadLine(), out double baseC);
            Console.Write(" --> altura: ");
            _ = double.TryParse(Console.ReadLine(), out double alturaC);
            _ = new Rectangulo();
            Console.WriteLine($"* area: {Rectangulo.Area(baseC,alturaC)}");
            Console.WriteLine($"* perímetro: {Rectangulo.Perimetro(baseC,alturaC)}");

            // Instanciación del triángulo
            Console.WriteLine("\nTriángulo: ");
            Console.Write(" --> lado1: ");
            _ = double.TryParse(Console.ReadLine(), out double lado1);
            Console.Write(" --> lado2: ");
            _ = double.TryParse(Console.ReadLine(), out double lado2);
            Console.Write(" --> lado3: ");
            _ = double.TryParse(Console.ReadLine(), out double lado3);
            Triangulo t1 = new("#ffff",lado1,lado2,lado3);

            Console.WriteLine($"* color: {t1.color}");
            Console.WriteLine($"* area: {t1.Area()}");
            // inaccesible -> Console.WriteLine($"* area: {t1.perimetro()}");
        }
    }

    /////////////////////////////////////////////////
    //                                             //
    //                   CUAD                      //
    //                                             //
    /////////////////////////////////////////////////
    
    /**
     * propiedad color (no accesible externamente), 
     * métodos "Área" y "Perímetro" (accesibles externamente).
     */

    internal class Cuadrado
    {
        // private readonly string color = "#0000";
        
        public static double Area(double l) { return l*l; }
        public static double Perimetro(double l) { return 4*l; }
    }

    /////////////////////////////////////////////////
    //                                             //
    //                   RECT                      //
    //                                             //
    /////////////////////////////////////////////////
    
    /**
     * sin propiedades, 
     * métodos "Área" y "Perímetro" (accesibles externamente).
     */

    internal class Rectangulo
    {
        public static double Area(double b, double h) { return b * h; }
        public static double Perimetro(double b, double h) { return 2 * b + 2 * h; }
    }

    /////////////////////////////////////////////////
    //                                             //
    //                   TRIA                      //
    //                                             //
    /////////////////////////////////////////////////

    /**
     * propiedades color (accesible externamente), lado1, lado2 y lado3 (accesibles externamente), 
     * métodos "Área" (accesible externamente) y "Perímetro" (no accesible externamente).
     */

    internal class Triangulo
    {
        public string color = "#0000";
        public double lado1, lado2, lado3;

        // Constructor
        public Triangulo(string color, double lado1, double lado2, double lado3)
        {
            if(!Validar(lado1, lado2, lado3))
                throw new ArgumentException($"No se puede generar un triángulo con los lados ({lado1},{lado1},{lado1}");

            this.color = color;
            this.lado1 = lado1;
            this.lado2 = lado2;
            this.lado3 = lado3;
        }

        // Métodos
        private double Perimetro() { return this.lado1 + this.lado2 + this.lado3; }
        public double Area()
        {
            double s = Perimetro() / 2; // semiperimetro
            // Teorema de Herón
            return Math.Sqrt(s * (s - this.lado1) * (s - this.lado2) * (s - this.lado3));
        }

        private static bool Validar(double l1, double l2, double l3) {
            double maxLado = Math.Max(l1, Math.Max(l2, l3));
            double sumaLadosMenores = (l1 + l2 + l3) - maxLado;

            return (sumaLadosMenores > maxLado);
        }
    }


}
