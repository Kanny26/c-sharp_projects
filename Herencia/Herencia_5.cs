using System;

class Vehiculo
{
    public string tipoVehiculo;
    public string estadoLimpieza;
    public int numeroPuertas;

    public void MostrarEstado()
    {
        Console.WriteLine("Tipo: " + tipoVehiculo);
        Console.WriteLine("Estado de limpieza: " + estadoLimpieza);
        Console.WriteLine("Número de puertas: " + numeroPuertas);
    }

    public virtual void RealizarServicio()
    {
        Console.WriteLine("Realizando servicio general...");
    }
}

class Automovil : Vehiculo
{
    public Automovil()
    {
        tipoVehiculo = "Automóvil";
        estadoLimpieza = "Sucio";
        numeroPuertas = 4;
    }

    public override void RealizarServicio()
    {
        Console.WriteLine("Lavando exterior del automóvil...");
        Console.WriteLine("Limpiando interiores del automóvil...");
        Console.WriteLine("Puliendo la carrocería...");
        estadoLimpieza = "Limpio";
    }
}

class Motocicleta : Vehiculo
{
    public Motocicleta()
    {
        tipoVehiculo = "Motocicleta";
        estadoLimpieza = "Sucio";
        numeroPuertas = 0;
    }

    public override void RealizarServicio()
    {
        Console.WriteLine("Limpiando asiento de la motocicleta...");
        Console.WriteLine("Revisando espejos de la motocicleta...");
        Console.WriteLine("Lavando llantas de la motocicleta...");
        estadoLimpieza = "Limpio";
    }
}

class ProgramaLavadero
{
    static void Main()
    {
        int opcion = 0;
        while (opcion != 3)
        {
            Console.WriteLine("\n--- MENÚ DEL LAVADERO ---");
            Console.WriteLine("1. Atender Automóvil");
            Console.WriteLine("2. Atender Motocicleta");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string entrada = Console.ReadLine();
            opcion = int.Parse(entrada);

            if (opcion == 1)
            {
                Automovil auto = new Automovil();
                Console.WriteLine("\nRecibiendo un automóvil...");
                auto.RealizarServicio();
                Console.WriteLine("\n--- Estado Final del Vehículo ---");
                auto.MostrarEstado();
            }
            else if (opcion == 2)
            {
                Motocicleta moto = new Motocicleta();
                Console.WriteLine("\nRecibiendo una motocicleta...");
                moto.RealizarServicio();
                Console.WriteLine("\n--- Estado Final del Vehículo ---");
                moto.MostrarEstado();
            }
            else if (opcion == 3)
            {
                Console.WriteLine("Saliendo del sistema...");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}
