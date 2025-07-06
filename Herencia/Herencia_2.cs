using System;

class Apuesta
{
    public string nombreEvento;
    public double monto;

    public virtual double CalcularPago()
    {
        return 0;
    }
}

class ApuestaSimple : Apuesta
{
    public double probabilidad;

    public override double CalcularPago()
    {
        double pago = 0;
        if (probabilidad > 0)
        {
            pago = monto / probabilidad;
        }
        return pago;
    }
}

class ApuestaCombinada : Apuesta
{
    public string[] eventos = new string[10];
    public double[] probabilidades = new double[10];
    public int totalEventos = 0;

    public void AgregarEvento(string nombre, double prob)
    {
        if (totalEventos < 10)
        {
            eventos[totalEventos] = nombre;
            probabilidades[totalEventos] = prob;
            totalEventos = totalEventos + 1;
        }
    }

    public override double CalcularPago()
    {
        double probabilidadTotal = 1;
        int i = 0;
        while (i < totalEventos)
        {
            probabilidadTotal = probabilidadTotal * probabilidades[i];
            i = i + 1;
        }

        double pago = 0;
        if (probabilidadTotal > 0)
        {
            pago = monto / probabilidadTotal;
        }
        return pago;
    }
}

class Program
{
    static void Main()
    {
        string[] eventosDisponibles = { "Fútbol", "Tenis", "Patinaje", "Baloncesto", "Equitacion" };

        int opcion = 0;

        do
        {
            Console.WriteLine("\n--- SISTEMA DE APUESTAS LA PERLA ---");
            Console.WriteLine("1. Apuesta Simple");
            Console.WriteLine("2. Apuesta Combinada");
            Console.WriteLine("3. Salir");
            Console.Write("Elija una opción: ");
            string entrada = Console.ReadLine();
            opcion = int.Parse(entrada);

            if (opcion == 1)
            {
                ApuestaSimple a = new ApuestaSimple();

                Console.WriteLine("\nSeleccione el evento:");
                a.nombreEvento = ElegirEvento(eventosDisponibles);

                Console.Write("Monto apostado: ");
                a.monto = double.Parse(Console.ReadLine());

                Console.Write("Probabilidad de ganar (ej: 0.25): ");
                a.probabilidad = double.Parse(Console.ReadLine());

                double pago = a.CalcularPago();
                Console.WriteLine("Pago potencial: " + pago);
            }
            else if (opcion == 2)
            {
                ApuestaCombinada ac = new ApuestaCombinada();

                Console.WriteLine("\nSeleccione el evento principal:");
                ac.nombreEvento = ElegirEvento(eventosDisponibles);

                Console.Write("Monto apostado: ");
                ac.monto = double.Parse(Console.ReadLine());

                string continuar = "s";

                while (continuar == "s")
                {
                    Console.WriteLine("\nSeleccione sub-evento:");
                    string subEvento = ElegirEvento(eventosDisponibles);

                    Console.Write("Probabilidad del sub-evento (ej: 0.5): ");
                    double prob = double.Parse(Console.ReadLine());

                    ac.AgregarEvento(subEvento, prob);

                    Console.Write("¿Desea agregar otro evento? (s/n): ");
                    continuar = Console.ReadLine();
                }

                double pago = ac.CalcularPago();
                Console.WriteLine("Pago potencial combinado: " + pago);
            }

        } while (opcion != 3);

        Console.WriteLine("Gracias por usar el sistema de apuestas.");
    }

    static string ElegirEvento(string[] eventos)
    {
        int i = 0;
        while (i < eventos.Length)
        {
            Console.WriteLine((i + 1) + ". " + eventos[i]);
            i = i + 1;
        }

        int opcion = 0;
        do
        {
            Console.Write("Seleccione un evento por número: ");
            string entrada = Console.ReadLine();
            opcion = int.Parse(entrada);
        } while (opcion < 1 || opcion > eventos.Length);

        return eventos[opcion - 1];
    }
}



