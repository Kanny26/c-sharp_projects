using System;

class tipo_vehiculos
{
    public int ruedas;
    public int capacidadCarga;
    public string ruta;

    public void AsignarRuta(string nuevaruta)
    {
        ruta = nuevaruta;
    }

    public void Mover()
    {
        Console.WriteLine("El vehículo se está moviendo por la ruta: " + ruta);
    }

    public void Informacion_vehiculo()
    {
        Console.WriteLine("Número de ruedas: " + ruedas);
        Console.WriteLine("Capacidad de carga actual: " + capacidadCarga + " kg");
        Console.WriteLine("Ruta actual: " + ruta);
    }
}

class Camion : tipo_vehiculos
{
    public void añadirCarga()
    {
        string respuesta = "";
        Console.Write("¿Desea añadir carga? (s/n): ");
        respuesta = Console.ReadLine();

        if (respuesta == "s")
        {
            int carga;
            Console.Write("Ingrese la cantidad de carga a añadir (kg): ");
            carga = Convert.ToInt32(Console.ReadLine());

            if (capacidadCarga + carga > 45000)
            {
                Console.WriteLine("¡No se puede añadir esa cantidad! Se excede el límite de 45,000 kg.");
                Console.WriteLine("Carga disponible para añadir: " + (45000 - capacidadCarga) + " kg");
            }
            else
            {
                capacidadCarga = capacidadCarga + carga;
                Console.WriteLine("Nueva capacidad de carga: " + capacidadCarga + " kg");
            }
        }
    }

    public void transporteCargaPesada()
    {
        Console.WriteLine("El camión está transportando una carga pesada...");
    }
}

class Furgoneta : tipo_vehiculos
{
    public void añadirCarga()
    {
        string respuesta = "";
        Console.Write("¿Desea añadir carga? (s/n): ");
        respuesta = Console.ReadLine();

        if (respuesta == "s")
        {
            int carga;
            Console.Write("Ingrese la cantidad de carga a añadir (kg): ");
            carga = Convert.ToInt32(Console.ReadLine());

            if (capacidadCarga + carga > 3500)
            {
                Console.WriteLine("¡No se puede añadir esa cantidad! Se excede el límite de 3,500 kg.");
                Console.WriteLine("Carga disponible para añadir: " + (3500 - capacidadCarga) + " kg");
            }
            else
            {
                capacidadCarga = capacidadCarga + carga;
                Console.WriteLine("Nueva capacidad de carga: " + capacidadCarga + " kg");
            }
        }
    }

    public void CambioRuta()
    {
        Console.WriteLine("La furgoneta ha cambiado de ruta rápidamente.");
        ruta = "Ruta alternativa rápida: Tunja - Yopal";
        Console.WriteLine("Nueva ruta: " + ruta);
    }
}

class Program
{
    static void Main()
    {
        int opcion = 0;

        while (opcion != 4)
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Usar un camión");
            Console.WriteLine("2. Usar una furgoneta");
            Console.WriteLine("3. Verificar el vehículo en movimiento");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 1 || opcion == 2)
            {
                Console.WriteLine("\nSeleccione una ruta:");
                Console.WriteLine("1. Ruta larga: Bucaramanga - Ventaquemada - Chocontá");
                Console.WriteLine("2. Ruta corta: San Gil - Socorro");
                Console.Write("Ingrese opción de ruta: ");
                int elegir = Convert.ToInt32(Console.ReadLine());

                string seleccionada = "Sin ruta";
                if (elegir == 1)
                {
                    seleccionada = "Bucaramanga - Ventaquemada - Chocontá";
                }
                else if (elegir == 2)
                {
                    seleccionada = "San Gil - Socorro";
                }

                if (opcion == 1)
                {
                    Camion camion = new Camion();
                    camion.ruedas = 8;
                    camion.capacidadCarga = 0;
                    camion.AsignarRuta(seleccionada);

                    camion.Informacion_vehiculo();
                    camion.Mover();
                    camion.añadirCarga();
                    camion.transporteCargaPesada();
                }
                else if (opcion == 2)
                {
                    Furgoneta furgoneta = new Furgoneta();
                    furgoneta.ruedas = 4;
                    furgoneta.capacidadCarga = 0;
                    furgoneta.AsignarRuta(seleccionada);

                    furgoneta.Informacion_vehiculo();
                    furgoneta.Mover();
                    furgoneta.añadirCarga();
                    furgoneta.CambioRuta();
                    furgoneta.Mover();
                }
            }
            else if (opcion == 3)
            {
                tipo_vehiculos movimiento = new tipo_vehiculos();
                movimiento.AsignarRuta("Bucaramanga - Yopal");
                movimiento.Mover();
            }
            else if (opcion == 4)
            {
                Console.WriteLine("Gracias por usar el sistema.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}

