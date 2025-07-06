using System;

class Gimnasio
{
    static void Main()
    {
        bool salir = false;

        do
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("  Bienvenido a nuestro gimnasio");
            Console.WriteLine("  1. Lista de nuestras membresías");
            Console.WriteLine("  2. Registro de membresía");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine();
            Console.Write(" Seleccione alguna de las opciones: ");
            Console.WriteLine();
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                ListaMembresias();
            }
            else if (opcion == "2")
            {
                RegistrarMembresia();
            }
            else
            {
                Console.WriteLine(" Opción no válida. Intente nuevamente.");
            }

        } while (!salir);
    }

    static void ListaMembresias()
    {
        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        Console.WriteLine("  Membresía mensual estándar: $50.000");
        Console.WriteLine("  Membresía trimestral: $150.000");
        Console.WriteLine("  Membresía anual: $400.000");
        Console.WriteLine("  Membresía familiar: $80.000");
        Console.WriteLine("  Membresía VIP: $100.000");
        Console.WriteLine("  Membresía estudiantes: $60.000");
        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        Console.WriteLine();
    }

    static void RegistrarMembresia()
    {
        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        Console.WriteLine("  Bienvenido al sistema de registro de membresía");

        Console.Write("  Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("  Ingrese su dirección: ");
        string direccion = Console.ReadLine();
         
        Console.Write("  Ingrese su edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("  Ingrese su correo electrónico: ");
        string email = Console.ReadLine();

        Console.Write("  Ingrese su sexo (M/F): ");
        string sexo = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("  ¿Desea continuar con el registro?");
        Console.Write("  Seleccione 1 para continuar y 2 para cancelar: ");
        int continuar = int.Parse(Console.ReadLine());

        if (continuar == 1)
        {
            Console.WriteLine();
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine($"  Su registro ha sido realizado con éxito.");
            Console.WriteLine($"  Bienvenido {nombre}");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            ElegirMembresia(nombre);
        }
        else
        {
            Console.WriteLine("  Registro cancelado.");
            return;
        }
    }

    static void ElegirMembresia(string nombre)
    {
        bool finalizar = false;

        do
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("  Marca 1 para elegir la membresía que deseas");
            Console.WriteLine("  Marca 2 para volver al menú");
            Console.WriteLine("  Marca 3 para finalizar el programa");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.Write("  Elije una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.WriteLine("  ¿Cuál membresía deseas elegir?");
                ListaMembresias();

                Console.Write("  Seleccione el número de membresía (1-6): ");
                int membresia = int.Parse(Console.ReadLine());

                if (membresia == 3)
                {
                    Console.WriteLine("  Membresía anual con un descuento del 10% quedaría en: $360.000");
                }
                else
                {
                    Console.WriteLine("  Opción de membresía seleccionada.");
                }
            }
            else if (opcion == 2)
            {
                Console.WriteLine("  Volviendo al menú principal...");
                finalizar = true;
            }
            else if (opcion == 3)
            {
                Console.WriteLine($"  Gracias por visitarnos, {nombre}. ¡Hasta luego!");
                finalizar = true;
            }
            else
            {
                Console.WriteLine("  Opción no válida. Intente nuevamente.");
                return;
            }

        } while (!finalizar);
    }
}
