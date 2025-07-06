using System;

class ClubDeportivo
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú de Entrenamientos ---");
            Console.WriteLine("1. Ingresar datos de atletas");
            Console.WriteLine("2. Mostrar análisis de entrenamientos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida, intente de nuevo.");
                continue;
            }

            if (opcion == 1)
            {
                IngresarDatos();
            }
            else if (opcion == 2)
            {
                MostrarAnalisis();
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Saliendo...");
            }
            else
            {
                Console.WriteLine("Opción inválida, intente de nuevo.");
            }
        } while (opcion != 3);
    }

    static string[] atletas;
    static int[] entrenamientos;
    static string[] tiposEntrenamiento;
    static double[] costos;
    static int n;

    static void IngresarDatos()
    {
        Console.Write("Ingrese la cantidad de atletas: ");
        if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Cantidad inválida, debe ser un número positivo.");
            return;
        }

        atletas = new string[n];
        entrenamientos = new int[n];
        tiposEntrenamiento = new string[n];
        costos = new double[n];

        Console.WriteLine("\nTipos de entrenamiento disponibles:");
        Console.WriteLine("1. Fuerza");
        Console.WriteLine("2. Resistencia");
        Console.WriteLine("3. Velocidad");
        Console.WriteLine("4. Flexibilidad");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el nombre del atleta {i + 1}: ");
            atletas[i] = Console.ReadLine();

            Console.Write($"Ingrese la cantidad de entrenamientos de {atletas[i]}: ");
            if (!int.TryParse(Console.ReadLine(), out entrenamientos[i]) || entrenamientos[i] < 0)
            {
                Console.WriteLine("Cantidad inválida, debe ser un número positivo.");
                entrenamientos[i] = 0;
            }

            Console.Write($"Seleccione el tipo de entrenamiento de {atletas[i]} (1-4): ");
            if (!int.TryParse(Console.ReadLine(), out int tipoOpcion) || tipoOpcion < 1 || tipoOpcion > 4)
            {
                Console.WriteLine("Opción inválida, asignando 'Otro'");
                tiposEntrenamiento[i] = "Otro";
            }
            else
            {
                string[] tipos = { "Fuerza", "Resistencia", "Velocidad", "Flexibilidad" };
                tiposEntrenamiento[i] = tipos[tipoOpcion - 1];
            }

            Console.Write($"Ingrese el costo del entrenamiento de {atletas[i]}: ");
            if (!double.TryParse(Console.ReadLine(), out costos[i]) || costos[i] < 0)
            {
                Console.WriteLine("Costo inválido, asignando 0.");
                costos[i] = 0;
            }
        }
    }

    static void MostrarAnalisis()
    {
        if (atletas == null || atletas.Length == 0)
        {
            Console.WriteLine("No hay datos ingresados.");
            return;
        }

        int maxEntrenamientos = entrenamientos[0], minEntrenamientos = entrenamientos[0];
        string atletaMasEntrenamientos = atletas[0], atletaMenosEntrenamientos = atletas[0];

        for (int i = 1; i < n; i++)
        {
            if (entrenamientos[i] > maxEntrenamientos)
            {
                maxEntrenamientos = entrenamientos[i];
                atletaMasEntrenamientos = atletas[i];
            }
            if (entrenamientos[i] < minEntrenamientos)
            {
                minEntrenamientos = entrenamientos[i];
                atletaMenosEntrenamientos = atletas[i];
            }
        }

        var frecuenciaEntrenamientos = new System.Collections.Generic.Dictionary<string, int>();
        foreach (var tipo in tiposEntrenamiento)
        {
            if (frecuenciaEntrenamientos.ContainsKey(tipo))
                frecuenciaEntrenamientos[tipo]++;
            else
                frecuenciaEntrenamientos[tipo] = 1;
        }

        string entrenamientoMasFrecuente = "", entrenamientoMenosFrecuente = "";
        int maxFrecuencia = 0, minFrecuencia = int.MaxValue;

        foreach (var item in frecuenciaEntrenamientos)
        {
            if (item.Value > maxFrecuencia)
            {
                maxFrecuencia = item.Value;
                entrenamientoMasFrecuente = item.Key;
            }
            if (item.Value < minFrecuencia)
            {
                minFrecuencia = item.Value;
                entrenamientoMenosFrecuente = item.Key;
            }
        }

        double totalGasto = 0;
        foreach (double costo in costos)
            totalGasto += costo;
        double promedioGasto = n > 0 ? totalGasto / n : 0;

        Console.WriteLine($"Atleta con más entrenamientos: {atletaMasEntrenamientos} ({maxEntrenamientos} sesiones)");
        Console.WriteLine($"Atleta con menos entrenamientos: {atletaMenosEntrenamientos} ({minEntrenamientos} sesiones)");
        Console.WriteLine($"Entrenamiento más frecuente: {entrenamientoMasFrecuente} ({maxFrecuencia} veces)");
        Console.WriteLine($"Entrenamiento menos frecuente: {entrenamientoMenosFrecuente} ({minFrecuencia} veces)");
        Console.WriteLine($"Gasto total: ${totalGasto:F2}");
        Console.WriteLine($"Gasto promedio por atleta: ${promedioGasto:F2}");
    }
}