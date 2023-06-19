/* 
- Mostrar mensaje de bienvenida.
- Adivinar número dentro de un intervalo.
- Dar pistas sobre el número. (mayor o menor)
- Limitar intentos para adivinar. (vidas)
- Mostrar número y mensaje al finalizar.
- Preguntar si se desea seguir jugando.
*/

using System;

namespace CursoAspNet
{
    class JuegoAdivinacion
    {

        /////////////////////////////////////////////////
        //                                             //
        //                 ATRIBUTOS                   //
        //                                             //
        /////////////////////////////////////////////////


        private static Tuple<int, int> _tupla = Tuple.Create(0, 0);
        private static int _dificultad = 0;

        enum Dificultad : int { Facil, Intermedio, Dificil, Extremo }
        private readonly static Dictionary<int, double> _dificultades = new Dictionary<int, double>()
        {

            { (int)Dificultad.Facil, 0.50 },     // 50%
            { (int)Dificultad.Intermedio, 0.3 }, // 30%
            { (int)Dificultad.Dificil, 0.1 },    // 10%
            { (int)Dificultad.Extremo, 0.01 }    // 1% 
        };

        /////////////////////////////////////////////////
        //                                             //
        //                   MAIN                      //
        //                                             //
        /////////////////////////////////////////////////

        public static void Main(string[] args)
        {
            // mensaje de bienvenida
            Console.WriteLine("Bienvenido al juego de 'Adivina el número'");
            Console.WriteLine("Primero que nada, elige dos números (n1 y n2):\n");

            do
            {
                crear_intervalo(); // pide 2 numeros y setea un intervalo como atributo
                jugar_adivinanza(generar_numero(), generar_vidas()); // comienzo del juego
                Console.Write("\n¿Deseas seguir jugando?  (yes/no): ");
            } while (Console.ReadLine() == "yes");
        }

        /////////////////////////////////////////////////
        //                                             //
        //                   FUNC                      //
        //                                             //
        /////////////////////////////////////////////////

        /**
        * @brief, Método que crea el intervalo n1, n2
        * @return Tuple<int,int>, intervalo n1,n2
        */

        static void crear_intervalo()
        {
            int n1, n2;

            Console.Write(" --> n1: "); // solicitar n1
            if (!int.TryParse(Console.ReadLine(), out n1))
                throw new ArgumentException($"El valor n1({n1}) no es correcto.");

            Console.Write(" --> n2: "); // solicitar n2
            if (!int.TryParse(Console.ReadLine(), out n2))
                throw new ArgumentException($"El valor n2({n2}) no es correcto.");


            _tupla = (n1 < n2) ? // crear tupla
                Tuple.Create(n1, n2) :
                Tuple.Create(n2, n1);
        }

        /**
         * @brief, Método que calcula un numero aleatorio dentro del intervalo
         * @return int, numero aleatorio generado
         */
        static int generar_numero()
        {
            return new Random().Next(_tupla.Item1, _tupla.Item2 + 1);
        }


        /**
         * @brief, Método que elige la dificultad del juego
         * @return double, porcentaje segun la dificultad elegida
         */

        static double elegir_dificultad()
        {
            Console.WriteLine("\nElije la dificultad:\n");

            // MENU
            // [0] Fácil
            // [1] Intermedio
            // ...
            foreach (var dificultad in _dificultades) // menú a partir del Dictionary 
                Console.WriteLine($"[{dificultad.Key}] {(Dificultad)dificultad.Key}.");

            // ELECCIÓN
            bool dificultad_valida;
            do
            {
                Console.Write("\n --> dificultad: "); // mensaje petición
                int.TryParse(Console.ReadLine(), out _dificultad); // Pide opción

                dificultad_valida = _dificultades.ContainsKey(_dificultad);
                if (!dificultad_valida) // Mensaje de aviso no valido
                    Console.WriteLine("\nElije una dificultad correcta:");

            } while (!dificultad_valida); // checkear si es válido

            return _dificultades[_dificultad];
        }

        /**
         * @brief, Método que genera la cantidad de vidas iniciales según la dificultad
         * @return int, cantidad de vidas iniciales
         */

        static int generar_vidas()
        {
            double porcentaje = elegir_dificultad();
            int cantidad = Math.Abs(_tupla.Item1 - _tupla.Item2);
            return Math.Max(1, (int)Math.Round(cantidad * porcentaje));
            // si el redondeo fuera 0, el max sería 1
        }

        /**
         * @brief, Método que permite al jugador adivinar el número objetivo
         * @param objetivo, número objetivo que el jugador debe adivinar
         * @param vidas, cantidad de vidas restantes
         */

        static void jugar_adivinanza(int objetivo, int vidas)
        {
            int candidato;
            Console.Write($"[Tienes {vidas} intentos]\n");
            int inf = _tupla.Item1, sup = _tupla.Item2;

            do
            {
                Console.Write($"\n¿Cuál crees que es el número? ({inf}...{sup}): ");
                int.TryParse(Console.ReadLine(), out candidato);
                Console.Write("\n");

                if (candidato > objetivo)
                {
                    Console.WriteLine($"El número que buscas es menor que {candidato}");
                    sup = candidato - 1;
                    vidas--;
                }

                if (candidato < objetivo)
                {
                    Console.WriteLine($" - El número que buscas es mayor que {candidato}");
                    inf = candidato + 1;
                    vidas--;
                }

                if (candidato == objetivo)
                {
                    Console.WriteLine($"¡Correcto! el número era {candidato}");
                    break;
                }

                Console.WriteLine($" - Te quedan {vidas} intentos.");
            } while ((candidato != objetivo) && (vidas > 0));

            if (vidas == 0)
                Console.WriteLine($"\nGame over. Se te acabaron los intentos. El número era {objetivo}");
        }


    }
}
