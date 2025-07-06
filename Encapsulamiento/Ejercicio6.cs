using System;  // Importa el espacio de nombres System, necesario para usar Console, entre otros.

class Patrulla
{
    // Atributos privados de la clase
    private string nombre;       // Nombre de la patrulla
    private int numero;          // Número identificador de la patrulla
    private string ubicacion;    // Ubicación actual de la patrulla
    private bool disponible;     // Indica si la patrulla está disponible o no

    // Método para asignar valores iniciales a los atributos
    public void AsignarDatos(string nombrePatrulla, int numeroPatrulla, string ubicacionPatrulla)
    {
        nombre = nombrePatrulla;
        numero = numeroPatrulla;
        ubicacion = ubicacionPatrulla;
        disponible = true;  // Al asignar datos, la patrulla se marca como disponible por defecto
    }

    // Métodos para obtener los valores de los atributos (getters)
    public string ObtenerNombre()
    {
        return nombre;
    }

    public int ObtenerNumero()
    {
        return numero;
    }

    public string ObtenerUbicacion()
    {
        return ubicacion;
    }

    public bool EstaDisponible()
    {
        return disponible;
    }

    // Método para cambiar el estado de disponibilidad de la patrulla
    public void CambiarDisponibilidad(bool estado)
    {
        disponible = estado;
    }

    // Método para mostrar la información completa de la patrulla en consola
    public void MostrarInfo()
    {
        Console.WriteLine("Patrulla: " + nombre + " - Nº: " + numero + " - Ubicación: " + ubicacion + " - Disponible: " + disponible);
    }
}


class Incidente
{
    // Atributos privados del incidente
    private string tipo;                   // Tipo de incidente (por ejemplo, robo, accidente, etc.)
    private int prioridad;                 // Prioridad del incidente (por ejemplo, 1 = alta, 2 = media, etc.)
    private string ubicacion;              // Ubicación del incidente
    private bool resuelto;                 // Indica si el incidente ya fue resuelto
    private Patrulla patrullaAsignada;     // Referencia a la patrulla asignada al incidente

    // Método para asignar datos iniciales al incidente
    public void AsignarDatos(string tipoIncidente, int prioridadIncidente, string ubicacionIncidente)
    {
        tipo = tipoIncidente;
        prioridad = prioridadIncidente;
        ubicacion = ubicacionIncidente;
        resuelto = false;                 // Al crear el incidente, se marca como no resuelto
        patrullaAsignada = null;          // Inicialmente no hay patrulla asignada
    }

    // Métodos para obtener los valores de los atributos (getters)
    public string ObtenerTipo()
    {
        return tipo;
    }

    public int ObtenerPrioridad()
    {
        return prioridad;
    }

    public string ObtenerUbicacion()
    {
        return ubicacion;
    }

    public bool EstaResuelto()
    {
        return resuelto;
    }

    // Método para marcar el incidente como resuelto
    public void MarcarResuelto()
    {
        resuelto = true;

        // Si hay una patrulla asignada, se vuelve a marcar como disponible
        if (patrullaAsignada != null)
        {
            patrullaAsignada.CambiarDisponibilidad(true);
        }
    }

    // Método para asignar una patrulla al incidente
    public void AsignarPatrulla(Patrulla p)
    {
        patrullaAsignada = p;
        p.CambiarDisponibilidad(false); // Al asignar la patrulla, se marca como no disponible
    }

    // Método para obtener el nombre de la patrulla asignada, si existe
    public string ObtenerNombrePatrullaAsignada()
    {
        if (patrullaAsignada == null)
        {
            return "No asignada";
        }
        else
        {
            return patrullaAsignada.ObtenerNombre();
        }
    }

    // Método para mostrar la información completa del incidente en consola
    public void MostrarInfo()
    {
        string estado = resuelto ? "Resuelto" : "Pendiente";
        string patrulla = ObtenerNombrePatrullaAsignada();

        Console.WriteLine("Incidente: " + tipo +
                          " - Prioridad: " + prioridad +
                          " - Ubicación: " + ubicacion +
                          " - Estado: " + estado +
                          " - Patrulla: " + patrulla);
    }
}

