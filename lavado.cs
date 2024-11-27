using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;
        while (opcion != 2) // Mientras no elija finalizar
        {
            Console.WriteLine("Para iniciar el programa presione(1), Para finalizar el programa presione(2):");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                if (opcion == 1)
                {
                    Console.WriteLine("Bienvenido al sistema de lavado de !!!INFINITY WASH¡¡¡");
                    bool continuar = true;

                    while (continuar) // Menú principal
                    {
                        Console.WriteLine("\nMENU DE OPCIONES:");
                        Console.WriteLine("Opcion (1) para lavado");
                        Console.WriteLine("Opcion (2) para parqueo");
                        Console.WriteLine("Opcion (0) para terminar");
                        Console.Write("Ingrese una opcion: ");
                        string opcionMenu = Console.ReadLine();

                        if (opcionMenu == "1") // Lavado
                        {
                            RealizarLavado();
                        }
                        else if (opcionMenu == "2") // Parqueo (puedes implementar después)
                        {
                            Console.WriteLine("Opción de parqueo aún no implementada.");
                        }
                        else if (opcionMenu == "0") // Terminar
                        {
                            continuar = false;
                            Console.WriteLine("Gracias por usar INFINITY WASH.");
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                        }
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("Finalizado. ¡Gracias por usar INFINITY WASH!");
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

    static void RealizarLavado()
    {
        Console.WriteLine("\nIngrese el tipo de vehículo a lavar:");
        Console.WriteLine("Opcion (1) para CARRO");
        Console.WriteLine("Opcion (2) para CAMIONETA");
        Console.WriteLine("Opcion (3) para MOTO");
        string tipoVehiculo = Console.ReadLine();

        while (tipoVehiculo != "1" && tipoVehiculo != "2" && tipoVehiculo != "3")
        {
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            Console.Write("Ingrese una opción: ");
            tipoVehiculo = Console.ReadLine();
        }

        Console.WriteLine("\nTIPOS DE LAVADO:");
        Console.WriteLine("Opcion (1) lavado sencillo ($5000)");
        Console.WriteLine("Opcion (2) lavado semicompleto ($10000)");
        Console.WriteLine("Opcion (3) lavado completo ($20000)");
        string tipoLavado = Console.ReadLine();

        while (tipoLavado != "1" && tipoLavado != "2" && tipoLavado != "3")
        {
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            Console.Write("Ingrese una opción: ");
            tipoLavado = Console.ReadLine();
        }

        int precio = 0;
        if (tipoLavado == "1")
        {
            precio = 5000;
        }
        else if (tipoLavado == "2")
        {
            precio = 10000;
        }
        else if (tipoLavado == "3")
        {
            precio = 20000;
        }

        Console.Write("\nIngrese la marca del vehículo: ");
        string marca = Console.ReadLine();

        Console.Write("Ingrese el modelo del vehículo: ");
        string modelo = Console.ReadLine();

        Console.Write("Ingrese el nombre del propietario: ");
        string propietario = Console.ReadLine();

        Console.Write("Ingrese el número de teléfono del propietario: ");
        string telefono = Console.ReadLine();

        Console.WriteLine($"\nEl valor a pagar por el lavado es de: ${precio}");
        Console.WriteLine($"Vehículo: {marca} {modelo}");
        Console.WriteLine($"Propietario: {propietario}");
        Console.WriteLine($"Teléfono: {telefono}");

        Console.WriteLine("\n¿Desea volver a inicializar el programa?");
        Console.WriteLine("(Si) presione(1), (No) presione(2)");
    }
}
