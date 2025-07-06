using System;

class Joyería
{
    static void Main(string[] args)
    {
        double precio_Anillo = 15.000;
        double precio_Aretes = 13.000;
        double precio_Collar = 15.000;
        double precio_Pulsera = 8.000;

        int opcion;
        int cantidad;
        bool tieneCupon;
        double total = 0;

        Console.WriteLine("*-*-*-*-*-*-* Bienvenid@ a tu joyeria de confianza ;) *-*-*-*-*-*-* ");

        for (; ; )
        {
            Console.WriteLine("");
            Console.WriteLine("----digita el numero del producto que vas a comprar: ----");
            Console.WriteLine("1. Anillos - $15.000");
            Console.WriteLine("2. Aretes - $13.000");
            Console.WriteLine("3. Collares - $15.000");
            Console.WriteLine("4. Pulseras - $8.000");
            Console.WriteLine("0. Salir");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-* ");

            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 0)
            {
                break; 
            }

            Console.WriteLine("*** Ingrese la cantidad: ***");
            cantidad = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1)
            {
                total += precio_Anillo * cantidad;
            }
            else if (opcion == 2)
            {
                total += precio_Aretes * cantidad;
            }
            else if (opcion == 3)
            {
                total += precio_Collar * cantidad;
            }
            else if (opcion == 4)
            {
                total += precio_Pulsera * cantidad;
            }
            else
            {
                Console.WriteLine("¡Opción no válida..!");
            }
        }

        Console.WriteLine("-------------//¿Tiene un cupón de descuento? (M. para sí / N. para no): \\-------------");
        string respuesta = Console.ReadLine().Trim().ToLower();

        if (respuesta == "m")
        {
            tieneCupon = true;
        }
        else if (respuesta == "n")
        {
            tieneCupon = false;
        }
        else
        {
            Console.WriteLine("Respuesta no válida. Por favor ingrese 'M' o 'N'.");
            return;
        }

        if (tieneCupon)
        {
            total -= total * 0.10;
        }

        Console.WriteLine($"El total de su compra es: ${total:F3}");
        Console.WriteLine("********** Gracias por preferirnos, ¡Hasta luego! **********");
    }
}
