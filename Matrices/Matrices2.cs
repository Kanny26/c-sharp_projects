using System;

namespace JardinInfantil
{
    internal class Program
    {
        static string[] salas = { "Sala Cuna", "Nivel Medio Menor", "Nivel Medio Mayor", "Transición" };
        static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
        static int[,] asistencia = new int[salas.Length, dias.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Registro de Asistencia Semanal ---");
                Console.WriteLine("1. Ingresar asistencia");
                Console.WriteLine("2. Mostrar asistencia");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                string entrada = Console.ReadLine();
                int opcion;

                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Entrada inválida. Intenta de nuevo.");
                    continue;
                }

                if (opcion == 1)
                {
                    IngresarAsistencia();
                }
                else if (opcion == 2)
                {
                    MostrarAsistencia();
                }
                else if (opcion == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, elige una opción entre 1 y 3.");
                }
            }
        }

        static void IngresarAsistencia()
        {
            for (int i = 0; i < salas.Length; i++)
            {
                Console.WriteLine($"\nSala: {salas[i]}");
                for (int j = 0; j < dias.Length; j++)
                {
                    Console.Write($"¿Cuántos niños asistieron el {dias[j]}? ");
                    string entrada = Console.ReadLine();
                    int cantidad;

                    if (int.TryParse(entrada, out cantidad) && cantidad >= 0)
                    {
                        asistencia[i, j] = cantidad;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. Se registrará 0.");
                        asistencia[i, j] = 0;
                    }
                }
            }
        }

        static void MostrarAsistencia()
        {
            Console.WriteLine("\n--- Asistencia Registrada ---");

            for (int i = 0; i < salas.Length; i++)
            {
                Console.WriteLine($"\nSala: {salas[i]}");
                for (int j = 0; j < dias.Length; j++)
                {
                    Console.WriteLine($"  {dias[j]}: {asistencia[i, j]} niños");
                }
            }
        }
    }
}
