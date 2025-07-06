}
using System;

namespace LigaBetPlay
{
    // Clase que representa un jugador de fútbol
    class Jugador
    {
        // Atributos privados (encapsulamiento)
        private string nombre;
        private string posicion;
        private Equipo equipo; // Asociación: cada jugador pertenece a un equipo

        // Constructor de jugador
        public Jugador(string nombreJugador, string posicionJugador, Equipo equipoJugador)
        {
            nombre = nombreJugador;
            posicion = posicionJugador;
            equipo = equipoJugador;
        }

        // No se usan getters ni setters como se solicitó
    }

    // Clase que representa un equipo de fútbol
    class Equipo
    {
        // Atributos del equipo
        private string nombre;
        private string ciudad;
        private int ganados;
        private int perdidos;
        private int empatados;
        private int golesAFavor;
        private int golesEnContra;

        private Jugador[] jugadores = new Jugador[20]; // Arreglo para hasta 20 jugadores
        private int cantidadJugadores = 0; // Contador de jugadores actuales

        // Constructor
        public Equipo(string nombreEquipo, string ciudadEquipo)
        {
            nombre = nombreEquipo;
            ciudad = ciudadEquipo;
        }

        // Método para obtener el nombre del equipo (usado para buscar el equipo)
        public string ObtenerNombre()
        {
            return nombre;
        }

        // Método para agregar un jugador al equipo
        public void AgregarJugador(Jugador jugador)
        {
            if (cantidadJugadores < 20)
            {
                jugadores[cantidadJugadores] = jugador;
                cantidadJugadores++;
            }
        }

        // Método para actualizar estadísticas luego de un partido
        public void ActualizarEstadisticas(int golesPropios, int golesRivales)
        {
            golesAFavor += golesPropios;
            golesEnContra += golesRivales;

            if (golesPropios > golesRivales)
                ganados++;
            else if (golesPropios < golesRivales)
                perdidos++;
            else
                empatados++;
        }

        // Muestra todas las estadísticas del equipo
        public void MostrarEstadisticas()
        {
            Console.WriteLine("Equipo: " + nombre);
            Console.WriteLine("Ciudad: " + ciudad);
            Console.WriteLine("Ganados: " + ganados);
            Console.WriteLine("Perdidos: " + perdidos);
            Console.WriteLine("Empatados: " + empatados);
            Console.WriteLine("Goles a favor: " + golesAFavor);
            Console.WriteLine("Goles en contra: " + golesEnContra);
        }
    }

    // Clase que representa un partido de fútbol
    class Partido
    {
        // Equipos que juegan
        private Equipo local;
        private Equipo visitante;

        // Goles de cada equipo
        private int golesLocal;
        private int golesVisitante;

        // Método para registrar el partido (asignar equipos y actualizar estadísticas)
        public void Registrar(Equipo equipoLocal, Equipo equipoVisitante, int golesEquipoLocal, int golesEquipoVisitante)
        {
            local = equipoLocal;
            visitante = equipoVisitante;
            golesLocal = golesEquipoLocal;
            golesVisitante = golesEquipoVisitante;

            // Actualiza estadísticas en ambos equipos
            local.ActualizarEstadisticas(golesEquipoLocal, golesEquipoVisitante);
            visitante.ActualizarEstadisticas(golesEquipoVisitante, golesEquipoLocal);
        }
    }

    // Clase principal que gestiona toda la liga
    class LigaBetPlayManager
    {
        // Arreglo de equipos (máximo 20 equipos)
        private Equipo[] equipos = new Equipo[20];
        private int cantidadEquipos = 0;

        // Arreglo de partidos (máximo 100 partidos)
        private Partido[] partidos = new Partido[100];
        private int cantidadPartidos = 0;

        // Método para registrar un nuevo equipo
        public void RegistrarEquipo(string nombreEquipo, string ciudadEquipo)
        {
            if (cantidadEquipos < 20)
            {
                equipos[cantidadEquipos] = new Equipo(nombreEquipo, ciudadEquipo);
                cantidadEquipos++;
                Console.WriteLine("Equipo registrado correctamente.");
            }
            else
            {
                Console.WriteLine("No se pueden registrar más equipos.");
            }
        }

