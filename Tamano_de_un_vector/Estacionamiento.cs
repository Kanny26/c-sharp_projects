using System;

class Estacionamiento
{
    static int capacidad; // Número de vehículos a registrar
    static Cliente[] clientes;
    static int contadorClientes = 0; // Contador de clientes

    static void Main()
    {
        Console.Write("Bienvenidos al sistema de estacionamiento la venganza: ");
        Console.Write("Ingrese la cantidad de vehículos que ingresarán hoy: ");
        capacidad = int.Parse(Console.ReadLine());

        clientes = new Cliente[capacidad];

        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ ESTACIONAMIENTO ===");
            Console.WriteLine("1. Ingresar vehículo");
            Console.WriteLine("2. Mostrar facturas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                if (contadorClientes < capacidad)
                {
                    IngresarVehiculo();
                }
                else
                {
                    Console.WriteLine("Se ha alcanzado el límite de vehículos registrados hoy.");
                }
            }
            else if (opcion == "2")
            {
                MostrarFacturas();
            }
            else if (opcion == "3")
            {
                Console.WriteLine("Saliendo del sistema...");
                continuar = false;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }

    static void IngresarVehiculo()
    {
        Console.WriteLine("\n=== REGISTRO DE VEHÍCULO ===");
        Console.Write("Nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Cédula del cliente: ");
        string cedula = Console.ReadLine();

        Console.Write("Placa del vehículo: ");
        string placa = Console.ReadLine();

        Console.Write("Color del vehículo: ");
        string color = Console.ReadLine();

        Console.Write("Número de horas de estacionamiento: ");
        int horas = int.Parse(Console.ReadLine());

        int pago = horas * 2000; // Cálculo del pago total

        clientes[contadorClientes] = new Cliente(contadorClientes + 1, nombre, cedula, placa, color, horas, pago);
        Console.WriteLine($"\nVehículo registrado exitosamente con Número de Cliente: {contadorClientes + 1}");

        contadorClientes++; // Incrementa el contador
    }

    static void MostrarFacturas()
    {
        Console.WriteLine("\n=== FACTURAS DEL DÍA ===");
        if (contadorClientes == 0)
        {
            Console.WriteLine("No hay facturas registradas.");
            return;
        }

        for (int i = 0; i < contadorClientes; i++) 
        {
            Cliente cliente = clientes[i];
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"Número de Cliente: {cliente.NumeroCliente}");
            Console.WriteLine($"Nombre: {cliente.Nombre}");
            Console.WriteLine($"Cédula: {cliente.Cedula}");
            Console.WriteLine($"Placa del Vehículo: {cliente.Placa}");
            Console.WriteLine($"Color del Vehículo: {cliente.Color}");
            Console.WriteLine($"Horas de Estacionamiento: {cliente.Horas}");
            Console.WriteLine($"Total a Pagar: ${cliente.pago}");
            Console.WriteLine("----------------------------------\n");
        }
    }
}

class Cliente
{
    public int NumeroCliente { get; }
    public string Nombre { get; }
    public string Cedula { get; }
    public string Placa { get; }
    public string Color { get; }
    public int Horas { get; }
    public int pago { get; }

    public Cliente(int numeroCliente, string nombre, string cedula, string placa, string color, int horas, int pago)
    {
        NumeroCliente = numeroCliente;
        Nombre = nombre;
        Cedula = cedula;
        Placa = placa;
        Color = color;
        Horas = horas;
        pago = pago;
    }
}
