using System; 

// Clase que representa a un jugador de ping pong
class Jugador 
{
    // Campos privados del jugador
    private string nombre;
    private string pais;
    private int clasificacionInicial;
    private int puntajePrevio;

    private int puntosActuales;
    private int victorias;
    private int derrotas;
    private int rondaActual;

    // Constructor que inicializa el jugador con datos básicos y valores iniciales para el torneo
    public Jugador(string nombreJugador, string paisJugador, int clasifIni, int puntajeAnt)
    {
        nombre = nombreJugador;
        pais = paisJugador;
        clasificacionInicial = clasifIni;
        puntajePrevio = puntajeAnt;

        puntosActuales = 0;
        victorias = 0;
        derrotas = 0;
        rondaActual = 1;
    }

    // Métodos para obtener información del jugador
    public string ObtenerNombre() { return nombre; }
    public string ObtenerPais() { return pais; }
    public int ObtenerClasificacionInicial() { return clasificacionInicial; }
    public int ObtenerPuntajePrevio() { return puntajePrevio; }
    public int ObtenerPuntosActuales() { return puntosActuales; }
    public int ObtenerVictorias() { return victorias; }
    public int ObtenerDerrotas() { return derrotas; }
    public int ObtenerRondaActual() { return rondaActual; }

    // Método para agregar puntos al puntaje actual del jugador
    public void AgregarPuntos(int puntos)
    {
        puntosActuales = puntosActuales + puntos;
    }

    // Métodos para registrar victoria, derrota y avanzar ronda
    public void RegistrarVictoria() { victorias = victorias + 1; }
    public void RegistrarDerrota() { derrotas = derrotas + 1; }
    public void AvanzarRonda() { rondaActual = rondaActual + 1; }
}

// Clase que representa un partido entre dos jugadores
class Partido
{
    private Jugador jugador1;
    private Jugador jugador2;

    private int puntosJugador1;
    private int puntosJugador2;

    // Puntos asignados al ganador y al perdedor del partido
    private int puntosGanador = 3;
    private int puntosPerdedor = 1;

    // Constructor que recibe dos jugadores y inicializa los puntos en cero
    public Partido(Jugador j1, Jugador j2)
    {
        jugador1 = j1;
        jugador2 = j2;
        puntosJugador1 = 0;
        puntosJugador2 = 0;
    }

    // Método para jugar el partido y actualizar estadísticas de los jugadores según resultado
    public void JugarPartido(int puntos1, int puntos2)
    {
        puntosJugador1 = puntos1;
        puntosJugador2 = puntos2;

        if (puntosJugador1 > puntosJugador2)
        {
            // Jugador 1 gana
            jugador1.RegistrarVictoria();
            jugador1.AgregarPuntos(puntosGanador);
            jugador1.AvanzarRonda();

            // Jugador 2 pierde
            jugador2.RegistrarDerrota();
            jugador2.AgregarPuntos(puntosPerdedor);
        }
        else
        {
            // Jugador 2 gana
            jugador2.RegistrarVictoria();
            jugador2.AgregarPuntos(puntosGanador);
            jugador2.AvanzarRonda();

            // Jugador 1 pierde
            jugador1.RegistrarDerrota();
            jugador1.AgregarPuntos(puntosPerdedor);
        }
    }

    // Método para obtener un resumen del resultado del partido
    public string ObtenerResultado()
    {
        return jugador1.ObtenerNombre() + " " + puntosJugador1 + " - " + puntosJugador2 + " " + jugador2.ObtenerNombre();
    }
}

// Clase que maneja el torneo de ping pong
class Torneo
{
    private Jugador[] jugadores;
    private int cantidadJugadores;
    private int capacidadMaxima = 10; // Límite de jugadores permitidos

    // Constructor que inicializa la lista de jugadores y la cantidad actual
    public Torneo()
    {
        jugadores = new Jugador[capacidadMaxima];
        cantidadJugadores = 0;
    }

