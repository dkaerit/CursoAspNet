using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.a7_tienda
{
    internal class Program {

        private static readonly Dictionary<int, Action> modos = new()
        {
            { 1, () => Interactivo.Exec() },
            { 2, () => Test.Exec() }
        };

        public static void MainTienda(string[] args)
        {
            Console.WriteLine("Seleccione el modo:");
            Console.WriteLine("1. Modo interactivo");
            Console.WriteLine("2. Modo de prueba de clases");
            Console.Write(">> ");
            _ = int.TryParse(Console.ReadLine(), out int index);
            Console.WriteLine("");
            modos[index]();
           
        }
    }
}