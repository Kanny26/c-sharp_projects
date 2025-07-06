using System; // Importa la biblioteca base para entrada/salida y otras utilidades

// Clase que representa a un estudiante
class Estudiante
{
    // Atributos privados (encapsulados)
    private int id;
    private string nombre;
    private int edad;
    private string nivel;

    // Constructor para inicializar un estudiante con sus datos
    public Estudiante(int idEstudiante, string nombreEstudiante, int edadEstudiante, string nivelEstudiante)
    {
        id = idEstudiante;
        nombre = nombreEstudiante;
        edad = edadEstudiante;
        nivel = nivelEstudiante;
    }

    // Métodos públicos para acceder y modificar los atributos

    public int ObtenerID() // Devuelve el ID del estudiante
    {
        return id;
    }

    public string ObtenerNombre() // Devuelve el nombre del estudiante
    {
        return nombre;
    }

    public int ObtenerEdad() // Devuelve la edad del estudiante
    {
        return edad;
    }

    public string ObtenerNivel() // Devuelve el nivel de inglés del estudiante
    {
        return nivel;
    }

    public void ActualizarNivel(string nuevoNivel) // Permite actualizar el nivel de inglés
    {
        nivel = nuevoNivel;
    }
}

// Clase principal del programa
class Programa
{
    // Arreglo para almacenar hasta 100 estudiantes
    static Estudiante[] vectorEstudiantes = new Estudiante[100];

    // Contador de cuántos estudiantes han sido registrados
    static int cantidadEstudiantes = 0;

    // ID que se asignará al próximo estudiante registrado
    static int siguienteID = 1;

    // Método principal
    static void Main()
    {
        // Ciclo principal del menú
        while (true)
        {
            // Mostrar opciones del menú
            Console.WriteLine("\n--- Menú de Gestión de Niveles de Inglés ---");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Actualizar nivel de inglés");
            Console.WriteLine("3. Consultar estudiante por nombre o ID");
            Console.WriteLine("4. Ver estudiantes con nivel C1 o superior");
            Console.WriteLine("5. Ver promedio de niveles alcanzados");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string opcionIngresada = Console.ReadLine();

            // Ejecutar la acción correspondiente
            if (opcionIngresada == "1")
            {
                RegistrarEstudiante();
            }
            else if (opcionIngresada == "2")
            {
                ActualizarNivel();
            }
            else if (opcionIngresada == "3")
            {
                ConsultarEstudiante();
            }
            else if (opcionIngresada == "4")
            {
                MostrarAvanzados();
            }
            else if (opcionIngresada == "5")
            {
                CalcularPromedio();
            }
            else if (opcionIngresada == "6")
            {
                break; // Salir del programa
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    // Método para registrar un nuevo estudiante
    static void RegistrarEstudiante()
    {
        if (cantidadEstudiantes >= 100)
        {
            Console.WriteLine("Límite de estudiantes alcanzado.");
            return;
        }

        // Solicitar los datos del estudiante
        Console.Write("Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del estudiante: ");
        int edad = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el nivel de inglés (A1, A2, B1, B2, C1, C2): ");
        string nivel = Console.ReadLine();

        // Crear nuevo estudiante con ID automático
        Estudiante nuevoEstudiante = new Estudiante(siguienteID, nombre, edad, nivel);
        vectorEstudiantes[cantidadEstudiantes] = nuevoEstudiante;

        // Confirmar registro
        Console.WriteLine("Estudiante registrado con ID: " + siguienteID);

        // Actualizar contadores
        siguienteID++;
        cantidadEstudiantes++;
    }

    // Método para actualizar el nivel de inglés de un estudiante
    static void ActualizarNivel()
    {
        Console.Write("Ingrese el ID del estudiante: ");
        int idBuscado = Convert.ToInt32(Console.ReadLine());

        bool encontrado = false;

        // Buscar el estudiante por ID
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            if (vectorEstudiantes[i].ObtenerID() == idBuscado)
            {
                Console.Write("Ingrese el nuevo nivel (A1, A2, B1, B2, C1, C2): ");
                string nuevoNivel = Console.ReadLine();

                // Actualizar el nivel
                vectorEstudiantes[i].ActualizarNivel(nuevoNivel);
                Console.WriteLine("Nivel actualizado correctamente.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    // Método para consultar un estudiante por nombre o ID
    static void ConsultarEstudiante()
    {
        Console.Write("Ingrese el nombre o ID del estudiante: ");
        string entrada = Console.ReadLine();

        bool encontrado = false;

        // Buscar coincidencia por nombre o ID
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            if (vectorEstudiantes[i].ObtenerNombre() == entrada ||
                vectorEstudiantes[i].ObtenerID().ToString() == entrada)
            {
                // Mostrar información del estudiante
                Console.WriteLine("ID: " + vectorEstudiantes[i].ObtenerID());
                Console.WriteLine("Nombre: " + vectorEstudiantes[i].ObtenerNombre());
                Console.WriteLine("Edad: " + vectorEstudiantes[i].ObtenerEdad());
                Console.WriteLine("Nivel: " + vectorEstudiantes[i].ObtenerNivel());
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    // Método para mostrar estudiantes con nivel C1 o C2
    static void MostrarAvanzados()
    {
        bool alguno = false;
        Console.WriteLine("Estudiantes con nivel C1 o superior:");

        // Recorrer y filtrar por niveles avanzados
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            string nivel = vectorEstudiantes[i].ObtenerNivel();
            if (nivel == "C1" || nivel == "C2")
            {
                Console.WriteLine("- " + vectorEstudiantes[i].ObtenerNombre() + " (Nivel: " + nivel + ")");
                alguno = true;
            }
        }

        if (!alguno)
        {
            Console.WriteLine("No hay estudiantes con nivel C1 o superior.");
        }
    }

    // Método para calcular el promedio numérico de los niveles
    static void CalcularPromedio()
    {
        // Arreglos que representan los niveles y su valor numérico
        string[] niveles = { "A1", "A2", "B1", "B2", "C1", "C2" };
        int[] valores = { 1, 2, 3, 4, 5, 6 };

        int suma = 0;
        int total = 0;

        // Sumar los valores de los niveles
        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            string nivel = vectorEstudiantes[i].ObtenerNivel();

            for (int j = 0; j < niveles.Length; j++)
            {
                if (nivel == niveles[j])
                {
                    suma += valores[j];
                    total++;
                    break;
                }
            }
        }

        // Calcular promedio si hay estudiantes registrados
        if (total > 0)
        {
            double promedio = (double)suma / total;
            Console.WriteLine("Promedio numérico de niveles: " + promedio.ToString("0.00"));
        }
        else
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
    }
}