    // Método para agregar un jugador si no se supera la capacidad máxima
    public void AgregarJugador(string nombre, string pais, int clasificacion, int puntajePrevio)
    {
        if (cantidadJugadores < capacidadMaxima)
        {
            jugadores[cantidadJugadores] = new Jugador(nombre, pais, clasificacion, puntajePrevio);
            cantidadJugadores = cantidadJugadores + 1;
        }
        else
        {
            Console.WriteLine("No se pueden agregar más jugadores, capacidad máxima alcanzada.");
        }
    }

    // Método para obtener un jugador por índice en el arreglo
    public Jugador ObtenerJugador(int indice)
    {
        if (indice >= 0 && indice < cantidadJugadores)
        {
            return jugadores[indice];
        }
        return null; // Retorna null si índice es inválido
    }

    // Obtener la cantidad de jugadores actualmente registrados
    public int ObtenerCantidadJugadores()
    {
        return cantidadJugadores;
    }

    // Mostrar la clasificación general del torneo
    public void MostrarClasificacion()
    {
        OrdenarJugadores(); // Primero ordena la lista según puntos, victorias y ronda

        Console.WriteLine("Clasificación general:");
        int pos = 1;
        for (int i = 0; i < cantidadJugadores; i = i + 1)
        {
            Jugador j = jugadores[i];
            Console.WriteLine(pos + ". " + j.ObtenerNombre() + " - Puntos: " + j.ObtenerPuntosActuales() + " - Victorias: " + j.ObtenerVictorias() + " - Ronda: " + j.ObtenerRondaActual());
            pos = pos + 1;
        }
    }

    // Ordena el arreglo de jugadores usando burbuja según criterios personalizados
    private void OrdenarJugadores()
    {
        for (int i = 0; i < cantidadJugadores - 1; i = i + 1)
        {
            for (int j = 0; j < cantidadJugadores - 1 - i; j = j + 1)
            {
                // Si el jugador j+1 es mejor que jugador j según criterios, intercambiarlos
                if (CompararJugadores(jugadores[j], jugadores[j + 1]) < 0)
                {
                    Jugador temp = jugadores[j];
                    jugadores[j] = jugadores[j + 1];
                    jugadores[j + 1] = temp;
                }
            }
        }
    }

    // Compara dos jugadores por puntos actuales, victorias y ronda actual, en ese orden
    private int CompararJugadores(Jugador j1, Jugador j2)
    {
        if (j2.ObtenerPuntosActuales() != j1.ObtenerPuntosActuales())
            return j2.ObtenerPuntosActuales() - j1.ObtenerPuntosActuales();

        if (j2.ObtenerVictorias() != j1.ObtenerVictorias())
            return j2.ObtenerVictorias() - j1.ObtenerVictorias();

        return j2.ObtenerRondaActual() - j1.ObtenerRondaActual();
    }

    // Muestra estadísticas detalladas de un jugador buscando por nombre
    public void MostrarEstadisticasJugador(string nombre)
    {
        for (int i = 0; i < cantidadJugadores; i = i + 1)
        {
            Jugador j = jugadores[i];
            if (j.ObtenerNombre() == nombre)
            {
                Console.WriteLine("Jugador: " + j.ObtenerNombre());
                Console.WriteLine("País: " + j.ObtenerPais());
                Console.WriteLine("Clasificación inicial: " + j.ObtenerClasificacionInicial());
                Console.WriteLine("Puntaje previo: " + j.ObtenerPuntajePrevio());
                Console.WriteLine("Puntos actuales: " + j.ObtenerPuntosActuales());
                Console.WriteLine("Victorias: " + j.ObtenerVictorias());
                Console.WriteLine("Derrotas: " + j.ObtenerDerrotas());
                Console.WriteLine("Ronda actual: " + j.ObtenerRondaActual());
                return;
            }
        }
        Console.WriteLine("Jugador no encontrado.");
    }
}

