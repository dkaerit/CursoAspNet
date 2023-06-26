using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Program {

        private static Dictionary<int, Action> modos = new Dictionary<int, Action>()
        {
            { 1, () => Interactivo.exec() },
            { 2, () => Test.exec() }
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Seleccione el modo:");
            Console.WriteLine("1. Modo interactivo");
            Console.WriteLine("2. Modo de prueba de clases");
            Console.Write(">> ");
            int.TryParse(Console.ReadLine(), out int index);
            Console.WriteLine("");
            modos[index]();
           
        }
    }
}