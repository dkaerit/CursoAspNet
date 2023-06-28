/* 
			IFCD46: ACTIVIDAD EVALUTIVA E1:

---Cliente---:
la clase Cliente podría tener propiedades como CodCliente, Nombre, Apellido1, Apellido2 y 
FNacimiento. 
la clase Cliente podría tener métodos como modificarCliente() y mostrarInfo().

---Moto y Coche---:
La clase Coche podría tener propiedades como CodCoche, Marca, Modelo, Cilindrada y 
Matrícula. 
La clase Moto podría tener CodMoto, Marca, Modelo, Caballos y Matrícula. 
En las clases moto y coche, habrá que asegurarse que se le asigna un valor 0 a la 
cilindrada y a los caballos, en caso de ser un valor negativo.

---Main---: 
Se pondrá un bucle, que permita la creación de los objetos
de cada clase y posteriormente hacer uso de sus correspondientes propiedades y métodos. Por ejemplo, se 
puede ir creando objetos de la clase Cliente y establecer sus propiedades mediante los constructores 
(deben estar sobrecargados con 1 y 2 parámetros. El de 2 recibiendo tipos de datos diferentes). Luego, 
se llamará a los métodos de esa instancia, como modificarCliente() para cambiar la info de un cliente. 
Con Coche y Moto seguirá el mismo funcionamiento.

Se deben utilizar diferentes listas para ir agregando, modificando y eliminando objetos de las clases: 
Cliente, Coche y Moto respectivamente. 

Se valorá la existencia de comentarios.

*/

using CursoAspNet.a7_tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAspNet.e1_vehiculos
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            /////////////////////////////////////////////////
            //                                             //
            //             INTRODUCIR CLIENTES             //
            //                                             //
            /////////////////////////////////////////////////
           
            Console.Write("\n¿Cuantos clientes quieres introducir?: ");
            int.TryParse(Console.ReadLine(), out int cantidadClientes);

            List<Cliente> clientes = new List<Cliente>(cantidadClientes);

            // Bucle pedir datos de coches "cantidadClientes" veces
            for (int i = 0; i < cantidadClientes; i++)
            {
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellido 1: ");
                string apellido1 = Console.ReadLine();
                Console.Write("Apellido 2: ");
                string apellido2 = Console.ReadLine();
                Console.Write("Nacimiento (DD/MM/YYYY): ");
                string fechaNacimiento = Console.ReadLine();
                Console.Write("Telefono: ");
                string telefono = Console.ReadLine();

                Tuple<string, string> apellidos = new(apellido1, apellido2);
                Cliente cliente = new(nombre, apellidos, fechaNacimiento, telefono);
                clientes.Add(cliente);
            }

            /////////////////////////////////////////////////
            //                                             //
            //             INTRODUCIR MOTOS                //
            //                                             //
            /////////////////////////////////////////////////

            Console.Write("\n¿Cuantas motos quieres introducir?: ");
            int.TryParse(Console.ReadLine(), out int cantidadMotos);
            List<Moto> motos = new List<Moto>(cantidadMotos);

            // Bucle pedir datos de coches "cantidadMotos" veces
            for (int i = 0; i < cantidadMotos; i++)
            {
                Console.Write("Marca: ");
                string marca = Console.ReadLine();
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Caballos: ");
                double.TryParse(Console.ReadLine(), out double caballos);
                Console.Write("Cilindrada: ");
                double.TryParse(Console.ReadLine(), out double cilindrada);
                Console.Write("Matricula: ");
                string matricula = Console.ReadLine();

                Moto moto = new(marca, modelo, caballos, cilindrada, matricula);
                motos.Add(moto);
            }

            /////////////////////////////////////////////////
            //                                             //
            //            INTRODUCIR COCHES                //
            //                                             //
            /////////////////////////////////////////////////

            Console.Write("\n¿Cuantos coches quieres introducir?: ");
            int.TryParse(Console.ReadLine(), out int cantidadCoches);

            // Bucle pedir datos de coches "cantidadCoches" veces
            List<Coche> coches = new List<Coche>(cantidadCoches);
            for (int i = 0; i < cantidadCoches; i++)
            {
                Console.Write("Marca: ");
                string marca = Console.ReadLine();
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Cilindrada: ");
                int.TryParse(Console.ReadLine(), out int cilindrada);
                Console.Write("Matricula: ");
                string matricula = Console.ReadLine();

                Coche coche = new(marca, modelo, cilindrada, matricula);
                coches.Add(coche);
            }

            /////////////////////////////////////////////////
            //                                             //
            //            IMPRIMIR POR PANTALLA            //
            //                                             //
            /////////////////////////////////////////////////

            Console.WriteLine("");

            foreach (Cliente cliente in clientes)
                cliente.Mostrar();

            foreach (Moto moto in motos)
                moto.Mostrar();

            foreach (Coche coche in coches)
                coche.Mostrar();

        }


    }
}
