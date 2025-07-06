using System;

class Program
{
    static void Main(string[] args)
    {
        int costoTotal = 0; // Inicializa el costo total de la compra en 0
        string continuar = "s"; // Variable para controlar si el usuario quiere seguir comprando

        do
        {
            // Menú de selección de verduras
            Console.WriteLine("Seleccione una verdura:");
            Console.WriteLine("1. Zanahoria - $1500/kg");
            Console.WriteLine("2. Tomate - $2000/kg");
            Console.WriteLine("3. Lechuga - $1200/kg");
            Console.WriteLine("4. Cebolla - $800/kg");
            Console.WriteLine("5. Papa - $1000/kg");
            Console.WriteLine("6. Yuca - $900/kg");
            Console.WriteLine("7. Limón - $300/kg");
            Console.WriteLine("8. Salir");

            int seleccion = int.Parse(Console.ReadLine()); // Captura la selección del usuario

            if (seleccion == 8)
            {
                break; // Termina el bucle si el usuario elige salir
            }

            int precioPorKilogramo = 0; // Variable para almacenar el precio por kg de la verdura seleccionada

            // Asignar el precio correspondiente según la selección del usuario
            if (seleccion == 1)
            {
                precioPorKilogramo = 1500;
            }
            else if (seleccion == 2)
            {
                precioPorKilogramo = 2000;
            }
            else if (seleccion == 3)
            {
                precioPorKilogramo = 1200;
            }
            else if (seleccion == 4)
            {
                precioPorKilogramo = 800;
            }
            else if (seleccion == 5)
            {
                precioPorKilogramo = 1000;
            }
            else if (seleccion == 6)
            {
                precioPorKilogramo = 900;
            }
            else if (seleccion == 7)
            {
                precioPorKilogramo = 300;
            }
            else
            {
                Console.WriteLine("Selección no válida. Intente de nuevo.");
                continue; // Vuelve al inicio del bucle si la selección no es válida
            }

            // Solicitar la cantidad de kilogramos al usuario
            Console.WriteLine("Ingrese la cantidad en kilogramos:");
            int cantidad = int.Parse(Console.ReadLine());

            // Calcular el costo de la cantidad seleccionada
            int costo = precioPorKilogramo * cantidad;
            costoTotal += costo; // Acumular el costo total de la compra

            // Mostrar el costo de la compra actual y el total acumulado
            Console.WriteLine($"Costo de {cantidad} kg: ${costo}");
            Console.WriteLine($"Costo total hasta ahora: ${costoTotal}");

            // Preguntar si el usuario quiere agregar otra verdura
            Console.WriteLine("¿Desea agregar otra verdura? (s/n)");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "s"); // Repetir mientras el usuario quiera seguir comprando

        // Mostrar el costo total final de la compra
        Console.WriteLine($"El costo total de su compra es: ${costoTotal}");
    }
}
