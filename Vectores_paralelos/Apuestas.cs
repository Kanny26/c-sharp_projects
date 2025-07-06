using System;

namespace Ruleta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******************************************");
            Console.WriteLine("* Bienvenidos al juego de la ruleta *");
            Console.WriteLine("******************************************");
            Console.ResetColor();
            Console.WriteLine("\n¡Puede hacer hasta 10 apuestas!");

            string[] colores = { "Rosado", "Negro" };
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
            string[] tiposApuestas = { "Color", "Número", "Número y Color" };

            int opcion;
            double montoApuesta;
            bool continuar = true;
            Random rnd = new Random();

            while (continuar)
            {
                Console.WriteLine("\nPor favor, elija el tipo de apuesta que desea realizar:");
                Console.WriteLine("1. Apostar a un color (Rosado-Negro)");
                Console.WriteLine("2. Apostar a un número (1-28)");
                Console.WriteLine("3. Apostar a un número y a un color");
                Console.Write("Ingrese su opción (numérica): ");
                opcion = int.Parse(Console.ReadLine());

                Console.Write("¿Cuánto desea apostar?: ");
                montoApuesta = double.Parse(Console.ReadLine());

                int numeroGanador = rnd.Next(1, 29);
                string colorGanador = colores[rnd.Next(0, 2)];

                if (opcion == 1)
                {
                    Console.WriteLine("\nHa elegido apostar a un color.");
                    Console.Write("Elija un color (1. Rosado, 2. Negro): ");
                    int colorElegido = int.Parse(Console.ReadLine()) - 1;

                    if (colorElegido < 0 || colorElegido > 1)
                    {
                        Console.WriteLine("Opción de color no válida.");
                    }
                    else if (colores[colorElegido] == colorGanador)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n¡Felicidades! Ganó {montoApuesta * 2} pesos. El color ganador fue {colorGanador}.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nLo siento, perdió {montoApuesta} pesos. El color ganador fue {colorGanador}.");
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("\nHa elegido apostar a un número.");
                    Console.Write("Elija un número (1-28): ");
                    int numeroElegido = int.Parse(Console.ReadLine());

                    if (numeroElegido < 1 || numeroElegido > 28)
                    {
                        Console.WriteLine("Número fuera de rango.");
                    }
                    else if (numeroElegido == numeroGanador)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n¡Felicidades! Ganó {montoApuesta * 10} pesos. El número ganador fue {numeroGanador}.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nLo siento, perdió {montoApuesta} pesos. El número ganador fue {numeroGanador}.");
                    }
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("\nHa elegido apostar a un número y a un color.");
                    Console.Write("Elija un número (1-28): ");
                    int numeroElegido = int.Parse(Console.ReadLine());
                    Console.Write("Elija un color (1. Rosado, 2. Negro): ");
                    int colorElegido = int.Parse(Console.ReadLine()) - 1;

                    if (numeroElegido < 1 || numeroElegido > 28 || colorElegido < 0 || colorElegido > 1)
                    {
                        Console.WriteLine("Número o color fuera de rango.");
                    }
                    else if (numeroElegido == numeroGanador && colores[colorElegido] == colorGanador)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n¡Felicidades! Ganó {montoApuesta * 20} pesos. El número ganador fue {numeroGanador} y el color ganador fue {colorGanador}.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nLo siento, perdió {montoApuesta} pesos. El número ganador fue {numeroGanador} y el color ganador fue {colorGanador}.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }

                Console.ResetColor();
                Console.Write("\n¿Desea realizar otra apuesta? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nGracias por jugar. ¡Vuelva pronto!");
            Console.ResetColor();
        }
    }
}