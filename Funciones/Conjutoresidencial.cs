using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicitar información al residente
        Console.Write("Ingrese el nombre del residente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el número de apartamento: ");
        string numeroApartamento = Console.ReadLine();

        Console.Write("Ingrese el valor base de la cuota de mantenimiento: ");
        float valorBase = float.Parse(Console.ReadLine());

        // Preguntar por el uso de servicios adicionales
        Console.Write("¿Usa piscina? (s/n): ");
        bool usaPiscina = Console.ReadLine().ToLower() == "s";

        Console.Write("¿Usa gimnasio? (s/n): ");
        bool usaGimnasio = Console.ReadLine().ToLower() == "s";

        Console.Write("¿Usa parqueadero? (s/n): ");
        bool usaParqueadero = Console.ReadLine().ToLower() == "s";

        // Solicitar la cantidad de días de mora en el pago
        Console.Write("Ingrese la mora en el pago (en días): ");
        int moraDias = int.Parse(Console.ReadLine());

        // Calcular el total a pagar
        CalcularTotalAPagar(nombre, numeroApartamento, valorBase, usaPiscina, usaGimnasio, usaParqueadero, moraDias);
    }

    static void CalcularTotalAPagar(string nombre, string numeroApartamento, float valorBase, bool usaPiscina, bool usaGimnasio, bool usaParqueadero, int moraDias)
    {
        float total = valorBase;

        // Agregar costos de servicios adicionales
        if (usaPiscina)
        {
            total += 50000; // Costo adicional por uso de piscina
        }
        if (usaGimnasio)
        {
            total += 30000; // Costo adicional por uso de gimnasio
        }
        if (usaParqueadero)
        {
            total += 20000; // Costo adicional por uso de parqueadero
        }

        // Calcular recargo por mora
        if (moraDias > 0)
        {
            total += (valorBase * 0.05f) * moraDias; // 5% de recargo por cada día de mora
        }

        // Mostrar el total a pagar
        Console.WriteLine("\nResumen de pago:");
        Console.WriteLine($"Nombre del residente: {nombre}");
        Console.WriteLine($"Número de apartamento: {numeroApartamento}");
        Console.WriteLine($"Total a pagar: ${total}");
    }
}

