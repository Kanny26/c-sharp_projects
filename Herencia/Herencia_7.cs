using System;

class Participante
{
    public string nombre;
    public int edad;
    public string pais;

    public void Registrar(string nombreParticipante, int edadParticipante, string paisOrigen)
    {
        nombre = nombreParticipante;
        edad = edadParticipante;
        pais = paisOrigen;
    }

    public void MostrarInfo()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad);
        Console.WriteLine("País: " + pais);
    }
}

class PatinadorArtistico : Participante
{
    public int saltos;
    public double puntajeArtistico;

    public void CalificarPerformance(int cantidadSaltos)
    {
        saltos = cantidadSaltos;
        if (cantidadSaltos < 3)
        {
            puntajeArtistico = 5.0;
        }
        else if (cantidadSaltos >= 3 && cantidadSaltos <= 5)
        {
            puntajeArtistico = 7.5;
        }
        else
        {
            puntajeArtistico = 10.0;
        }
    }

    public void MostrarResultado()
    {
        MostrarInfo();
        Console.WriteLine("Categoría: Patinaje Artístico");
        Console.WriteLine("Saltos realizados: " + saltos);
        Console.WriteLine("Puntaje artístico: " + puntajeArtistico);
    }
}

class PatinadorVelocidad : Participante
{
    public double tiempo;
    public double puntajeVelocidad;

    public void CalificarTiempo(double tiempoRecorrido)
    {
        tiempo = tiempoRecorrido;
        if (tiempoRecorrido < 10)
        {
            puntajeVelocidad = 10.0;
        }
        else if (tiempoRecorrido >= 10 && tiempoRecorrido <= 15)
        {
            puntajeVelocidad = 7.5;
        }
        else
        {
            puntajeVelocidad = 5.0;
        }
    }

    public void MostrarResultado()
    {
        MostrarInfo();
        Console.WriteLine("Categoría: Patinaje de Velocidad");
        Console.WriteLine("Tiempo recorrido: " + tiempo + " segundos");
        Console.WriteLine("Puntaje de velocidad: " + puntajeVelocidad);
    }
}

class Programa
{
    static void Main()
    {
        int cantidad = 2;//de patinadores
        int i = 0;

        PatinadorArtistico[] artistas = new PatinadorArtistico[cantidad];
        PatinadorVelocidad[] velocistas = new PatinadorVelocidad[cantidad];

        Console.WriteLine("=== Registro de Patinadores Artísticos ===");
        while (i < cantidad)
        {
            PatinadorArtistico patinador = new PatinadorArtistico();

            Console.Write("Nombre: ");
            string nombreIngresado = Console.ReadLine();

            Console.Write("Edad: ");
            int edadIngresada = int.Parse(Console.ReadLine());

            Console.Write("País: ");
            string paisIngresado = Console.ReadLine();

            Console.Write("Saltos realizados: ");
            int saltosIngresados = int.Parse(Console.ReadLine());

            patinador.Registrar(nombreIngresado, edadIngresada, paisIngresado);
            patinador.CalificarPerformance(saltosIngresados);

            artistas[i] = patinador;
            i++;
        }

        i = 0;
        Console.WriteLine("\n=== Registro de Patinadores de Velocidad ===");
        while (i < cantidad)
        {
            PatinadorVelocidad patinador = new PatinadorVelocidad();

            Console.Write("Nombre: ");
            string nombreIngresado = Console.ReadLine();

            Console.Write("Edad: ");
            int edadIngresada = int.Parse(Console.ReadLine());

            Console.Write("País: ");
            string paisIngresado = Console.ReadLine();

            Console.Write("Tiempo recorrido (segundos): ");
            double tiempoIngresado = double.Parse(Console.ReadLine());

            patinador.Registrar(nombreIngresado, edadIngresada, paisIngresado);
            patinador.CalificarTiempo(tiempoIngresado);

            velocistas[i] = patinador;
            i++;
        }

        // Ordenar artistas por mayor puntaje
        i = 0;
        while (i < cantidad - 1)
        {
            int j = i + 1;
            while (j < cantidad)
            {
                if (artistas[i].puntajeArtistico < artistas[j].puntajeArtistico)
                {
                    PatinadorArtistico temp = artistas[i];
                    artistas[i] = artistas[j];
                    artistas[j] = temp;
                }
                j++;
            }
            i++;
        }

        // Ordenar velocistas por menor tiempo
        i = 0;
        while (i < cantidad - 1)
        {
            int j = i + 1;
            while (j < cantidad)
            {
                if (velocistas[i].tiempo > velocistas[j].tiempo)
                {
                    PatinadorVelocidad temp = velocistas[i];
                    velocistas[i] = velocistas[j];
                    velocistas[j] = temp;
                }
                j++;
            }
            i++;
        }

        Console.WriteLine("\n=== Resultados Finales: Patinaje Artístico (Mejor Puntaje Primero) ===");
        i = 0;
        while (i < cantidad)
        {
            artistas[i].MostrarResultado();
            Console.WriteLine("-------------------------");
            i++;
        }

        Console.WriteLine("\n=== Resultados Finales: Patinaje de Velocidad (Mejor Tiempo Primero) ===");
        i = 0;
        while (i < cantidad)
        {
            velocistas[i].MostrarResultado();
            Console.WriteLine("-------------------------");
            i++;
        }

        Console.WriteLine("=== Fin del torneo ===");
    }
}