class SistemaSeguridad
{
    // Arreglos para almacenar patrullas e incidentes
    private Patrulla[] patrullas;
    private Incidente[] incidentes;

    // Contadores para llevar registro del número actual de patrullas e incidentes registrados
    private int contadorPatrullas;
    private int contadorIncidentes;

    // Constructor que inicializa los arreglos con tamaños máximos definidos
    public SistemaSeguridad(int maxPatrullas, int maxIncidentes)
    {
        patrullas = new Patrulla[maxPatrullas];
        incidentes = new Incidente[maxIncidentes];
        contadorPatrullas = 0;
        contadorIncidentes = 0;
    }

    // Método para registrar una patrulla
    public void RegistrarPatrulla(string nombre, int numero, string ubicacion)
    {
        // Verifica que aún haya espacio en el arreglo
        if (contadorPatrullas < patrullas.Length)
        {
            // Crea una nueva patrulla, asigna datos y la almacena
            Patrulla p = new Patrulla();
            p.AsignarDatos(nombre, numero, ubicacion);
            patrullas[contadorPatrullas] = p;
            contadorPatrullas++;
            Console.WriteLine("Patrulla registrada correctamente.");
        }
        else
        {
            Console.WriteLine("No se pueden registrar más patrullas.");
        }
    }

    // Método para registrar un incidente
    public void RegistrarIncidente(string tipo, int prioridad, string ubicacion)
    {
        // Verifica que aún haya espacio en el arreglo
        if (contadorIncidentes < incidentes.Length)
        {
            // Crea un nuevo incidente, asigna datos y lo almacena
            Incidente i = new Incidente();
            i.AsignarDatos(tipo, prioridad, ubicacion);
            incidentes[contadorIncidentes] = i;
            contadorIncidentes++;
            Console.WriteLine("Incidente registrado correctamente.");
        }
        else
        {
            Console.WriteLine("No se pueden registrar más incidentes.");
        }
    }

    // Método que asigna patrullas disponibles a incidentes no resueltos
    public void AsignarPatrullasAIncidentes()
    {
        bool asignacionRealizada = false;

        // Recorre todos los incidentes registrados
        for (int i = 0; i < contadorIncidentes; i++)
        {
            // Verifica si el incidente no está resuelto y no tiene patrulla asignada
            if (!incidentes[i].EstaResuelto() && incidentes[i].ObtenerNombrePatrullaAsignada() == "No asignada")
            {
                bool patrullaEncontrada = false;

                // Recorre todas las patrullas registradas para buscar una disponible en la misma ubicación
                for (int j = 0; j < contadorPatrullas && !patrullaEncontrada; j++)
                {
                    if (patrullas[j].EstaDisponible() && patrullas[j].ObtenerUbicacion() == incidentes[i].ObtenerUbicacion())
                    {
                        // Asigna la patrulla al incidente y marca la patrulla como no disponible
                        incidentes[i].AsignarPatrulla(patrullas[j]);
                        Console.WriteLine("Asignada patrulla '" + patrullas[j].ObtenerNombre() + "' al incidente '" + incidentes[i].ObtenerTipo() + "'.");
                        patrullaEncontrada = true;
                        asignacionRealizada = true;
                    }
                }

                // Si no se encontró patrulla para ese incidente
                if (!patrullaEncontrada)
                {
                    Console.WriteLine("No hay patrullas disponibles para incidente en " + incidentes[i].ObtenerUbicacion() + ".");
                }
            }
        }

        // Si no se hizo ninguna asignación
        if (!asignacionRealizada)
        {
            Console.WriteLine("No hay incidentes pendientes sin patrulla asignada o no hay patrullas disponibles.");
        }
    }

