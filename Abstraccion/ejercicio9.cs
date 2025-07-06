using System;

// Clase que representa el sistema de asistencia
class SistemaAsistencia
{
    // Arreglos para guardar nombres y asistencias de los aprendices
    public string[] nombres;
    public int[] asistencias;

    // Cantidad actual de aprendices registrados
    public int cantidad;

    // Constructor que inicializa el sistema con una capacidad dada
    public SistemaAsistencia(int capacidad)
    {
        nombres = new string[capacidad];       // Inicializa el arreglo de nombres
        asistencias = new int[capacidad];      // Inicializa el arreglo de asistencias
        cantidad = 0;                          // Inicialmente no hay aprendices
    }

    // Agrega un nuevo aprendiz al sistema
    public void AgregarAprendiz(string nombre)
    {
        if (BuscarIndice(nombre) == -1 && cantidad < nombres.Length)
        {
            nombres[cantidad] = nombre;         // Agrega el nombre en la posición actual
            asistencias[cantidad] = 0;          // Inicializa su asistencia en 0
            cantidad++;                         // Aumenta el contador de aprendices
            Console.WriteLine("Aprendiz agregado exitosamente.\n");
        }
        else
        {
            Console.WriteLine("Error: El aprendiz ya está registrado o no hay espacio disponible.\n");
        }
    }

    // Marca una asistencia para un aprendiz
    public void MarcarAsistencia(string nombre)
    {
        int indice = BuscarIndice(nombre);      // Busca al aprendiz por su nombre
        if (indice != -1)
        {
            asistencias[indice]++;              // Incrementa su asistencia
            Console.WriteLine("Asistencia registrada correctamente.\n");
        }
        else
        {
            Console.WriteLine("Error: El aprendiz no está registrado.\n");
        }
    }

    // Consulta cuántas asistencias tiene un aprendiz
    public void ConsultarAsistencia(string nombre)
    {
        int indice = BuscarIndice(nombre);      // Busca al aprendiz por su nombre
        if (indice != -1)
        {
            Console.WriteLine("El aprendiz " + nombre + " ha asistido " + asistencias[indice] + " días.\n");
        }
        else
        {
            Console.WriteLine("El aprendiz no está registrado.\n");
        }
    }

    // Genera un reporte final con información de todos los aprendices
    public void GenerarReporteFinal(int umbral)
    {
        Console.WriteLine("\n--- Reporte Final ---");

        if (cantidad == 0)
        {
            Console.WriteLine("No hay aprendices registrados.\n");
            return;
        }

        // Muestra la asistencia de todos los aprendices
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine(nombres[i] + ": " + asistencias[i] + " días");
        }

        // Determina la asistencia máxima registrada
        int maxAsistencia = asistencias[0];
        for (int i = 1; i < cantidad; i++)
        {
            if (asistencias[i] > maxAsistencia)
            {
                maxAsistencia = asistencias[i];
            }
        }

        // Muestra los aprendices con la mayor asistencia
        Console.WriteLine("\nAprendiz(es) con mayor asistencia (" + maxAsistencia + " días):");
        for (int i = 0; i < cantidad; i++)
        {
            if (asistencias[i] == maxAsistencia)
            {
                Console.WriteLine("- " + nombres[i]);
            }
        }

        // Muestra los aprendices que tienen asistencia por debajo del umbral
        Console.WriteLine("\nAprendices con asistencia menor a " + umbral + " días:");
        for (int i = 0; i < cantidad; i++)
        {
            if (asistencias[i] < umbral)
            {
                Console.WriteLine("- " + nombres[i] + ": " + asistencias[i] + " días");
            }
        }

        Console.WriteLine();
    }

    // Método privado que busca el índice de un aprendiz por nombre
    public int BuscarIndice(string nombre)
    {
        for (int i = 0; i < cantidad; i++)
        {
            if (nombres[i] == nombre)
            {
                return i;
            }
        }
        return -1; // Si no se encuentra
    }

    // Método auxiliar para obtener el nombre de un aprendiz por índice
    public string MostrarNombre(int indice)
    {
        if (indice >= 0 && indice < cantidad)
        {
            return nombres[indice];
        }
        return "";
    }

    // Devuelve la cantidad actual de aprendices registrados
    public int ObtenerCantidad()
    {
        return cantidad;
    }
}

// Clase principal que ejecuta el programa
internal class Program
{
    static void Main()
    {
        // Se crea una instancia del sistema con capacidad para 100 aprendices
        SistemaAsistencia sistema = new SistemaAsistencia(100);
        int opcion = 0;

        // Ciclo principal del menú
        while (opcion != 5)
        {
            // Muestra el menú de opciones
            Console.WriteLine("--- MENÚ DE ASISTENCIA SENA ---");
            Console.WriteLine("1. Agregar aprendiz");
            Console.WriteLine("2. Marcar asistencia");
            Console.WriteLine("3. Consultar asistencia");
            Console.WriteLine("4. Generar reporte final");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            // Opción 1: Agregar un aprendiz
            if (opcion == 1)
            {
                Console.Write("Ingrese el nombre del aprendiz: ");
                string nombre = Console.ReadLine();
                sistema.AgregarAprendiz(nombre);
            }
            // Opción 2: Marcar asistencia
            else if (opcion == 2)
            {
                Console.WriteLine("\nAprendices registrados:");
                int total = sistema.ObtenerCantidad();
                if (total == 0)
                {
                    Console.WriteLine("No hay aprendices registrados.\n");
                }
                else
                {
                    // Muestra todos los nombres disponibles para que el usuario seleccione
                    for (int i = 0; i < total; i++)
                    {
                        Console.WriteLine("- " + sistema.MostrarNombre(i));
                    }

                    Console.Write("\nIngrese el nombre del aprendiz para marcar asistencia: ");
                    string nombre = Console.ReadLine();
                    sistema.MarcarAsistencia(nombre);
                }
            }
            // Opción 3: Consultar asistencia individual
            else if (opcion == 3)
            {
                Console.Write("Ingrese el nombre del aprendiz: ");
                string nombre = Console.ReadLine();
                sistema.ConsultarAsistencia(nombre);
            }
            // Opción 4: Generar reporte final
            else if (opcion == 4)
            {
                Console.Write("Ingrese el umbral de asistencia (ej. 3): ");
                int umbral = int.Parse(Console.ReadLine());
                sistema.GenerarReporteFinal(umbral);
            }
            // Opción 5: Salir del programa
            else if (opcion == 5)
            {
                Console.WriteLine("¡Gracias por usar el sistema!");
            }
            // Opción inválida
            else
            {
                Console.WriteLine("Opción inválida.\n");
            }
        }
    }
}
