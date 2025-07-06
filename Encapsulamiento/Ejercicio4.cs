using System; // Importa funcionalidades básicas del sistema, como entrada/salida por consola.

// Clase que representa una marca con criterios de sostenibilidad.
class MarcaSostenible
{
    // Atributos privados de la marca.
    private string nombre;
    private string categoria;
    private bool usaMaterialesReciclados;
    private int nivelSostenibilidad;

    // Constructor que inicializa los atributos con los valores proporcionados.
    public MarcaSostenible(string nombreMarca, string categoriaMarca, bool materialesReciclados, int nivel)
    {
        nombre = nombreMarca;
        categoria = categoriaMarca;
        usaMaterialesReciclados = materialesReciclados;
        nivelSostenibilidad = nivel;
    }

    // Método para mejorar el nivel de sostenibilidad, limitado a un máximo de 5.
    public void MejorarSostenibilidad(int incremento)
    {
        nivelSostenibilidad += incremento;
        if (nivelSostenibilidad > 5)
        {
            nivelSostenibilidad = 5;
        }
    }

    // Muestra en pantalla los datos de la marca.
    public void MostrarInfo()
    {
        Console.WriteLine($"Marca: {nombre}");
        Console.WriteLine($"Categoría: {categoria}");
        Console.WriteLine($"Usa materiales reciclados: {(usaMaterialesReciclados ? "Sí" : "No")}");
        Console.WriteLine($"Nivel de Sostenibilidad: {nivelSostenibilidad}");
    }

    // Devuelve el nombre de la marca.
    public string ObtenerNombre()
    {
        return nombre;
    }
}

// Clase que gestiona un conjunto de marcas sostenibles.
class GestorMarcas
{
    private MarcaSostenible[] marcas; // Arreglo de marcas.
    private int contadorMarcas; // Número actual de marcas registradas.
    private MarcaSostenible marcaFavorita; // Marca seleccionada como favorita.

    // Constructor: inicializa el arreglo con capacidad para 10 marcas.
    public GestorMarcas()
    {
        marcas = new MarcaSostenible[10];
        contadorMarcas = 0;
        marcaFavorita = null;
    }

    // Permite agregar una nueva marca a la lista.
    public void AgregarMarca()
    {
        if (contadorMarcas < marcas.Length)
        {
            Console.Write("Ingrese el nombre de la marca: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la categoría de la marca: ");
            string categoria = Console.ReadLine();

            Console.Write("¿La marca usa materiales reciclados? (si/no): ");
            bool usaMaterialesReciclados = Console.ReadLine().ToLower() == "si";

            Console.Write("Ingrese el nivel de sostenibilidad (1-5): ");
            int nivelSostenibilidad = int.Parse(Console.ReadLine());

            // Se crea una nueva instancia de MarcaSostenible y se guarda en el arreglo.
            marcas[contadorMarcas] = new MarcaSostenible(nombre, categoria, usaMaterialesReciclados, nivelSostenibilidad);
            contadorMarcas++;

            Console.WriteLine("Marca agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pueden agregar más marcas.");
        }
    }

    // Permite buscar y evaluar una marca ya registrada.
    public void EvaluarMarca()
    {
        MostrarNombresDeMarcas();

        Console.Write("Ingrese el nombre de la marca a evaluar: ");
        string nombre = Console.ReadLine();

        MarcaSostenible marca = BuscarMarca(nombre);

        if (marca != null)
        {
            Console.WriteLine("Información de la marca:");
            marca.MostrarInfo();

            Console.Write("¿Desea mejorar su sostenibilidad? (si/no): ");
            if (Console.ReadLine().ToLower() == "si")
            {
                Console.Write("Ingrese el incremento (1-5): ");
                int incremento = int.Parse(Console.ReadLine());
                marca.MejorarSostenibilidad(incremento);
                Console.WriteLine("Sostenibilidad actualizada.");
            }
        }
        else
        {
            Console.WriteLine("Marca no encontrada.");
        }
    }

    // Permite seleccionar una marca como la favorita del mes.
    public void SeleccionarMarcaFavorita()
    {
        MostrarNombresDeMarcas();

        Console.Write("Ingrese el nombre de la marca favorita: ");
        string nombre = Console.ReadLine();

        MarcaSostenible marca = BuscarMarca(nombre);

        if (marca != null)
        {
            marcaFavorita = marca;
            Console.WriteLine($"Marca {nombre} seleccionada como favorita del mes.");
        }
        else
        {
            Console.WriteLine("Marca no encontrada.");
        }
    }

    // Muestra la información de todas las marcas registradas y la marca favorita (si existe).
    public void MostrarMarcas()
    {
        if (contadorMarcas == 0)
        {
            Console.WriteLine("No hay marcas registradas.");
            return;
        }

        Console.WriteLine("Listado de marcas:");
        for (int i = 0; i < contadorMarcas; i++)
        {
            marcas[i].MostrarInfo();
            Console.WriteLine();
        }

        if (marcaFavorita != null)
        {
            Console.WriteLine($"Marca favorita del mes: {marcaFavorita.ObtenerNombre()}");
        }
    }

    // Busca una marca por su nombre (sin importar mayúsculas/minúsculas).
    private MarcaSostenible BuscarMarca(string nombre)
    {
        for (int i = 0; i < contadorMarcas; i++)
        {
            if (marcas[i].ObtenerNombre().ToLower() == nombre.ToLower())
            {
                return marcas[i];
            }
        }
        return null;
    }

    // Muestra solo los nombres de todas las marcas registradas.
    private void MostrarNombresDeMarcas()
    {
        if (contadorMarcas == 0)
        {
            Console.WriteLine("No hay marcas registradas.");
            return;
        }

        Console.WriteLine("Marcas registradas:");
        for (int i = 0; i < contadorMarcas; i++)
        {
            Console.WriteLine($"- {marcas[i].ObtenerNombre()}");
        }
    }
}

// Clase principal con el punto de entrada del programa.
class Program
{
    static void Main(string[] args)
    {
        GestorMarcas gestor = new GestorMarcas(); // Crea una instancia del gestor de marcas.
        bool salir = false; // Bandera para controlar el ciclo del menú.

        while (!salir)
        {
            // Menú de opciones.
            Console.WriteLine("\n----- MENÚ -----");
            Console.WriteLine("1. Agregar nueva marca");
            Console.WriteLine("2. Evaluar marca");
            Console.WriteLine("3. Seleccionar marca favorita");
            Console.WriteLine("4. Mostrar todas las marcas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string entrada = Console.ReadLine();

            // Se ejecuta la opción seleccionada por el usuario.
            if (entrada == "1")
            {
                gestor.AgregarMarca();
            }
            else if (entrada == "2")
            {
                gestor.EvaluarMarca();
            }
            else if (entrada == "3")
            {
                gestor.SeleccionarMarcaFavorita();
            }
            else if (entrada == "4")
            {
                gestor.MostrarMarcas();
            }
            else if (entrada == "5")
            {
                Console.WriteLine("Saliendo del programa.");
                salir = true;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente nuevamente.");
            }
        }
    }
}