    // Método para marcar un incidente como resuelto por índice
    public void MarcarIncidenteResuelto(int indice)
    {
        // Verifica que el índice sea válido
        if (indice >= 0 && indice < contadorIncidentes)
        {
            if (!incidentes[indice].EstaResuelto())
            {
                // Marca el incidente como resuelto y libera la patrulla
                incidentes[indice].MarcarResuelto();
                Console.WriteLine("Incidente marcado como resuelto.");
            }
            else
            {
                Console.WriteLine("El incidente ya está resuelto.");
            }
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    // Muestra la información de todas las patrullas registradas
    public void MostrarPatrullas()
    {
        Console.WriteLine("----- Lista de Patrullas -----");

        // Recorre el arreglo de patrullas hasta el contador
        for (int i = 0; i < contadorPatrullas; i++)
        {
            patrullas[i].MostrarInfo();
        }
    }

    // Muestra la información de todos los incidentes registrados
    public void MostrarIncidentes()
    {
        Console.WriteLine("----- Lista de Incidentes -----");

        // Recorre el arreglo de incidentes hasta el contador
        for (int i = 0; i < contadorIncidentes; i++)
        {
            Console.Write(i + ") "); // Muestra el índice del incidente
            incidentes[i].MostrarInfo();
        }
    }
}




class Program
{
    static void Main()
    {
        // Se crea una instancia del sistema de seguridad con capacidad para 10 patrullas y 10 incidentes.
        SistemaSeguridad sistema = new SistemaSeguridad(10, 10);
        bool continuar = true; // Variable de control para mantener el menú activo

        // Bucle principal que muestra el menú hasta que el usuario decida salir
        while (continuar)
        {
            // Menú de opciones mostrado al usuario
            Console.WriteLine("\n--- MENU DE SEGURIDAD ---");
            Console.WriteLine("1. Registrar patrulla");
            Console.WriteLine("2. Registrar incidente");
            Console.WriteLine("3. Asignar patrullas a incidentes");
            Console.WriteLine("4. Marcar incidente como resuelto");
            Console.WriteLine("5. Mostrar patrullas");
            Console.WriteLine("6. Mostrar incidentes");
            Console.WriteLine("7. Salir");
            Console.Write("Ingrese opción: ");
            string opcion = Console.ReadLine(); // Lee la opción del usuario como texto

            // Estructura de control que evalúa la opción seleccionada
            if (opcion == "1")
            {
                // Solicita los datos de la patrulla al usuario
                Console.Write("Nombre de la patrulla (por ejemplo: Patrulla del sur): ");
                string nombre = Console.ReadLine();
                Console.Write("Número de la patrulla: ");
                int numero = int.Parse(Console.ReadLine());
                Console.Write("Ubicación (nombre del barrio): ");
                string ubicacion = Console.ReadLine();

                // Llama al método que registra una patrulla en el sistema
                sistema.RegistrarPatrulla(nombre, numero, ubicacion);
            }
            else if (opcion == "2")
            {
                // Solicita los datos del incidente al usuario
                Console.Write("Tipo de incidente (robo, pelea, etc.): ");
                string tipo = Console.ReadLine();
                Console.Write("Prioridad (1=alta, 2=media, 3=baja): ");
                int prioridad = int.Parse(Console.ReadLine());
                Console.Write("Ubicación (nombre del barrio): ");
                string ubicacion = Console.ReadLine();

                // Llama al método para registrar el incidente
                sistema.RegistrarIncidente(tipo, prioridad, ubicacion);
            }
            else if (opcion == "3")
            {
                // Intenta asignar patrullas disponibles a incidentes no resueltos
                sistema.AsignarPatrullasAIncidentes();
            }
            else if (opcion == "4")
            {
                // Muestra la lista de incidentes primero
                sistema.MostrarIncidentes();

                // Solicita al usuario el número del incidente a marcar como resuelto
                Console.Write("Ingrese el número del incidente a marcar como resuelto: ");
                int indice = int.Parse(Console.ReadLine());

                // Llama al método que marca el incidente como resuelto
                sistema.MarcarIncidenteResuelto(indice);
            }
            else if (opcion == "5")
            {
                // Muestra todas las patrullas registradas
                sistema.MostrarPatrullas();
            }
            else if (opcion == "6")
            {
                // Muestra todos los incidentes registrados
                sistema.MostrarIncidentes();
            }
            else if (opcion == "7")
            {
                // Sale del ciclo y finaliza el programa
                continuar = false;
                Console.WriteLine("Saliendo del sistema...");
            }
            else
            {
                // Si la opción ingresada no es válida
                Console.WriteLine("Opción inválida, intente de nuevo.");
            }
        }
    }
}
