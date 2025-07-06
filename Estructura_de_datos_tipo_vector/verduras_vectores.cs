using System;

class Program
{
    static void Main()
    {
        // Declaración de un arreglo para almacenar 10 verduras
        string[] verduras = new string[10];
        Console.WriteLine("¡Hola!, ¡Bienvenidos a la verduleria verdes y saludables!");

        // Pedir al usuario que ingrese las verduras
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Ingrese la verdura {i + 1}: ");
            verduras[i] = Console.ReadLine(); // Guardar la entrada del usuario en el arreglo
        }

        bool salir = false; // Variable de control para salir del menú
        while (!salir)
        {
            // Mostrar el menú de opciones al usuario
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar una verdura");
            Console.WriteLine("2. Listar todas las verduras compradas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine(); // Leer la opción ingresada por el usuario

            if (opcion == "1")
            {
                // Opción para buscar una verdura en la lista
                Console.Write("Ingrese la verdura que desea buscar: ");
                string buscar = Console.ReadLine();
                int contador = 0;

                // Contar cuántas veces aparece la verdura ingresada
                for (int i = 0; i < verduras.Length; i++)
                {
                    if (verduras[i].ToLower() == buscar.ToLower())//Compara las verduras
                    {
                        contador++;
                    }
                }

                Console.WriteLine($"La verdura '{buscar}' aparece {contador} veces en la lista.");
            }
            else if (opcion == "2")
            {
                // Opción para listar todas las verduras compradas
                Console.WriteLine("Lista de verduras compradas:");
                for (int i = 0; i < verduras.Length; i++)
                {
                    Console.WriteLine("- " + verduras[i]);
                }
            }
            else if (opcion == "3")
            {
                // Opción para salir del programa
                salir = true;
                Console.WriteLine("Gracias por su compra. ¡Vuelva pronto!");
            }
            else
            {
                // Mensaje de error si el usuario ingresa una opción inválida
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
