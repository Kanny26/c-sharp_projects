using System;

namespace equipoFutbol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (partidosJugados, partidosGanados) = partidos();
            calculo(partidosJugados, partidosGanados);
        }

        static (int, int) partidos()
        {
            Console.WriteLine("--- Bienvenido al sistema de calculo ---");
            Console.Write("Ingrese el total de partidos jugados: ");
            int partidosJugados = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el total de partidos ganados: ");
            int partidosGanados = int.Parse(Console.ReadLine());

            return (partidosJugados, partidosGanados);
        }

        static void calculo(int partidosJugados, int partidosGanados)
        {
            float porcentaje = 0;
            if (partidosJugados > 0)
            {
                porcentaje = (float)partidosGanados / partidosJugados * 100;
            }

            Console.WriteLine($"El porcentaje de partidos ganados es: {porcentaje:F2}%");
        }
    }
}