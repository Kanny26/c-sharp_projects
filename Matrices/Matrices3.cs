using System;

namespace AcademiaArte
{
    internal class Program
    {
        static string[] estudiantes = { "Estudiante 1", "Estudiante 2", "Estudiante 3", "Estudiante 4", "Estudiante 5", "Estudiante 6" };
        static string[] areas = { "Dibujo artístico", "Pintura", "Escultura" };
        static double[,] calificaciones = new double[estudiantes.Length, areas.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Evaluación Trimestral de Estudiantes ---");
                Console.WriteLine("1. Ingresar calificaciones");
                Console.WriteLine("2. Mostrar calificaciones");
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
                    IngresarCalificaciones();
                }
                else if (opcion == 2)
                {
                    MostrarCalificaciones();
                }
                else if (opcion == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, elige una opción válida.");
                }
            }
        }

        static void IngresarCalificaciones()
        {
            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine($"\n{estudiantes[i]}:");

                for (int j = 0; j < areas.Length; j++)
                {
                    double nota;
                    bool notaValida = false;

                    // Repetir hasta que el usuario ingrese una nota válida
                    while (!notaValida)
                    {
                        Console.Write($"  Calificación en {areas[j]} (1.0 - 7.0): ");
                        string entrada = Console.ReadLine();

                        if (double.TryParse(entrada.Replace(",", "."), out nota) && nota >= 1.0 && nota <= 7.0)
                        {
                            calificaciones[i, j] = nota;
                            notaValida = true;
                        }
                        else
                        {
                            Console.WriteLine(" Entrada inválida. Debes ingresar un número entre 1.0 y 7.0 con punto decimal.");
                        }
                    }
                }
            }
        }


        static void MostrarCalificaciones()
        {
            Console.WriteLine("\n--- Calificaciones Registradas ---");

            for (int i = 0; i < estudiantes.Length; i++)
            {
                Console.WriteLine($"\n{estudiantes[i]}:");
                for (int j = 0; j < areas.Length; j++)
                {
                    Console.WriteLine($"  {areas[j]}: {calificaciones[i, j]:0.0}");
                }
            }
        }
    }
}
