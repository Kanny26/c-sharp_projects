using System;

class Glamping
{
    class Reservacion
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string MetodosPago { get; set; }
        public int Cantpersonas { get; set; }
        public int Tipoglamping { get; set; }
    }

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("------ BIENVENIDOS AL GLAMPING POLUS ------");
            Console.WriteLine("Precio por noche:");
            Console.WriteLine("1. Glamping basico (100.000) - Pareja");
            Console.WriteLine("2. Glamping especial (150.000) - Pareja");
            Console.WriteLine("3. Glamping eternal (250.000) - Familiar");
            Console.WriteLine("4. Glamping presidencial (400.000) - Familiar");
            Console.WriteLine("Deseas realizar una reserva:");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");
            Console.Write("Elige una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out int opc) || (opc < 1 || opc > 2))
            {
                Console.WriteLine("Opción inválida. Presiona cualquier tecla para intentarlo nuevamente.");
                Console.ReadKey();
                continue;
            }

            if (opc == 1)
            {
                HacerReservacion();
            }
            else
            {
                exit = true;
                Console.WriteLine("Gracias por visitar Glamping Polus. ¡Hasta pronto!");
            }
        }
    }

    static void HacerReservacion()
    {
        Reservacion reservacion = new Reservacion();
        Console.Clear();
        Console.WriteLine("TIPOS DE GLAMPINGS:");
        Console.WriteLine("1. Glamping basico - Pareja");
        Console.WriteLine("2. Glamping especial - Pareja");
        Console.WriteLine("3. Glamping eternal - Familiar");
        Console.WriteLine("4. Glamping presidencial - Familiar");
        Console.Write("Escribe el número del glamping que deseas reservar: ");

        if (!int.TryParse(Console.ReadLine(), out int tipoGlamping) || tipoGlamping < 1 || tipoGlamping > 4)
        {
            Console.WriteLine("Tipo de glamping inválido. Reserva cancelada.");
            return;
        }

        reservacion.Tipoglamping = tipoGlamping;

        Console.Write("Ingrese los siguientes datos para realizar la reserva:\n");
        Console.Write("Nombres y apellidos: ");
        reservacion.Nombre = Console.ReadLine();
        Console.Write("Fecha (DD/MM/AAAA): ");
        reservacion.Fecha = Console.ReadLine();
        Console.Write("Medio de pago (Efectivo - Tarjeta - Transferencia): ");
        reservacion.MetodosPago = Console.ReadLine();
        Console.Write("Cantidad de personas que ingresan: ");

        // Validación de la cantidad de personas
        if (!int.TryParse(Console.ReadLine(), out int cantPersonas) || cantPersonas < 1)
        {
            Console.WriteLine("Cantidad de personas inválida. Reserva cancelada.");
            return;
        }

        reservacion.Cantpersonas = cantPersonas;

        int price = GetPrice(reservacion.Tipoglamping);
        Console.Clear();
        Console.WriteLine("Su reserva está en proceso, por favor verifique si los siguientes datos son correctos:");
        Console.WriteLine($"La reserva queda agendada para {reservacion.Nombre}, para la fecha {reservacion.Fecha}. Se pagará por el medio ({reservacion.MetodosPago}), y el número de personas es {reservacion.Cantpersonas}.");
        Console.WriteLine("Los datos son correctos:");
        Console.WriteLine("1. Si");
        Console.WriteLine("2. No");
        Console.Write("Elige una opcion: ");

        if (!int.TryParse(Console.ReadLine(), out int confirmar) || (confirmar < 1 || confirmar > 2))
        {
            Console.WriteLine("Opción inválida. Reserva cancelada.");
            return;
        }

        if (confirmar == 1)
        {
            Console.WriteLine("Reserva realizada con éxito.");
            Console.WriteLine($"Valor a pagar: ${price}");
        }
        else
        {
            Console.WriteLine("La reserva ha sido cancelada.");
        }

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }


    static int GetPrice(int Tiposglamping)
    {
        // Reemplazo del switch con if-else
        if (Tiposglamping == 1)
        {
            return 100000;
        }
        else if (Tiposglamping == 2)
        {
            return 150000;
        }
        else if (Tiposglamping == 3)
        {
            return 250000;
        }
        else if (Tiposglamping == 4)
        {
            return 400000;
        }
        else
        {
            return 0; 
        }
    }
}
