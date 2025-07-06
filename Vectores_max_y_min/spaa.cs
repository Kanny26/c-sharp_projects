using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el número de clientes: ");
        int n = int.Parse(Console.ReadLine());

        string[] nombres = new string[n];
        int[] edades = new int[n];
        double[] pesos = new double[n];
        int[] visitas = new int[n];
        double[] gastos = new double[n];

        int MasJoven = 0, MayorEdad = 0;
        int MenorPeso = 0, MayorPeso = 0;
        int MayorGasto = 0, MenorGasto = 0;
        double sumaEdad = 0, sumaPeso = 0, sumaVisitas = 0, sumaGasto = 0;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Cliente {i + 1}:");
            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();
            Console.Write("Edad: ");
            edades[i] = int.Parse(Console.ReadLine());
            Console.Write("Peso (kg): ");
            pesos[i] = double.Parse(Console.ReadLine());
            Console.Write("Número de visitas mensuales: ");
            visitas[i] = int.Parse(Console.ReadLine());
            Console.Write("Gasto promedio mensual: ");
            gastos[i] = double.Parse(Console.ReadLine());

            sumaEdad += edades[i];
            sumaPeso += pesos[i];
            sumaVisitas += visitas[i];
            sumaGasto += gastos[i];

            if (edades[i] < edades[MasJoven]) MasJoven = i;
            if (edades[i] > edades[MayorEdad]) MayorEdad = i;
            if (pesos[i] < pesos[MenorPeso]) MenorPeso = i;
            if (pesos[i] > pesos[MayorPeso]) MayorPeso = i;
            if (gastos[i] > gastos[MayorGasto]) MayorGasto = i;
            if (gastos[i] < gastos[MenorGasto]) MenorGasto = i;
        }

        Console.WriteLine($"Cliente más joven: {nombres[MasJoven]} ({edades[MasJoven]} años)");
        Console.WriteLine($"Cliente de mayor edad: {nombres[MayorEdad]} ({edades[MayorEdad]} años)");
        Console.WriteLine($"Cliente con menor peso: {nombres[MenorPeso]} ({pesos[MenorPeso]} kg)");
        Console.WriteLine($"Cliente con mayor peso: {nombres[MayorPeso]} ({pesos[MayorPeso]} kg)");
        Console.WriteLine($"Cliente que más gasta: {nombres[MayorGasto]} (${gastos[MayorGasto]:F2})");
        Console.WriteLine($"Cliente que menos gasta: {nombres[MenorGasto]} (${gastos[MenorGasto]:F2})");

        Console.WriteLine($"Promedio de edad: {sumaEdad / n:F2} años");
        Console.WriteLine($"Promedio de peso: {sumaPeso / n:F2} kg");
        Console.WriteLine($"Promedio de visitas: {sumaVisitas / n:F2}");
        Console.WriteLine($"Promedio de gasto mensual: ${sumaGasto / n:F2}");

        Console.WriteLine("Clasificación de fidelidad:");
        for (int i = 0; i < n; i++)
        {
            string fidelidad = visitas[i] >= 10 ? "Cliente VIP" : (visitas[i] >= 5 ? "Cliente Frecuente" : "Cliente Ocasional");
            Console.WriteLine($"{nombres[i]} - {fidelidad}");
        }
    }
}