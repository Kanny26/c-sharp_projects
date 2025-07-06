using System;

namespace ProduccionMultinacional
{
    internal class Program
    {
        static string[] fabricas = { "Fábrica México", "Fábrica Alemania", "Fábrica Japón", "Fábrica Brasil" };
        static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
        static string[] turnos = { "Mañana", "Tarde", "Noche" };
        static string[] productos = { "Producto A", "Producto B", "Producto C" };

        static int[,,,] produccion = new int[fabricas.Length, dias.Length, turnos.Length, productos.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Producción Global ---");
                Console.WriteLine("1. Ingresar datos de producción");
                Console.WriteLine("2. Ver análisis por fábrica");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciona una opción: ");

                string entrada = Console.ReadLine();
                int opcion;

                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine(" Entrada inválida.");
                    continue;
                }

                if (opcion == 1)
                    IngresarDatos();
                else if (opcion == 2)
                    MostrarAnalisis();
                else if (opcion == 3)
                    break;
                else
                    Console.WriteLine(" Opción no válida.");
            }
        }

        static void IngresarDatos()
        {
            Console.WriteLine("\n--- Selecciona la fábrica para ingresar datos ---");
            for (int i = 0; i < fabricas.Length; i++)
                Console.WriteLine($"{i + 1}. {fabricas[i]}");

            Console.Write("Opción: ");
            string entrada = Console.ReadLine();
            int indiceFabrica;

            if (!int.TryParse(entrada, out indiceFabrica) || indiceFabrica < 1 || indiceFabrica > fabricas.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            indiceFabrica -= 1;

            for (int indiceDia = 0; indiceDia < dias.Length; indiceDia++)
            {
                Console.WriteLine($"\n {dias[indiceDia]}:");

                for (int indiceTurno = 0; indiceTurno < turnos.Length; indiceTurno++)
                {
                    Console.WriteLine($"  Turno: {turnos[indiceTurno]}");

                    for (int indiceProducto = 0; indiceProducto < productos.Length; indiceProducto++)
                    {
                        int cantidad;
                        bool valido = false;

                        while (!valido)
                        {
                            Console.Write($"    {productos[indiceProducto]}: ");
                            string entradaCantidad = Console.ReadLine();

                            if (int.TryParse(entradaCantidad, out cantidad) && cantidad >= 0)
                            {
                                produccion[indiceFabrica, indiceDia, indiceTurno, indiceProducto] = cantidad;
                                valido = true;
                            }
                            else
                            {
                                Console.WriteLine("     Valor inválido. Intenta nuevamente.");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n Datos registrados correctamente.");
        }

        static void MostrarAnalisis()
        {
            Console.WriteLine("\n--- Selecciona la fábrica para ver el análisis ---");

            for (int i = 0; i < fabricas.Length; i++)
                Console.WriteLine($"{i + 1}. {fabricas[i]}");

            Console.Write("Opción: ");
            string entrada = Console.ReadLine();
            int indiceFabrica;

            if (!int.TryParse(entrada, out indiceFabrica) || indiceFabrica < 1 || indiceFabrica > fabricas.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            indiceFabrica -= 1;

            Console.WriteLine($"\n Análisis de {fabricas[indiceFabrica]}:");

            int totalFabrica = 0;
            int[] totalPorProducto = new int[productos.Length];
            int[] totalPorTurno = new int[turnos.Length];

            for (int dia = 0; dia < dias.Length; dia++)
            {
                for (int turno = 0; turno < turnos.Length; turno++)
                {
                    for (int producto = 0; producto < productos.Length; producto++)
                    {
                        int cantidad = produccion[indiceFabrica, dia, turno, producto];
                        totalFabrica += cantidad;
                        totalPorProducto[producto] += cantidad;
                        totalPorTurno[turno] += cantidad;
                    }
                }
            }

            Console.WriteLine($"\n Producción total semanal: {totalFabrica} unidades");

            Console.WriteLine("\n Total por producto:");
            for (int i = 0; i < productos.Length; i++)
            {
                Console.WriteLine($"  {productos[i]}: {totalPorProducto[i]} unidades");
            }

            Console.WriteLine("\n Total por turno:");
            for (int i = 0; i < turnos.Length; i++)
            {
                Console.WriteLine($"  {turnos[i]}: {totalPorTurno[i]} unidades");
            }
        }
    }
}
