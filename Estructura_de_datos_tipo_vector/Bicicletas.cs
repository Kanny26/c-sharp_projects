using System;

class Program
{
    static void Main()
    {
        // Declaramos un vector para almacenar los precios de alquiler
        decimal[] precios = new decimal[5];

        Console.WriteLine("¡Hola!, ¡Bienvenidos al alquiler pedaladas! \n");

        // Captura de los precios de las bicicletas
        for (int i = 0; i < precios.Length; i++)
        {
            Console.Write($"Ingrese el precio de alquiler para la bicicleta {i + 1}: ");
            precios[i] = Convert.ToDecimal(Console.ReadLine());
        }

        // Listar los precios ingresados
        Console.WriteLine("\nLista de precios de alquiler de bicicletas:");
        for (int i = 0; i < precios.Length; i++)
        {
            Console.WriteLine($"Bicicleta {i + 1}: {precios[i]}");
        }

        int opcion;
        do
        {
            // Menú de opciones
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar el precio de una bicicleta");
            Console.WriteLine("2. Modificar el precio de una bicicleta");
            Console.WriteLine("3. Calcular el precio total");
            Console.WriteLine("4. Salir");
            Console.Write("Elija una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                // Buscar el precio de una bicicleta por índice
                Console.Write("Ingrese el número de bicicleta (1-5): ");
                int indiceBuscar = Convert.ToInt32(Console.ReadLine()) - 1;
                if (indiceBuscar >= 0 && indiceBuscar < precios.Length)
                {
                    Console.WriteLine($"El precio de la bicicleta {indiceBuscar + 1} es: {precios[indiceBuscar]}");
                }
                else
                {
                    Console.WriteLine("Número de bicicleta inválido.");
                }
            }
            else if (opcion == 2)
            {
                // Modificar el precio de una bicicleta
                Console.Write("Ingrese el número de bicicleta a modificar (1-5): ");
                int indiceModificar = Convert.ToInt32(Console.ReadLine()) - 1;
                if (indiceModificar >= 0 && indiceModificar < precios.Length)
                {
                    Console.Write("Ingrese el nuevo precio: ");
                    precios[indiceModificar] = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Precio actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("Número de bicicleta inválido.");
                }
            }
            else if (opcion == 3)
            {
                // Calcular el precio total de todas las bicicletas
                decimal total = 0;
                for (int i = 0; i < precios.Length; i++)
                {
                    total += precios[i];
                }
                Console.WriteLine($"El precio total del alquiler de todas las bicicletas es: {total}");
            }
            else if (opcion == 4)
            {
                // Salir del programa
                Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }

        } while (opcion != 4);
    }
}
