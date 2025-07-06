using System;
// Clase que representa un plato con atributos y comportamientos
class Plato
{
    // Atributos privados del plato
    private string nombre;
    private int frescura;
    private int presentacion;
    private int calidad;
    private bool esEstrella;

    // Constructor que inicializa un plato con sus valores
    public Plato(string Nombre, int Frescura, int Presentacion, int Calidad)
    {
        nombre = Nombre;
        frescura = Frescura;
        presentacion = Presentacion;
        calidad = Calidad;
        esEstrella = false; // Por defecto, el plato no es estrella
    }

    // Método para obtener el nombre del plato
    public string ObtenerNombre()
    {
        return nombre;
    }

    // Método para asignar una nueva calidad al plato (solo si está entre 0 y 10)
    public void EvaluarCalidad(int nuevaCalidad)
    {
        if (nuevaCalidad >= 0 && nuevaCalidad <= 10)
        {
            calidad = nuevaCalidad;
        }
    }

    // Método para mejorar la presentación del plato, hasta un máximo de 10
    public void MejorarPresentacion()
    {
        if (presentacion < 10)
        {
            presentacion++;
        }
    }

    // Marca el plato como Plato Estrella del Mes
    public void MarcarEstrella()
    {
        esEstrella = true;
    }

    // Quita el estado de Plato Estrella
    public void DesmarcarEstrella()
    {
        esEstrella = false;
    }

    // Devuelve si el plato es o no el Plato Estrella
    public bool EsEstrella()
    {
        return esEstrella;
    }

    // Muestra todos los detalles del plato en consola
    public void Mostrar()
    {
        Console.WriteLine($"Nombre: {nombre}, Frescura: {frescura}, Presentación: {presentacion}, Calidad: {calidad}" +
            $"{(esEstrella ? " ⭐ Plato Estrella del Mes ⭐" : "")}");
    }
}

// Clase principal que contiene el menú y la lógica del programa
class Programa
{
    static void Main()
    {
        // Arreglo para guardar hasta 5 platos
        Plato[] platos = new Plato[5];
        int cantidadRegistrada = 0; // Lleva la cuenta de cuántos platos se han registrado

        // Ciclo principal del menú
        while (true)
        {
            // Menú de opciones
            Console.WriteLine("\n--- Menú Casalins ---");
            Console.WriteLine("1. Registrar nuevo plato");
            Console.WriteLine("2. Evaluar calidad de un plato");
            Console.WriteLine("3. Mejorar presentación de un plato");
            Console.WriteLine("4. Mostrar todos los platos");
            Console.WriteLine("5. Marcar Plato Estrella del Mes");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Opción 1: Registrar un nuevo plato
            if (opcion == "1")
            {
                if (cantidadRegistrada >= 5)
                {
                    Console.WriteLine("Ya se registraron los 5 platos permitidos.");
                }
                else
                {
                    // Se piden los datos del nuevo plato
                    Console.Write("Nombre del plato: ");
                    string Nombre = Console.ReadLine();
                    Console.Write("Frescura (0-10): ");
                    int Frescura = int.Parse(Console.ReadLine());
                    Console.Write("Presentación (0-10): ");
                    int Presentacion = int.Parse(Console.ReadLine());
                    Console.Write("Calidad (0-10): ");
                    int Calidad = int.Parse(Console.ReadLine());

                    // Se crea y se guarda el nuevo plato
                    platos[cantidadRegistrada] = new Plato(Nombre, Frescura, Presentacion, Calidad);
                    cantidadRegistrada++;
                    Console.WriteLine("Plato registrado.");
                }
            }

            // Opción 2: Evaluar la calidad de un plato existente
            else if (opcion == "2")
            {
                MostrarPlatos(platos, cantidadRegistrada); // Se muestran los platos para elegir
                Console.Write("Número del plato a evaluar: ");
                int valoracion = int.Parse(Console.ReadLine()) - 1;
                if (valoracion >= 0 && valoracion < cantidadRegistrada)
                {
                    Console.Write("Nueva calidad (0-10): ");
                    int nuevaCalidad = int.Parse(Console.ReadLine());
                    platos[valoracion].EvaluarCalidad(nuevaCalidad); // Se actualiza la calidad
                    Console.WriteLine("Calidad actualizada.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }

            // Opción 3: Mejorar la presentación de un plato
            else if (opcion == "3")
            {
                MostrarPlatos(platos, cantidadRegistrada); // Se muestran los platos
                Console.Write("Número del plato a mejorar presentación: ");
                int presentacionPlato = int.Parse(Console.ReadLine()) - 1;
                if (presentacionPlato >= 0 && presentacionPlato < cantidadRegistrada)
                {
                    platos[presentacionPlato].MejorarPresentacion(); // Aumenta en 1 la presentación (hasta 10)
                    Console.WriteLine("Presentación mejorada.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }

            // Opción 4: Mostrar todos los platos registrados
            else if (opcion == "4")
            {
                MostrarPlatos(platos, cantidadRegistrada);
            }

            // Opción 5: Marcar uno de los platos como "Plato Estrella del Mes"
            else if (opcion == "5")
            {
                MostrarPlatos(platos, cantidadRegistrada); // Se muestran los platos
                Console.Write("Número del Plato Estrella del Mes: ");
                int platoEstrella = int.Parse(Console.ReadLine()) - 1;
                if (platoEstrella >= 0 && platoEstrella < cantidadRegistrada)
                {
                    // Se recorre todos los platos: uno se marca como estrella, los demás se desmarcan
                    for (int i = 0; i < cantidadRegistrada; i++)
                    {
                        if (i == platoEstrella)
                            platos[i].MarcarEstrella();
                        else
                            platos[i].DesmarcarEstrella();
                    }
                    Console.WriteLine("Plato Estrella actualizado.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }

            // Opción 6: Salir del programa
            else if (opcion == "6")
            {
                Console.WriteLine("Gracias por usar el sistema Casalins.");
                break;
            }

            // Si se ingresa una opción no válida
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
    }

    // Método auxiliar para mostrar todos los platos registrados
    static void MostrarPlatos(Plato[] platos, int cantidad)
    {
        if (cantidad == 0)
        {
            Console.WriteLine("No hay platos registrados.");
            return;
        }

        // Muestra uno a uno con su número correspondiente
        for (int i = 0; i < cantidad; i++)
        {
            Console.Write($"{i + 1}. ");
            platos[i].Mostrar();
        }
    }
}
