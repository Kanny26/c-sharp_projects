using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;
        while (opcion != 2) 
        {
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("\nPara iniciar el programa presione(1), Para finalizar el programa presione(2):");
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                if (opcion == 1)
                {
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine("Bienvenido a INFINITY WASH");
                    Console.WriteLine("*******************************************************");
                    bool continuar = true;
                    //menu elecciones 
                    while (continuar) 
                    {
                        Console.WriteLine("\nMENU DE OPCIONES:");
                        Console.WriteLine("Opcion (1) para lavado");
                        Console.WriteLine("Opcion (2) para parqueo");
                        Console.WriteLine("Opcion (0) para terminar");
                        Console.Write("Ingrese una opcion: ");
                        string opcionMenu = Console.ReadLine();

                        if (opcionMenu == "1") 
                        {
                            RealizarLavado();
                        }
                        else if (opcionMenu == "2") 
                        {
                            RealizarParqueo();
                        }
                        else if (opcionMenu == "0") 
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
                    Console.WriteLine("********************************************");
                    Console.WriteLine("Finalizado. ¡Gracias por usar INFINITY WASH!");
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
    //menu lavado 
    static void RealizarLavado()
    {
        Console.WriteLine("************************************");
        Console.WriteLine("Ingrese el tipo de vehículo a lavar:");
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
        Console.WriteLine("************************************");
        Console.WriteLine("TIPOS DE LAVADO:");
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

        Console.WriteLine("\n**********************************************");
        Console.WriteLine($"El valor a pagar por el lavado es de: ${precio}");
        Console.WriteLine($"Vehículo: {marca} {modelo}");
        Console.WriteLine($"Propietario: {propietario}");
        Console.WriteLine($"Teléfono: {telefono}");
        Console.WriteLine("*************************************************");

        Console.WriteLine("\n¿Desea volver a inicializar el programa?");
        Console.WriteLine("(Si) presione(1), (No) presione(2)");
    }
    //menu parqueo 
    static void RealizarParqueo()
    {
        Console.WriteLine("\n******************************************");
        Console.WriteLine("Ingrese el tipo de vehículo para el parqueo:");
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

        // Fecha y hora de entrada
        Console.WriteLine("Ingrese la hora de entrada (formato 24h, ej. 14:30):");
        string horaEntradaStr = Console.ReadLine();
        DateTime horaEntrada;

        while (!DateTime.TryParse(horaEntradaStr, out horaEntrada))
        {
            Console.WriteLine("Formato de hora no válido. Intente nuevamente (ej. 14:30):");
            horaEntradaStr = Console.ReadLine();
        }

        // Fecha y hora de salida
        Console.WriteLine("Ingrese la hora de salida (formato 24h, ej. 16:45):");
        string horaSalidaStr = Console.ReadLine();
        DateTime horaSalida;

        while (!DateTime.TryParse(horaSalidaStr, out horaSalida))//validar que el usuario haya ingresado una hora válida
        {
            Console.WriteLine("Formato de hora no válido. Intente nuevamente (ej. 16:45):");
            horaSalidaStr = Console.ReadLine();
        }

        TimeSpan duracionEstacionado = horaSalida - horaEntrada;//diferencia de tiempo entre la hora de salida (horaSalida) y la hora de entrada (horaEntrada) y la guarda en la variable duracionEstacionado, que es de tipo TimeSpan.
        double horasEstacionado = duracionEstacionado.TotalHours;

        double tarifaPorHora = 1000; 
        double precioTotal = Math.Ceiling(horasEstacionado) * tarifaPorHora; //Redondea hacia arriba las horas estacionadas al número entero más cercano y multiplica ese valor por la tarifa por hora para calcular el total a pagar.

        string tipoVehiculoTexto = "";
        if (tipoVehiculo == "1")
        {
            tipoVehiculoTexto = "CARRO";
        }
        else if (tipoVehiculo == "2")
        {
            tipoVehiculoTexto = "CAMIONETA";
        }
        else if (tipoVehiculo == "3")
        {
            tipoVehiculoTexto = "MOTO";
        }

        Console.WriteLine("\n********************************************");
        Console.WriteLine("Resumen del parqueo:");
        Console.WriteLine($"Tipo de vehículo: {tipoVehiculoTexto}");
        Console.WriteLine($"Hora de entrada: {horaEntrada.ToString("HH:mm")}");
        Console.WriteLine($"Hora de salida: {horaSalida.ToString("HH:mm")}");
        Console.WriteLine($"Duración del parqueo: {duracionEstacionado.TotalHours:F2} horas");
        Console.WriteLine($"Total a pagar por el parqueo: ${precioTotal}");
        Console.WriteLine("***********************************************");

        Console.WriteLine("\n¿Desea volver a inicializar el programa?");
        Console.WriteLine("(Si) presione(1), (No) presione(2)");
    }
}
