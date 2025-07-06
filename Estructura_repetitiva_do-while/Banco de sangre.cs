using System;

namespace BancoDeSangre
{
    class Program
    {
        static void Main(string[] args)
        {
            int donantes = 0;
            int edad = 0;
            int opcion;
            int enfermedadespecifica;
            string nombre;

            do
            {
                Console.WriteLine("\n--- Banco de Sangre ---");
                Console.WriteLine("1. Registrar donante");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1) // Registrar donante
                {
                    Console.WriteLine("Ingresa el nombre del donante: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa la edad del donante: ");
                    edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el tipo de sangre: ");
                    string tipodesangre = Console.ReadLine();

                    Console.WriteLine("Padece de alguna enfermedad (responde si o no)");
                    string enfermedad = Console.ReadLine().ToLower();

                    if (enfermedad == "si")
                    {
                        Console.WriteLine("Indica cual de las siguientes enfermedades padece:");
                        Console.WriteLine("1. hepatitis a");
                        Console.WriteLine("2. hepatitis b");
                        Console.WriteLine("3.hepatitis c");
                        Console.WriteLine("4. vih");
                        Console.WriteLine("5. cancer");
                        enfermedadespecifica = Convert.ToInt32(Console.ReadLine());

                        if (enfermedadespecifica == 1)
                        {
                            Console.WriteLine("Lo sentimos, no puede donar sangre.");
                        }
                            if (enfermedadespecifica == 2)
                            {
                                Console.WriteLine("Lo sentimos, no puede donar sangre.");
                            }
                                if (enfermedadespecifica == 3)
                                {
                                    Console.WriteLine("Lo sentimos, no puede donar sangre.");
                                }
                                    if (enfermedadespecifica == 4)
                                    {
                                        Console.WriteLine("Lo sentimos, no puede donar sangre.");
                                    }
                                        if (enfermedadespecifica == 5)
                                        {
                                            Console.WriteLine("Lo sentimos, no puede donar sangre.");
                                        }
                    }
                    else if (enfermedad == "no")
                    {
                        Console.WriteLine("El donante ha sido registrado y puedes donar sangre");
                        donantes++;
                    }
                }
                if (opcion == 2)
                {
                    Console.WriteLine("********************************************");
                    Console.WriteLine("Finalizado. ¡Gracias por visitarnos!");
                    Console.WriteLine("********************************************");
                }

            } while (true);
        }
    }
}