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
            double lado;
            Console.WriteLine("\nCuadrado: ");
            Console.Write(" --> lado: ");
            double.TryParse(Console.ReadLine(), out lado);

            Cuadrado c1 = new Cuadrado();
            Console.WriteLine($"* area: {c1.area(lado)}");
            Console.WriteLine($"* perímetro: {c1.perimetro(lado)}");

            // Instanciación del rectángulo
            double baseC, alturaC;
            Console.WriteLine("\nRectángulo: ");
            Console.Write(" --> base: ");
            double.TryParse(Console.ReadLine(), out baseC);
            Console.Write(" --> altura: ");
            double.TryParse(Console.ReadLine(), out alturaC);

            Rectangulo r1 = new Rectangulo();
            Console.WriteLine($"* area: {r1.area(baseC,alturaC)}");
            Console.WriteLine($"* perímetro: {r1.perimetro(baseC,alturaC)}");

            // Instanciación del triángulo
            double lado1, lado2, lado3;
            Console.WriteLine("\nTriángulo: ");
            Console.Write(" --> lado1: ");
            double.TryParse(Console.ReadLine(), out lado1);
            Console.Write(" --> lado2: ");
            double.TryParse(Console.ReadLine(), out lado2);
            Console.Write(" --> lado3: ");
            double.TryParse(Console.ReadLine(), out lado3);
            Triangulo t1 = new Triangulo("#ffff",lado1,lado2,lado3);

            Console.WriteLine($"* color: {t1.color}");
            Console.WriteLine($"* area: {t1.area()}");
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
        private string color = "#0000";
        
        public double area(double l) { return l*l; }
        public double perimetro(double l) { return 4*l; }
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
        public double area(double b, double h) { return b * h; }
        public double perimetro(double b, double h) { return 2 * b + 2 * h; }
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
            if(!validar(lado1, lado2, lado3))
                throw new ArgumentException($"No se puede generar un triángulo con los lados ({lado1},{lado1},{lado1}");

            this.color = color;
            this.lado1 = lado1;
            this.lado2 = lado2;
            this.lado3 = lado3;
        }

        // Métodos
        private double perimetro() { return this.lado1 + this.lado2 + this.lado3; }
        public double area()
        {
            double s = perimetro() / 2; // semiperimetro
            // Teorema de Herón
            return Math.Sqrt(s * (s - this.lado1) * (s - this.lado2) * (s - this.lado3));
        }

        private bool validar(double l1, double l2, double l3) {
            double maxLado = Math.Max(l1, Math.Max(l2, l3));
            double sumaLadosMenores = (l1 + l2 + l3) - maxLado;

            return (sumaLadosMenores > maxLado);
        }
    }


}
