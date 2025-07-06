using System;

// Clase que representa un equipo de baloncesto.
class Equipo
{
    // Propiedad para el nombre del equipo.
    public string Nombre { get; set; }

    // Propiedad para almacenar los puntos acumulados.
    public int Puntaje { get; set; }

    // Constructor: recibe el nombre e inicializa el puntaje en 0.
    public Equipo(string nombre)
    {
        Nombre = nombre;
        Puntaje = 0;
    }
}

// Clase que representa el torneo de baloncesto.
class TorneoBaloncesto
{
    public Equipo[] equipos; // Arreglo de equipos participantes.
    public int cantidadEquipos; // Número actual de equipos registrados.

    // Constructor: inicializa el arreglo con capacidad máxima de equipos.
    public TorneoBaloncesto(int capacidad)
    {
        equipos = new Equipo[capacidad];
        cantidadEquipos = 0;
    }

    // Método para agregar un equipo al torneo.
    public void AgregarEquipo(Equipo nuevoEquipo)
    {
        equipos[cantidadEquipos] = nuevoEquipo; // Se añade al arreglo.
        cantidadEquipos++; // Se incrementa el contador.
    }

    // Método para imprimir la tabla de posiciones actual.
    public void ImprimirTabla()
    {
        Console.WriteLine("\nTabla de posiciones:");
        for (int i = 0; i < cantidadEquipos; i++)
        {
            Console.WriteLine($"{equipos[i].Nombre}: {equipos[i].Puntaje} puntos");
        }
    }

    // Método para mostrar al campeón o campeones del torneo.
    public void MostrarCampeon()
    {
        int maxPuntaje = equipos[0].Puntaje; // Se asume que el primer equipo tiene el mayor puntaje inicialmente.

        // Se recorre el arreglo para encontrar el puntaje más alto.
        for (int i = 1; i < cantidadEquipos; i++)
        {
            if (equipos[i].Puntaje > maxPuntaje)
            {
                maxPuntaje = equipos[i].Puntaje;
            }
        }

        // Se muestran todos los equipos que tengan ese puntaje (puede haber empate).
        Console.WriteLine("\nCampeón del torneo:");
        for (int i = 0; i < cantidadEquipos; i++)
        {
            if (equipos[i].Puntaje == maxPuntaje)
            {
                Console.WriteLine($"{equipos[i].Nombre} con {equipos[i].Puntaje} puntos");
            }
        }
    }
}

// Clase principal del programa.
internal class Program
{
    static void Main(string[] args)
    {
        // Solicita al usuario el número de equipos que participarán.
        Console.Write("¿Cuántos equipos participarán?: ");
        int totalEquipos = int.Parse(Console.ReadLine());

        // Crea un nuevo torneo con la cantidad de equipos indicada.
        TorneoBaloncesto torneo = new TorneoBaloncesto(totalEquipos);

        // Ciclo para registrar el nombre de cada equipo.
        for (int i = 0; i < totalEquipos; i++)
        {
            Console.Write($"Ingrese el nombre del equipo #{i + 1}: ");
            string nombre = Console.ReadLine();

            // Verifica si el equipo ya fue registrado.
            bool existe = false;
            for (int j = 0; j < torneo.cantidadEquipos; j++)
            {
                if (torneo.equipos[j].Nombre == nombre)
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                // Si no existe, se agrega.
                Equipo nuevo = new Equipo(nombre);
                torneo.AgregarEquipo(nuevo);
            }
            else
            {
                // Si ya existe, se pide un nombre diferente y se repite el ciclo.
                Console.WriteLine("Ese equipo ya fue registrado. Intenta otro nombre.");
                i--;
            }
        }

        // Solicita el número de partidos que se van a registrar.
        Console.Write("\n¿Cuántos partidos se jugarán?: ");
        int totalPartidos = int.Parse(Console.ReadLine());

        // Ciclo para ingresar la información de cada partido.
        for (int i = 0; i < totalPartidos; i++)
        {
            Console.WriteLine($"\nPARTIDO #{i + 1}:");

            // Solicita nombres y puntajes de los dos equipos que jugaron.
            Console.Write("Nombre del primer equipo: ");
            string equipo1Nombre = Console.ReadLine();
            Console.Write("Puntaje del primer equipo: ");
            int puntos1 = int.Parse(Console.ReadLine());

            Console.Write("Nombre del segundo equipo: ");
            string equipo2Nombre = Console.ReadLine();
            Console.Write("Puntaje del segundo equipo: ");
            int puntos2 = int.Parse(Console.ReadLine());

            Equipo equipo1 = null;
            Equipo equipo2 = null;

            // Busca los objetos correspondientes a los equipos en el arreglo.
            for (int j = 0; j < torneo.cantidadEquipos; j++)
            {
                if (torneo.equipos[j].Nombre == equipo1Nombre)
                {
                    equipo1 = torneo.equipos[j];
                }
                if (torneo.equipos[j].Nombre == equipo2Nombre)
                {
                    equipo2 = torneo.equipos[j];
                }
            }

            if (equipo1 != null && equipo2 != null)
            {
                // Asigna puntos: 3 al ganador, 1 a cada uno si empatan.
                if (puntos1 > puntos2)
                {
                    equipo1.Puntaje += 3;
                }
                else if (puntos2 > puntos1)
                {
                    equipo2.Puntaje += 3;
                }
                else
                {
                    equipo1.Puntaje += 1;
                    equipo2.Puntaje += 1;
                }
            }
            else
            {
                // Si algún equipo no fue encontrado, muestra error y repite el partido.
                Console.WriteLine("Uno de los equipos ingresados no está registrado. Intenta nuevamente.");
                i--; // Decrementa el contador para repetir este partido.
            }
        }

        // Muestra la tabla final de posiciones y el campeón.
        torneo.ImprimirTabla();
        torneo.MostrarCampeon();
    }
}