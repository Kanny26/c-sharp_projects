using System;

class SalonDeBelleza
{
    static void Main(string[] args)
    {
        // Variables para almacenar la información del cliente
        int tipoServicio;
        int longitudCabello = 0;
        int tipoManicure = 0;
        int diaSemana;
        float propina;

        // Mostrar el menú de servicios
        Console.WriteLine("Seleccione el tipo de servicio:\n");
        Console.WriteLine("1. Corte de cabello");
        Console.WriteLine("2. Tinte");
        Console.WriteLine("3. Manicure");
        Console.WriteLine("4. Pedicure");
        tipoServicio = Convert.ToInt32(Console.ReadLine());

        // Obtener información adicional según el tipo de servicio seleccionado
        if (tipoServicio == 1 || tipoServicio == 2)
        {
            // Si el servicio es corte de cabello o tinte, preguntar la longitud del cabello
            Console.WriteLine("\nSeleccione la longitud del cabello:");
            Console.WriteLine("1. Corto");
            Console.WriteLine("2. Medio");
            Console.WriteLine("3. Largo");
            longitudCabello = Convert.ToInt32(Console.ReadLine());
        }
        else if (tipoServicio == 3)
        {
            // Si el servicio es manicure, preguntar el tipo de manicure
            Console.WriteLine("\nSeleccione el tipo de manicure:");
            Console.WriteLine("1. Tradicional");
            Console.WriteLine("2. Francesa");
            Console.WriteLine("3. Gel");
            tipoManicure = Convert.ToInt32(Console.ReadLine());
        }

        // Mostrar el menú de días de la semana
        Console.WriteLine("\nSeleccione el día de la semana:");
        Console.WriteLine("1. Lunes");
        Console.WriteLine("2. Martes");
        Console.WriteLine("3. Miércoles");
        Console.WriteLine("4. Jueves");
        Console.WriteLine("5. Viernes");
        Console.WriteLine("6. Sábado");
        Console.WriteLine("7. Domingo");
        diaSemana = Convert.ToInt32(Console.ReadLine());

        // Solicitar la propina
        Console.WriteLine("\nIngrese la propina (0 si no desea dejar propina):");
        propina = Convert.ToSingle(Console.ReadLine());

        // Calcular el total del servicio
        CalcularTotal(tipoServicio, longitudCabello, tipoManicure, diaSemana, propina);
    }

    static void CalcularTotal(int tipoServicio, int longitudCabello, int tipoManicure, int diaSemana, float propina)
    {
        float precioBase = 0; // Precio base del servicio
        float descuento = 0;  // Descuento aplicado si corresponde

        // Calcular el precio base según el tipo de servicio seleccionado
        if (tipoServicio == 1) // Corte de cabello
        {
            if (longitudCabello == 1) // Corto
                precioBase = 15000;
            else if (longitudCabello == 2) // Medio
                precioBase = 20000;
            else if (longitudCabello == 3) // Largo
                precioBase = 25000;
        }
        else if (tipoServicio == 2) // Tinte
        {
            if (longitudCabello == 1) // Corto
                precioBase = 30000;
            else if (longitudCabello == 2) // Medio
                precioBase = 40000;
            else if (longitudCabello == 3) // Largo
                precioBase = 50000;
        }
        else if (tipoServicio == 3) // Manicure
        {
            if (tipoManicure == 1) // Tradicional
                precioBase = 10000;
            else if (tipoManicure == 2) // Francesa
                precioBase = 15000;
            else if (tipoManicure == 3) // Gel
                precioBase = 20000;
        }
        else if (tipoServicio == 4) // Pedicure
        {
            precioBase = 25000; // Solo hay un tipo de pedicure
        }

        // Aplicar descuento si es martes (2) o jueves (4)
        if (diaSemana == 2 || diaSemana == 4)
        {
            descuento = precioBase * 0.10f; // 10% de descuento
        }

        // Calcular el total sumando la propina y restando el descuento
        float total = precioBase - descuento + propina;

        // Mostrar el total a pagar
        Console.WriteLine($"\nEl total a pagar es: {total}");
    }
}

