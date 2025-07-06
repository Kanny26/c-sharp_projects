using System;

namespace Solfruit
{
    class Program
    {
        static void Main()
        {
            double[] preciosFrutas = { 500, 1.500, 2.500, 400, 1.800 };

            int opcion;
            int cantidad;
            double total = 0;
            int cantidadTotalFrutas = 0;

            while (true)
            {
                MostrarMenu();

                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > preciosFrutas.Length)
                {
                    Console.WriteLine("Opción inválida. Por favor, elige una opción del menú.");
                    continue;
                }
                if (opcion == 0)
                    break;

                Console.Write("Ingresa la cantidad que desea comprar: ");
                if (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Cantidad inválida. Por favor, ingresa un número entero positivo.");
                    continue;
                }

                double precioFruta = preciosFrutas[opcion - 1];
                total += precioFruta * cantidad;
                cantidadTotalFrutas += cantidad;

                Console.WriteLine($"Se agregaron {cantidad} {ObtenerNombreFruta(opcion)} al carrito.");
            }

            Console.WriteLine("\nResumen de la compra:");
            Console.WriteLine($"Total a pagar: ${total}");
            Console.WriteLine($"Cantidad total de frutas: {cantidadTotalFrutas}");
            Console.WriteLine("********** Gracias por preferirnos, ¡Hasta luego! **********");
        }

        static void MostrarMenu()
          {
              Console.WriteLine("Buen día");
              Console.WriteLine("¿Qué frutas desea comprar hoy?");
              Console.WriteLine("1. Manzanas");
              Console.WriteLine("2. Peras");
              Console.WriteLine("3. Uvas");
              Console.WriteLine("4. Mandarinas");
              Console.WriteLine("5. Mangos");
              Console.WriteLine("0. Finalizar");
          }

        static string ObtenerNombreFruta(int opcion)
        {
            string[] nombresFrutas = { "Manzanas", "Peras", "Uvas", "Mandarinas", "Mangos" };
            return nombresFrutas[opcion - 1];
        }
    }
}