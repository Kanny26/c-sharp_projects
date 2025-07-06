using System;

class Program
{
    static void Main(string[] args)
    {
        // Declaración de variables
        string tienda = "";
        float totalCompra = 0;
        int metodoPago;
        int diaSemana;
        bool esVIP;

        // Menú de selección de tienda
        Console.WriteLine("Seleccione la tienda donde compró:");
        Console.WriteLine("1. Supermercado Metro");
        Console.WriteLine("2. Miniso");
        Console.WriteLine("3. Koaj");
        Console.WriteLine("4. Tennis");
        int opcionTienda = int.Parse(Console.ReadLine());

        // Asignación de la tienda seleccionada
        if (opcionTienda == 1)
        {
            tienda = "Supermercado Metro";
        }
        else if (opcionTienda == 2)
        {
            tienda = "Miniso";
        }
        else if (opcionTienda == 3)
        {
            tienda = "Koaj";
        }
        else if (opcionTienda == 4)
        {
            tienda = "Tennis";
        }
        else
        {
            Console.WriteLine("Opción no válida.");
            return;
        }

        // Menú de selección de rango de precios
        Console.WriteLine("Seleccione el rango de precios:");
        Console.WriteLine("1. Bajo: menos de $50.000");
        Console.WriteLine("2. Medio: entre $50.000 y $99.999");
        Console.WriteLine("3. Alto: entre $100.000 y $199.999");
        Console.WriteLine("4. Muy Alto: $200.000 o más");
        int opcionRango = int.Parse(Console.ReadLine());

        // Asignación del total de compra basado en el rango seleccionado
        if (opcionRango == 1)
        {
            totalCompra = 30000; // Ejemplo de un total en el rango bajo
        }
        else if (opcionRango == 2)
        {
            totalCompra = 75000; // Ejemplo de un total en el rango medio
        }
        else if (opcionRango == 3)
        {
            totalCompra = 150000; // Ejemplo de un total en el rango alto
        }
        else if (opcionRango == 4)
        {
            totalCompra = 250000; // Ejemplo de un total en el rango muy alto
        }
        else
        {
            Console.WriteLine("Opción no válida.");
            return;
        }

        // Menú de selección de método de pago
        Console.WriteLine("Seleccione el método de pago:");
        Console.WriteLine("1. Efectivo");
        Console.WriteLine("2. Tarjeta");
        Console.WriteLine("3. Cuotas");
        metodoPago = int.Parse(Console.ReadLine());

        // Menú de selección de día de la semana
        Console.WriteLine("Seleccione el día de la semana:");
        Console.WriteLine("1. Lunes");
        Console.WriteLine("2. Martes");
        Console.WriteLine("3. Miércoles");
        Console.WriteLine("4. Jueves");
        Console.WriteLine("5. Viernes");
        Console.WriteLine("6. Sábado");
        Console.WriteLine("7. Domingo");
        diaSemana = int.Parse(Console.ReadLine());

        // Pregunta si tiene membresía VIP
        Console.Write("¿Tiene membresía VIP? (s/n): ");
        esVIP = Console.ReadLine().ToLower() == "s";

        // Calcular total a pagar con posibles descuentos o recargos
        float totalAPagar = CalcularTotalAPagar(totalCompra, metodoPago, diaSemana, esVIP);

        // Mostrar el total a pagar
        Console.WriteLine($"El total a pagar en {tienda} es: {totalAPagar:C}");
    }

    // Método para calcular el total a pagar con descuentos y recargos
    static float CalcularTotalAPagar(float total, int metodoPago, int dia, bool esVIP)
    {
        float descuento = 0;

        // Aplicar descuento por día de la semana (Jueves o Domingo 10%)
        if (dia == 4 || dia == 7)
        {
            descuento += 0.10f;
        }

        // Aplicar descuento por membresía VIP (20%)
        if (esVIP)
        {
            descuento += 0.20f;
        }

        // Calcular el total con descuentos
        float totalDescuento = total * descuento;
        float totalConDescuento = total - totalDescuento;

        // Aplicar recargos según método de pago
        if (metodoPago == 1) // Efectivo (sin recargo)
        {
            // No se aplica recargo
        }
        else if (metodoPago == 2) // Tarjeta (2% de recargo)
        {
            totalConDescuento += totalConDescuento * 0.02f;
        }
        else if (metodoPago == 3) // Cuotas (5% de recargo)
        {
            totalConDescuento += totalConDescuento * 0.05f;
        }
        else
        {
            Console.WriteLine("Método de pago no válido.");
        }

        return totalConDescuento;
    }
}
