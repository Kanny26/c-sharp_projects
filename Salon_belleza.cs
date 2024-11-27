using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("\nPara iniciar el programa presione(1), Para finalizar el programa presione(2):");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                if (opcion == 1)
                {
                    string agendar;
                    string nombre;
                    int edad;
                    int mes;
                    int dia;
                    int telefono;
                    int opc;
                    string hora;

                    do
                    {
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Bienvenido al salon de belleza la venganza");
                        Console.WriteLine("1. agendar");
                        Console.WriteLine("2. SALIR");
                        Console.WriteLine("********************************************");
                        opc = Convert.ToInt32(Console.ReadLine());

                        if (opc == 1)
                        {
                            Console.WriteLine("Ingresa tu nombre: ");
                            nombre = Console.ReadLine();
                            Console.WriteLine("¿Cuántos años tienes?");
                            edad = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresa tu número telefónico");
                            telefono = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresa el mes en el cuál nos visitarás");
                            mes = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresa un día de 11 para agendarte");
                            dia = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingresa la hora en la que quieres que agendemos tu cita (formato 24h, ej. 14:30)");
                            hora = Console.ReadLine();
                            DateTime horacita;
                            while (!DateTime.TryParse(hora, out horacita))
                            {
                                Console.WriteLine("Formato de hora no válido. Intente nuevamente (ej. 14:30):");
                                hora = Console.ReadLine();
                            }
                            Console.WriteLine($"{nombre}, tu cita quedo para el {dia} del mes {mes} a las {hora}");
                        }
                        if (opc == 2)
                        {
                            Console.WriteLine("Gracias por venir!!");
                            break;
                        }
                    } while (true);
                    
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("********************************************");
                    Console.WriteLine("Finalizado. ¡Gracias por visitarnos!");
                    Console.WriteLine("********************************************");
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                }

            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }

        }
    }
}