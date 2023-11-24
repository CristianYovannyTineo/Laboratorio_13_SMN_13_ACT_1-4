using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_13_SMN_13_ACT_1_4
{

    class Program
    {
        static int[] encuestaResultados = new int[100];
        static int totalEncuestas = 0;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("==============================\n"+
                "Encuesta de Calidad\n"+
                "==============================\n"+
                "1: Realizar Encuesta\n"+
                "2: Ver datos registrados\n"+
                "3: Eliminar un dato\n"+
                "4: Ordenar datos de menor a mayor\n"+
                "5: Salir\n"+
                "==============================");
                Console.Write("Ingrese una opcion: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RealizarEncuesta();
                            break;
                        case 2:
                            VerDatosRegistrados();
                            break;
                        case 3:
                            EliminarDato();
                            break;
                        case 4:
                            OrdenarDatos();
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida.");
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }

        static void RealizarEncuesta()
        {
            Console.Clear();
            Console.WriteLine("==============================\n" +
            "Nivel de Satisfacción\n" +
            "==============================\n" +
            "¿Qué tan satisfecho está con la atención de nuestra tienda?\n" +
            "1: Nada satisfecho\n" +
            "2: No muy satisfecho\n" +
            "3: Tolerable\n" +
            "4: Satisfecho\n" +
            "5: Muy satisfecho\n" +
            "==============================");

            int respuesta;

            if (int.TryParse(Console.ReadLine(), out respuesta) && respuesta >= 1 && respuesta <= 5)
            {
                encuestaResultados[totalEncuestas] = respuesta;
                totalEncuestas++;

                Console.Clear();
                Console.WriteLine("==============================\n" +
                "Nivel de Satisfacción\n" +
                "==============================\n" +
                "¡Gracias por participar!\n" +
                "==============================");
            }
        }

        static void VerDatosRegistrados()
        {
            Console.Clear();
            Console.WriteLine("==============================\n" +
            "Ver datos registrados\n"+
            "==============================");

            int[] contador = new int[5];

            for (int i = 0; i < totalEncuestas; i++)
            {
                Console.Write($"[{encuestaResultados[i]}]  ");

                contador[encuestaResultados[i] - 1]++;
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{contador[i]:D2} personas: {(NivelSatisfaccion)(i + 1)}");
            }
        }

        static void EliminarDato()
        {
            Console.Clear();
            Console.WriteLine("==============================\n" +
            "Eliminar un dato\n" +
            "==============================");

            MostrarEncuestas();

            Console.Write("Ingrese la posición a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int posicionEliminar) && posicionEliminar >= 0 && posicionEliminar < totalEncuestas)
            {
                for (int i = posicionEliminar; i < totalEncuestas - 1; i++)
                {
                    encuestaResultados[i] = encuestaResultados[i + 1];
                }

                totalEncuestas--;

                Console.Clear();
                Console.WriteLine("Dato eliminado correctamente.");
                MostrarEncuestas();
            }
            else
            {
                Console.WriteLine("Posición no válida.");
            }
        }

        static void OrdenarDatos()
        {
            Console.Clear();
            Console.WriteLine("==============================\n" +
            "Ordenar datos de menor a mayor\n" +
            "==============================");

            Array.Sort(encuestaResultados, 0, totalEncuestas);

            MostrarEncuestas();
        } 
        enum NivelSatisfaccion
        {
            NadaSatisfecho = 1,
            NoMuySatisfecho,
            Tolerable,
            Satisfecho,
            MuySatisfecho
        }

        static void MostrarEncuestas()
        {
            for (int i = 0; i < totalEncuestas; i++)
            {
                Console.WriteLine($"{i:D3}: [{encuestaResultados[i]}]");
            }
        }

       

    }
}
