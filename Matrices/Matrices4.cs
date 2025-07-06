using System;

namespace TorneoFutbol
{
    internal class Program
    {
        static string[] equipos = { "Equipo A", "Equipo B", "Equipo C", "Equipo D" };
        static int[,] goles = new int[equipos.Length, equipos.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Torneo Juvenil de Fútbol ---");
                Console.WriteLine("1. Ingresar resultados de los partidos");
                Console.WriteLine("2. Mostrar resultados y estadísticas");
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
                    IngresarResultados();
                }
                else if (opcion == 2)
                {
                    MostrarResultadosYEstadisticas();
                }
                else if (opcion == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }
            }
        }

        static void IngresarResultados()
        {
            for (int i = 0; i < equipos.Length; i++)
            {
                for (int j = 0; j < equipos.Length; j++)
                {
                    if (i != j && goles[i, j] == 0 && goles[j, i] == 0)
                    {
                        Console.WriteLine($"\n{equipos[i]} vs {equipos[j]}");

                        int golesEquipo1 = SolicitarGoles($"  Goles anotados por {equipos[i]}: ");
                        int golesEquipo2 = SolicitarGoles($"  Goles anotados por {equipos[j]}: ");

                        goles[i, j] = golesEquipo1;
                        goles[j, i] = golesEquipo2;
                    }
                }
            }
        }

        static int SolicitarGoles(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out valor) && valor >= 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Ingresa un número entero válido (mayor o igual a 0).");
                }
            }
        }

        static void MostrarResultadosYEstadisticas()
        {
            Console.WriteLine("\n--- Resultados y Estadísticas ---");

            for (int i = 0; i < equipos.Length; i++)
            {
                Console.WriteLine($"\n{equipos[i]}:");

                int golesAnotados = 0;
                int golesRecibidos = 0;

                for (int j = 0; j < equipos.Length; j++)
                {
                    if (i != j)
                    {
                        Console.WriteLine($"  Goles anotados contra {equipos[j]}: {goles[i, j]}");
                        golesAnotados += goles[i, j];
                        golesRecibidos += goles[j, i];
                    }
                }

                Console.WriteLine($"  Total de goles anotados: {golesAnotados}");
                Console.WriteLine($"  Total de goles recibidos: {golesRecibidos}");
            }
        }
    }
}
