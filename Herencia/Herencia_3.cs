using System;

class Vehiculo
{
    public string tipoVehiculo;
    public int numeroRuedas;
    public string estadoMotor;

    public void ReparacionGeneral()
    {
        Console.WriteLine("\nIniciando reparación general del vehículo:");
        Console.WriteLine("\nTipo: " + tipoVehiculo);
        Console.WriteLine("Número de ruedas: " + numeroRuedas);
        Console.WriteLine("Estado del motor ANTES: " + estadoMotor);

        Console.WriteLine("\nRevisión de niveles, cambio de aceite, ajuste general realizado.");
    }
}

class Motocicleta : Vehiculo
{
    public string tipoMotocicleta;

    public void AjustarFrenos()
    {
        Console.WriteLine("Ajustando frenos de la motocicleta tipo " + tipoMotocicleta + "...");
        Console.WriteLine("Frenos ajustados correctamente.");
    }

    public void MostrarReporte()
    {
        estadoMotor = "Reparado";
        Console.WriteLine("Estado del motor DESPUÉS: " + estadoMotor);
        Console.WriteLine("\n=== REPORTE FINAL DE MOTOCICLETA ===");
        Console.WriteLine("Tipo de vehículo: " + tipoVehiculo);
        Console.WriteLine("Número de ruedas: " + numeroRuedas);
        Console.WriteLine("Tipo de motocicleta: " + tipoMotocicleta);
        Console.WriteLine("Estado final del motor: " + estadoMotor);
        Console.WriteLine("Reparaciones: Reparación general + Ajuste de frenos\n");
    }
}

class Auto : Vehiculo
{
    public string tipoAuto;

    public void Alinear()
    {
        Console.WriteLine("Realizando alineación del auto tipo " + tipoAuto + "...");
        Console.WriteLine("Alineación completada correctamente.");
    }

    public void MostrarReporte()
    {
        estadoMotor = "Reparado";
        Console.WriteLine("\nEstado del motor DESPUÉS: " + estadoMotor);
        Console.WriteLine("\n=== REPORTE FINAL DE AUTO ===");
        Console.WriteLine("Tipo de vehículo: " + tipoVehiculo);
        Console.WriteLine("Número de ruedas: " + numeroRuedas);
        Console.WriteLine("Tipo de auto: " + tipoAuto);
        Console.WriteLine("Estado final del motor: " + estadoMotor);
        Console.WriteLine("Reparaciones: Reparación general + Alineación\n");
    }
}

class Programa
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 3)
        {
            Console.WriteLine("=== TALLER DE VEHÍCULOS ===");
            Console.WriteLine("1. Registrar motocicleta");
            Console.WriteLine("2. Registrar auto");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();
            opcion = int.Parse(entrada);

            if (opcion == 1)
            {
                Motocicleta moto = new Motocicleta();

                moto.tipoVehiculo = "Motocicleta";
                moto.numeroRuedas = 2;
                moto.estadoMotor = "Averiado";

                Console.Write("Ingrese el tipo de motocicleta (deportiva, turismo, etc.): ");
                moto.tipoMotocicleta = Console.ReadLine();

                moto.ReparacionGeneral();
                moto.AjustarFrenos();
                moto.MostrarReporte();
            }
            else if (opcion == 2)
            {
                Auto auto = new Auto();

                auto.tipoVehiculo = "Auto";
                auto.numeroRuedas = 4;
                auto.estadoMotor = "Falla eléctrica";

                Console.Write("Ingrese el tipo de auto (sedán, SUV, etc.): ");
                auto.tipoAuto = Console.ReadLine();

                auto.ReparacionGeneral();
                auto.Alinear();
                auto.MostrarReporte();
            }
            else if (opcion != 3)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.\n");
            }
        }

        Console.WriteLine("Fin del programa.");
    }
}