        // Método para registrar un nuevo jugador
        public void RegistrarJugador(string nombreJugador, string posicionJugador, string nombreEquipo)
        {
            // Buscar el equipo por nombre
            for (int i = 0; i < cantidadEquipos; i++)
            {
                if (equipos[i].ObtenerNombre() == nombreEquipo)
                {
                    Jugador nuevo = new Jugador(nombreJugador, posicionJugador, equipos[i]);
                    equipos[i].AgregarJugador(nuevo);
                    Console.WriteLine("Jugador registrado.");
                    return;
                }
            }

            Console.WriteLine("Equipo no encontrado.");
        }

        // Método para registrar un nuevo partido
        public void RegistrarPartido(string nombreLocal, string nombreVisitante, int golesLocal, int golesVisitante)
        {
            Equipo equipoLocal = null;
            Equipo equipoVisitante = null;

            // Buscar ambos equipos
            for (int i = 0; i < cantidadEquipos; i++)
            {
                if (equipos[i].ObtenerNombre() == nombreLocal)
                    equipoLocal = equipos[i];
                if (equipos[i].ObtenerNombre() == nombreVisitante)
                    equipoVisitante = equipos[i];
            }

            // Verificar que ambos existan
            if (equipoLocal != null && equipoVisitante != null)
            {
                Partido nuevoPartido = new Partido();
                nuevoPartido.Registrar(equipoLocal, equipoVisitante, golesLocal, golesVisitante);
                partidos[cantidadPartidos] = nuevoPartido;
                cantidadPartidos++;
                Console.WriteLine("Partido registrado.");
            }
            else
            {
                Console.WriteLine("Uno o ambos equipos no fueron encontrados.");
            }
        }

        // Muestra las estadísticas de un equipo
        public void MostrarEstadisticas(string nombreEquipo)
        {
            for (int i = 0; i < cantidadEquipos; i++)
            {
                if (equipos[i].ObtenerNombre() == nombreEquipo)
                {
                    equipos[i].MostrarEstadisticas();
                    return;
                }
            }
            Console.WriteLine("Equipo no encontrado.");
        }
    }

    // Clase Main (punto de entrada del programa)
    class Program
    {
        static void Main(string[] args)
        {
            LigaBetPlayManager liga = new LigaBetPlayManager();
            int opcion = 0;

            while (opcion != 5)
            {
                // Menú principal
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Registrar jugador");
                Console.WriteLine("3. Registrar partido");
                Console.WriteLine("4. Ver estadísticas de equipo");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                string entrada = Console.ReadLine();

                // Validación de opción
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    opcion = 0;
                    continue;
                }

                // Opciones del menú
                if (opcion == 1)
                {
                    Console.Write("Nombre del equipo: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ciudad: ");
                    string ciudad = Console.ReadLine();
                    liga.RegistrarEquipo(nombre, ciudad);
                }
                else if (opcion == 2)
                {
                    Console.Write("Nombre del jugador: ");
                    string nombreJugador = Console.ReadLine();
                    Console.Write("Posición: ");
                    string posicion = Console.ReadLine();
                    Console.Write("Nombre del equipo: ");
                    string nombreEquipo = Console.ReadLine();
                    liga.RegistrarJugador(nombreJugador, posicion, nombreEquipo);
                }
                else if (opcion == 3)
                {
                    Console.Write("Equipo local: ");
                    string local = Console.ReadLine();
                    Console.Write("Equipo visitante: ");
                    string visitante = Console.ReadLine();
                    Console.Write("Goles equipo local: ");
                    int golesL = int.Parse(Console.ReadLine());
                    Console.Write("Goles equipo visitante: ");
                    int golesV = int.Parse(Console.ReadLine());
                    liga.RegistrarPartido(local, visitante, golesL, golesV);
                }
                else if (opcion == 4)
                {
                    Console.Write("Nombre del equipo: ");
                    string nombre = Console.ReadLine();
                    liga.MostrarEstadisticas(nombre);
                }
                else if (opcion != 5)
                {
                    Console.WriteLine("Opción inválida.");
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
    }
}
