using System;

class JugadorBase
{
    public string nombre;
    public int framesJugados;
    public int puntajeTotal;

    public void LanzarBola()
    {
        // Este método puede ser sobreescrito por las subclases si se desea.
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Frames jugados: " + framesJugados);
        Console.WriteLine("Puntaje total: " + puntajeTotal);
    }
}

class JugadorIndividual : JugadorBase
{
    public void Jugar()
    {
        framesJugados = 0;
        puntajeTotal = 0;

        while (framesJugados < 10)
        {
            Console.WriteLine("\nFrame #" + (framesJugados + 1));
            int primerTiro = Lanzamiento("primer");
            int segundoTiro = 0;
            int tercerTiro = 0;

            if (primerTiro == 10 && framesJugados < 9)
            {
                Console.WriteLine("¡Strike!");
                puntajeTotal += 10;
            }
            else
            {
                segundoTiro = Lanzamiento("segundo");

                if (primerTiro + segundoTiro == 10 && framesJugados < 9)
                {
                    Console.WriteLine("¡Spare!");
                    puntajeTotal += 10;
                }
                else
                {
                    puntajeTotal += primerTiro + segundoTiro;
                }
            }

            // Frame 10 (último): posibilidad de tercer tiro
            if (framesJugados == 9)
            {
                if (primerTiro == 10)
                {
                    segundoTiro = Lanzamiento("segundo");
                    tercerTiro = Lanzamiento("tercer");
                    puntajeTotal += primerTiro + segundoTiro + tercerTiro;
                }
                else if (primerTiro + segundoTiro == 10)
                {
                    tercerTiro = Lanzamiento("tercer");
                    puntajeTotal += primerTiro + segundoTiro + tercerTiro;
                }
                else
                {
                    puntajeTotal += primerTiro + segundoTiro;
                }
            }

            framesJugados++;
        }
    }

    int Lanzamiento(string intento)
    {
        int pinos = -1;

        while (pinos < 0 || pinos > 10)
        {
            Console.Write("Ingrese los pinos derribados en el " + intento + " tiro: ");
            pinos = int.Parse(Console.ReadLine());
        }

        return pinos;
    }
}

class EquipoJugadores : JugadorBase
{
    public JugadorIndividual jugador1 = new JugadorIndividual();
    public JugadorIndividual jugador2 = new JugadorIndividual();

    public void RegistrarEquipo(string nombreEquipo)
    {
        nombre = nombreEquipo;

        Console.WriteLine("\nRegistrar jugador 1:");
        Console.Write("Nombre: ");
        jugador1.nombre = Console.ReadLine();

        Console.WriteLine("Registrar jugador 2:");
        Console.Write("Nombre: ");
        jugador2.nombre = Console.ReadLine();
    }

    public void JugarComoEquipo()
    {
        Console.WriteLine("\nJugando jugador 1: " + jugador1.nombre);
        jugador1.Jugar();

        Console.WriteLine("\nJugando jugador 2: " + jugador2.nombre);
        jugador2.Jugar();

        puntajeTotal = jugador1.puntajeTotal + jugador2.puntajeTotal;
        framesJugados = 10;
    }

    public void MostrarPuntajeEquipo()
    {
        Console.WriteLine("\nEquipo: " + nombre);
        Console.WriteLine("Puntaje total del equipo: " + puntajeTotal);
        Console.WriteLine("Jugador 1: " + jugador1.nombre + " - Puntaje: " + jugador1.puntajeTotal);
        Console.WriteLine("Jugador 2: " + jugador2.nombre + " - Puntaje: " + jugador2.puntajeTotal);
    }
}

class Programa
{
    static void Main()
    {
        JugadorIndividual[] individuales = new JugadorIndividual[2];
        EquipoJugadores[] equipos = new EquipoJugadores[1];

        Console.WriteLine("=== Registro de jugadores individuales ===");
        int i = 0;
        while (i < 2)
        {
            individuales[i] = new JugadorIndividual();
            Console.Write("Ingrese el nombre del jugador individual #" + (i + 1) + ": ");
            individuales[i].nombre = Console.ReadLine();
            individuales[i].Jugar();
            i++;
        }

        Console.WriteLine("\n=== Registro de equipos ===");
        equipos[0] = new EquipoJugadores();
        Console.Write("Nombre del equipo: ");
        string nombreEquipo = Console.ReadLine();
        equipos[0].RegistrarEquipo(nombreEquipo);
        equipos[0].JugarComoEquipo();

        // Ordenar jugadores individuales por puntaje (burbuja)
        i = 0;
        while (i < 1)
        {
            int j = i + 1;
            while (j < 2)
            {
                if (individuales[i].puntajeTotal < individuales[j].puntajeTotal)
                {
                    JugadorIndividual temp = individuales[i];
                    individuales[i] = individuales[j];
                    individuales[j] = temp;
                }
                j++;
            }
            i++;
        }

        // Mostrar resultados
        Console.WriteLine("\n=== Resultados Finales - Jugadores Individuales ===");
        i = 0;
        while (i < 2)
        {
            individuales[i].MostrarInformacion();
            Console.WriteLine();
            i++;
        }

        Console.WriteLine("\n=== Resultados Finales - Equipos ===");
        equipos[0].MostrarPuntajeEquipo();
    }
}
