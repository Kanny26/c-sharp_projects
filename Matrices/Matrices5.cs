using System;

namespace ClinicaTemperatura
{
    internal class Program
    {
        static string[] pacientes = { "Paciente 1", "Paciente 2", "Paciente 3", "Paciente 4", "Paciente 5" };
        static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        static double[,] temperaturas = new double[pacientes.Length, dias.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Control de Temperatura Semanal ---");
                Console.WriteLine("1. Ingresar temperaturas");
                Console.WriteLine("2. Mostrar análisis por paciente");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                string entrada = Console.ReadLine();
                int opcion;

                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                if (opcion == 1)
                {
                    IngresarTemperaturas();
                }
                else if (opcion == 2)
                {
                    MostrarAnalisis();
                }
                else if (opcion == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }

        static void IngresarTemperaturas()
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                Console.WriteLine($"\n{pacientes[i]}:");

                for (int j = 0; j < dias.Length; j++)
                {
                    double temp;
                    bool valida = false;

                    while (!valida)
                    {
                        Console.Write($"  Temperatura el {dias[j]} (°C): ");
                        string entrada = Console.ReadLine();

                        if (double.TryParse(entrada.Replace(",", "."), out temp) && temp >= 34 && temp <= 43)
                        {
                            temperaturas[i, j] = temp;
                            valida = true;
                        }
                        else
                        {
                            Console.WriteLine("Ingresa una temperatura válida (entre 34.0 y 43.0 °C).");
                        }
                    }
                }
            }
        }

        static void MostrarAnalisis()
        {
            Console.WriteLine("\n--- Análisis de Temperatura ---");

            for (int i = 0; i < pacientes.Length; i++)
            {
                Console.WriteLine($"\n{pacientes[i]}:");

                double suma = 0;
                double max = temperaturas[i, 0];
                double min = temperaturas[i, 0];
                bool tuvoFiebre = false;

                for (int j = 0; j < dias.Length; j++)
                {
                    double temp = temperaturas[i, j];
                    Console.WriteLine($"  {dias[j]}: {temp} °C");

                    suma += temp;
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                    if (temp >= 38.0) tuvoFiebre = true;
                }

                double promedio = Math.Round(suma / dias.Length, 2);

                Console.WriteLine($"  Promedio semanal: {promedio} °C");
                Console.WriteLine($"  Temperatura máxima: {max} °C");
                Console.WriteLine($"  Temperatura mínima: {min} °C");
                Console.WriteLine($"  ¿Presentó fiebre?: {(tuvoFiebre ? "Sí" : "No")}");
            }
        }
    }
}
