using System;

namespace EstacionesSatelitales
{
    internal class Program
    {
        static string[] estaciones = {
            "Estación Alpha", "Estación Beta", "Estación Gamma",
            "Estación Delta", "Estación Epsilon", "Estación Zeta"
        };

        static string[] dias = {
            "Día 1", "Día 2", "Día 3", "Día 4", "Día 5",
            "Día 6", "Día 7", "Día 8", "Día 9", "Día 10"
        };

        static string[] variables = { "Temperatura (°C)", "Humedad (%)", "Viento (km/h)" };

        static double[,,] datos = new double[estaciones.Length, dias.Length, variables.Length];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Monitoreo Satelital ---");
                Console.WriteLine("1. Ingresar datos de las estaciones");
                Console.WriteLine("2. Mostrar datos y análisis por estación");
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
                    IngresarDatos();
                else if (opcion == 2)
                    MostrarAnalisis();
                else if (opcion == 3)
                    break;
                else
                    Console.WriteLine("Opción no válida.");
            }
        }

        static void IngresarDatos()
        {
            Console.WriteLine("\n--- Selecciona la estación a editar ---");

            for (int i = 0; i < estaciones.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {estaciones[i]}");
            }

            Console.Write("Elige una opción (1-" + estaciones.Length + "): ");
            string entrada = Console.ReadLine();
            int indiceEstacion;

            if (!int.TryParse(entrada, out indiceEstacion) || indiceEstacion < 1 || indiceEstacion > estaciones.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            // Ajustar a índice de matriz (0 a 5)
            indiceEstacion -= 1;

            Console.WriteLine($"\n Ingresando datos para {estaciones[indiceEstacion]}:");

            for (int indiceDia = 0; indiceDia < dias.Length; indiceDia++)
            {
                Console.WriteLine($"\n  {dias[indiceDia]}:");

                for (int indiceVariable = 0; indiceVariable < variables.Length; indiceVariable++)
                {
                    double valor;
                    bool valido = false;

                    while (!valido)
                    {
                        Console.Write($"    {variables[indiceVariable]}: ");
                        string valorEntrada = Console.ReadLine();

                        if (double.TryParse(valorEntrada.Replace(",", "."), out valor))
                        {
                            datos[indiceEstacion, indiceDia, indiceVariable] = valor;
                            valido = true;
                        }
                        else
                        {
                            Console.WriteLine("     Valor no válido. Intenta nuevamente.");
                        }
                    }
                }
            }

            Console.WriteLine("\n Datos registrados correctamente.");
        }


        static void MostrarAnalisis()
        {
            Console.WriteLine("\n--- Selecciona la estación para ver el análisis ---");

            for (int i = 0; i < estaciones.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {estaciones[i]}");
            }

            Console.Write("Elige una opción (1-" + estaciones.Length + "): ");
            string entrada = Console.ReadLine();
            int indiceEstacion;

            if (!int.TryParse(entrada, out indiceEstacion) || indiceEstacion < 1 || indiceEstacion > estaciones.Length)
            {
                Console.WriteLine(" Opción inválida.");
                return;
            }

            // Ajuste al índice de matriz
            indiceEstacion -= 1;

            Console.WriteLine($"\n {estaciones[indiceEstacion]}:");

            double[] sumaPorVariable = new double[variables.Length];
            double[] maximoPorVariable = new double[variables.Length];
            double[] minimoPorVariable = new double[variables.Length];
            int[] diaMaximo = new int[variables.Length];
            int[] diaMinimo = new int[variables.Length];

            // Inicializar
            for (int indiceVariable = 0; indiceVariable < variables.Length; indiceVariable++)
            {
                maximoPorVariable[indiceVariable] = datos[indiceEstacion, 0, indiceVariable];
                minimoPorVariable[indiceVariable] = datos[indiceEstacion, 0, indiceVariable];
                diaMaximo[indiceVariable] = 0;
                diaMinimo[indiceVariable] = 0;
            }

            for (int indiceDia = 0; indiceDia < dias.Length; indiceDia++)
            {
                Console.WriteLine($"\n  {dias[indiceDia]}:");

                for (int indiceVariable = 0; indiceVariable < variables.Length; indiceVariable++)
                {
                    double valor = datos[indiceEstacion, indiceDia, indiceVariable];
                    Console.WriteLine($"    {variables[indiceVariable]}: {valor}");

                    sumaPorVariable[indiceVariable] += valor;

                    if (valor > maximoPorVariable[indiceVariable])
                    {
                        maximoPorVariable[indiceVariable] = valor;
                        diaMaximo[indiceVariable] = indiceDia;
                    }

                    if (valor < minimoPorVariable[indiceVariable])
                    {
                        minimoPorVariable[indiceVariable] = valor;
                        diaMinimo[indiceVariable] = indiceDia;
                    }
                }
            }

            Console.WriteLine("\n   Estadísticas:");
            for (int indiceVariable = 0; indiceVariable < variables.Length; indiceVariable++)
            {
                double promedio = sumaPorVariable[indiceVariable] / dias.Length;
                Console.WriteLine($"    {variables[indiceVariable]}:");
                Console.WriteLine($"      Promedio: {promedio.ToString("F2")}");
                Console.WriteLine($"      Máximo: {maximoPorVariable[indiceVariable]} ({dias[diaMaximo[indiceVariable]]})");
                Console.WriteLine($"      Mínimo: {minimoPorVariable[indiceVariable]} ({dias[diaMinimo[indiceVariable]]})");
            }
        }

    }
}