// Clase principal con el menú y la interacción con el usuario
class Programa
{
    static void Main(string[] args)
    {
        Torneo torneo = new Torneo();

        while (true)
        {
            // Mostrar menú principal
            Console.WriteLine("\n--- Torneo Internacional de Ping Pong ---");
            Console.WriteLine("1. Registrar jugador");
            Console.WriteLine("2. Mostrar jugadores");
            Console.WriteLine("3. Registrar resultado de partido");
            Console.WriteLine("4. Mostrar clasificación");
            Console.WriteLine("5. Mostrar estadísticas de un jugador");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                // Registrar un nuevo jugador solicitando datos al usuario
                Console.Write("Nombre del jugador: ");
                string nombre = Console.ReadLine();
                Console.Write("País: ");
                string pais = Console.ReadLine();
                Console.Write("Clasificación inicial (número): ");
                int clasif = Convert.ToInt32(Console.ReadLine());
                Console.Write("Puntaje en torneos previos (número): ");
                int puntaje = Convert.ToInt32(Console.ReadLine());

                torneo.AgregarJugador(nombre, pais, clasif, puntaje);
            }
            else if (opcion == "2")
            {
                // Mostrar lista de jugadores registrados
                int total = torneo.ObtenerCantidadJugadores();
                Console.WriteLine("Jugadores registrados:");
                for (int i = 0; i < total; i = i + 1)
                {
                    Jugador j = torneo.ObtenerJugador(i);
                    Console.WriteLine((i + 1) + ". " + j.ObtenerNombre() + " (" + j.ObtenerPais() + ")");
                }
            }
            else if (opcion == "3")
            {
                // Registrar resultado de un partido entre dos jugadores seleccionados
                int total = torneo.ObtenerCantidadJugadores();
                if (total < 2)
                {
                    Console.WriteLine("Se necesitan al menos 2 jugadores para registrar un partido.");
                    continue;
                }

                Console.WriteLine("Seleccione jugador 1:");
                for (int i = 0; i < total; i = i + 1)
                {
                    Jugador j = torneo.ObtenerJugador(i);
                    Console.WriteLine((i + 1) + ". " + j.ObtenerNombre());
                }
                int ind1 = Convert.ToInt32(Console.ReadLine()) - 1;
                if (ind1 < 0 || ind1 >= total)
                {
                    Console.WriteLine("Índice inválido.");
                    continue;
                }

                Console.WriteLine("Seleccione jugador 2:");
                for (int i = 0; i < total; i = i + 1)
                {
                    if (i == ind1) continue; // No permitir seleccionar el mismo jugador dos veces
                    Jugador j = torneo.ObtenerJugador(i);
                    Console.WriteLine((i + 1) + ". " + j.ObtenerNombre());
                }
                int ind2 = Convert.ToInt32(Console.ReadLine()) - 1;
                if (ind2 < 0 || ind2 >= total || ind2 == ind1)
                {
                    Console.WriteLine("Índice inválido.");
                    continue;
                }

                // Solicitar los puntos obtenidos por cada jugador
                Console.Write("Puntos de " + torneo.ObtenerJugador(ind1).ObtenerNombre() + ": ");
                int p1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Puntos de " + torneo.ObtenerJugador(ind2).ObtenerNombre() + ": ");
                int p2 = Convert.ToInt32(Console.ReadLine());

                // Crear partido, jugar y mostrar resultado
                Partido partido = new Partido(torneo.ObtenerJugador(ind1), torneo.ObtenerJugador(ind2));
                partido.JugarPartido(p1, p2);
                Console.WriteLine("Resultado registrado: " + partido.ObtenerResultado());
            }
            else if (opcion == "4")
            {
                // Mostrar clasificación general del torneo
                torneo.MostrarClasificacion();
            }
            else if (opcion == "5")
            {
                // Mostrar estadísticas específicas de un jugador dado su nombre
                Console.Write("Ingrese el nombre del jugador: ");
                string nombre = Console.ReadLine();
                torneo.MostrarEstadisticasJugador(nombre);
            }
            else if (opcion == "6")
            {
                // Salir del programa
                Console.WriteLine("Saliendo...");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida, intente de nuevo.");
            }
        }
    }
}
