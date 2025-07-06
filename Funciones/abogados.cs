using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable para controlar si el usuario desea continuar con otro cálculo
        bool continuar = true;

        while (continuar)
        {
            // Menú para seleccionar el tipo de caso legal
            Console.WriteLine("Seleccione el tipo de caso:");
            Console.WriteLine("1. Consulta");
            Console.WriteLine("2. Divorcio");
            Console.WriteLine("3. Penal");
            Console.WriteLine("4. Corporativo");
            Console.WriteLine("5. Civil");
            int tipoCaso = Convert.ToInt32(Console.ReadLine());

            float duracionHoras = 0;
            bool duracionValida = false;

            // Bucle para asegurarse de que la duración ingresada es válida
            while (!duracionValida)
            {
                // Menú para seleccionar el rango de duración del caso
                Console.WriteLine("Seleccione la duración estimada en horas:");
                Console.WriteLine("1. 5 a 10 horas");
                Console.WriteLine("2. 11 a 20 horas");
                Console.WriteLine("3. 21 a 50 horas");
                Console.WriteLine("4. Más de 50 horas");
                int opcionDuracion = Convert.ToInt32(Console.ReadLine());

                // Validación de la duración ingresada según la opción seleccionada
                if (opcionDuracion == 1)
                {
                    Console.WriteLine("Ingrese la duración en horas (5 a 10):");
                    duracionHoras = float.Parse(Console.ReadLine());
                    if (duracionHoras >= 5 && duracionHoras <= 10)
                    {
                        duracionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Duración no válida. Debe estar entre 5 y 10 horas.");
                    }
                }
                else if (opcionDuracion == 2)
                {
                    Console.WriteLine("Ingrese la duración en horas (11 a 20):");
                    duracionHoras = float.Parse(Console.ReadLine());
                    if (duracionHoras >= 11 && duracionHoras <= 20)
                    {
                        duracionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Duración no válida. Debe estar entre 11 y 20 horas.");
                    }
                }
                else if (opcionDuracion == 3)
                {
                    Console.WriteLine("Ingrese la duración en horas (21 a 50):");
                    duracionHoras = float.Parse(Console.ReadLine());
                    if (duracionHoras >= 21 && duracionHoras <= 50)
                    {
                        duracionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Duración no válida. Debe estar entre 21 y 50 horas.");
                    }
                }
                else if (opcionDuracion == 4)
                {
                    Console.WriteLine("Ingrese la duración en horas (más de 50):");
                    duracionHoras = float.Parse(Console.ReadLine());
                    if (duracionHoras > 50)
                    {
                        duracionValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Duración no válida. Debe ser mayor a 50 horas.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }

            // Pregunta si el cliente es recurrente
            Console.WriteLine("¿Es cliente recurrente?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
            int clienteRecurrenteInput = Convert.ToInt32(Console.ReadLine());
            bool clienteRecurrente = clienteRecurrenteInput == 1;

            // Calcular el costo del caso
            float totalAPagar = CalcularCosto(tipoCaso, duracionHoras, clienteRecurrente);
            Console.WriteLine($"El total a pagar es: {totalAPagar}");

            // Pregunta si el usuario desea calcular otro costo
            Console.WriteLine("¿Desea calcular otro costo?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
            int continuarInput = Convert.ToInt32(Console.ReadLine());
            continuar = continuarInput == 1;
        }
    }

    // Método para calcular el costo del caso según el tipo, la duración y si el cliente es recurrente
    static float CalcularCosto(int tipoCaso, float duracionHoras, bool clienteRecurrente)
    {
        float tarifaPorHora = 0;

        // Asignación de tarifa por hora según el tipo de caso
        if (tipoCaso == 1) // Consulta
        {
            tarifaPorHora = 20000; // Tarifa para consulta
        }
        else if (tipoCaso == 2) // Divorcio
        {
            tarifaPorHora = 50000; // Tarifa para divorcio
        }
        else if (tipoCaso == 3) // Penal
        {
            tarifaPorHora = 75000; // Tarifa para penal
        }
        else if (tipoCaso == 4) // Corporativo
        {
            tarifaPorHora = 100000; // Tarifa para corporativo
        }
        else if (tipoCaso == 5) // Civil
        {
            tarifaPorHora = 30000; // Tarifa para civil
        }

        // Cálculo del costo base
        float costoBase = tarifaPorHora * duracionHoras;

        // Aplicar descuento del 20% si el cliente es recurrente
        if (clienteRecurrente)
        {
            costoBase *= 0.8f;
        }

        return costoBase;
    }
}
